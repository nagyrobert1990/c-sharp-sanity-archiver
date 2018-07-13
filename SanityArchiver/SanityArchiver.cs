using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class SanityArchiver : Form
    {
        List<FileInfo> filesListLeft = new List<FileInfo>();
        List<FileInfo> filesListRight = new List<FileInfo>();

        public SanityArchiver()
        {
            InitializeComponent();
        }

        private void OpenButtonLeft_Click(object sender, EventArgs e)
        {
            CreateFileList(filesListLeft, listViewLeft, pathTextBoxLeft, sizeLabelLeft);
        }

        private void OpenButtonRight_Click(object sender, EventArgs e)
        {
            CreateFileList(filesListRight, listViewRight, pathTextBoxRight, sizeLabelRight);
        }

        private void CreateFileList(List<FileInfo> fi, ListView lv, TextBox ptb, Label sl, string searchPattern = "*")
        {
            fi.Clear();
            lv.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    ptb.Text = fbd.SelectedPath;

                    foreach (string item in Directory.GetFiles(fbd.SelectedPath, searchPattern))
                    {
                        imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                        FileInfo fileInfo = new FileInfo(item);
                        fi.Add(fileInfo);
                        lv.Items.Add(fileInfo.Name, imageList.Images.Count - 1);
                    }

                    sl.Text = $"Directory size: {GetDirectorySize(fbd.SelectedPath)} byte";
                }
            }
        }

        private long GetDirectorySize(string searchDirectory)
        {
            var files = Directory.EnumerateFiles(searchDirectory);

            var currentSize = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();

            var directories = Directory.EnumerateDirectories(searchDirectory);

            var subDirSize = (from directory in directories select GetDirectorySize(directory)).Sum();

            return currentSize + subDirSize;
        }

        private void ListFiles(string[] files, List<FileInfo> fl, ListView lv, TextBox tb, Label sl)
        {
            fl.Clear();
            lv.Items.Clear();

            foreach (string item in files)
            {
                imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                FileInfo fileInfo = new FileInfo(item);
                fl.Add(fileInfo);
                lv.Items.Add(fileInfo.Name, imageList.Images.Count - 1);
            }

            sl.Text = $"Directory size: {GetDirectorySize(tb.Text)} byte";
        }

        private void RefreshBothListView()
        {
            try
            {
                ListFiles(Directory.GetFiles(pathTextBoxLeft.Text), filesListLeft, listViewLeft, pathTextBoxLeft, sizeLabelLeft);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                ListFiles(Directory.GetFiles(pathTextBoxRight.Text), filesListRight, listViewRight, pathTextBoxRight, sizeLabelRight);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void ListViewLeft_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                Process.Start(filesListLeft[listViewLeft.FocusedItem.Index].FullName);
            }
        }

        private void ListViewLeft_MouseClick(object sender, MouseEventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                FileInfo fi = filesListLeft[listViewLeft.FocusedItem.Index];
                if (fi.Extension != ".gz")
                {
                    compressButton.Text = "Compress";
                }
                else
                {
                    compressButton.Text = "Decomress";
                }

                FileAttributes attr = File.GetAttributes(fi.FullName);
                if ((attr & FileAttributes.Encrypted) == FileAttributes.Encrypted)
                {
                    encryptButton.Text = "Decrypt";
                }
                else
                {
                    encryptButton.Text = "Encrypt";
                }

                if ((attr & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    hideButton.Text = "Unhide";
                }
                else
                {
                    hideButton.Text = "Hide";
                }

                if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    roButton.Text = "Writable";
                }
                else
                {
                    roButton.Text = "Read-only";
                }
            }
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                FileInfo fi = filesListLeft[listViewLeft.FocusedItem.Index];
                if (compressButton.Text == "Compress")
                {
                    Compress(fi);
                }
                else
                {
                    Decompress(fi);
                }
            }

            RefreshBothListView();
        }

        private void Compress(FileInfo fi)
        {
            using (FileStream inFile = fi.OpenRead())
            {
                using (FileStream outFile =
                            File.Create(fi.FullName + ".gz"))
                {
                    using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                    {
                        inFile.CopyTo(Compress);
                    }
                }
            }
        }

        private void Decompress(FileInfo fi)
        {
            using (FileStream originalFileStream = fi.OpenRead())
            {
                string currentFileName = fi.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fi.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                if (encryptButton.Text == "Decrypt")
                {
                    DecryptFile(filesListLeft[listViewLeft.FocusedItem.Index].FullName);
                }
                else
                {
                    EncryptFile(filesListLeft[listViewLeft.FocusedItem.Index].FullName);
                }
            }

            RefreshBothListView();
        }

        private void EncryptFile(string inputFile)
        {
            File.Encrypt(inputFile);
        }

        private void DecryptFile(string inputFile)
        {
            File.Decrypt(inputFile);
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                string sourcePath = filesListLeft[listViewLeft.FocusedItem.Index].FullName;
                string targetPath = pathTextBoxRight.Text + "\\" + filesListLeft[listViewLeft.FocusedItem.Index].Name;

                File.Copy(sourcePath, targetPath, true);

                RefreshBothListView();
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                string sourcePath = filesListLeft[listViewLeft.FocusedItem.Index].FullName;
                string targetPath = pathTextBoxRight.Text + "\\" + filesListLeft[listViewLeft.FocusedItem.Index].Name;

                try
                {
                    File.Move(sourcePath, targetPath);
                }
                catch (Exception)
                {
                    return;
                }

                RefreshBothListView();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                string sourcePath = filesListLeft[listViewLeft.FocusedItem.Index].FullName;

                try
                {
                    File.Delete(sourcePath);
                }
                catch (Exception)
                {
                    return;
                }

                RefreshBothListView();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchField.Text))
            {
                RefreshBothListView();
            }
            else
            {
                string searchPattern = "*" + searchField.Text + "*";
                ListFiles(Directory.GetFiles(pathTextBoxLeft.Text, searchPattern), filesListLeft, listViewLeft, pathTextBoxLeft, sizeLabelLeft);
            }
        }

        private FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                string filePath = filesListLeft[listViewLeft.FocusedItem.Index].FullName;

                FileInfo fi = new FileInfo(filePath);
                FileAttributes attributes = File.GetAttributes(fi.FullName);


                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    // Show the file.
                    attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                    File.SetAttributes(filePath, attributes);
                }
                else
                {
                    // Hide the filefilePath
                    File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.Hidden);
                }
            }
        }

        private void roButton_Click(object sender, EventArgs e)
        {
            if (listViewLeft.FocusedItem != null)
            {
                string filePath = filesListLeft[listViewLeft.FocusedItem.Index].FullName;
                FileAttributes attributes = File.GetAttributes(filePath);

                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    // unset Read only on file.
                    attributes = attributes & ~FileAttributes.ReadOnly;
                    File.SetAttributes(filePath, attributes);
                }
                else
                {
                    // set Read only on file.
                    attributes = attributes | FileAttributes.ReadOnly;
                    File.SetAttributes(filePath, attributes);
                }
            }
        }
    }
}
