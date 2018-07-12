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
        List<FileInfo> filesList = new List<FileInfo>();

        public SanityArchiver()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            CreateFileList();
        }

        private void CreateFileList()
        {
            filesList.Clear();
            listView.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathTextBox.Text = fbd.SelectedPath;
                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                        FileInfo fileInfo = new FileInfo(item);
                        filesList.Add(fileInfo);
                        listView.Items.Add(fileInfo.Name, imageList.Images.Count - 1);
                    }
                }
            }
        }

        private void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                Process.Start(filesList[listView.FocusedItem.Index].FullName);
            }
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                FileInfo fi = filesList[listView.FocusedItem.Index];
                if ((File.GetAttributes(fi.FullName)
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
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
            }
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                FileInfo fi = filesList[listView.FocusedItem.Index];
                if (compressButton.Text == "Compress")
                {
                    Compress(fi);
                }
                else
                {
                    Decompress(fi);
                }
            }

            filesList.Clear();
            listView.Items.Clear();
            ListFiles(Directory.GetFiles(pathTextBox.Text));
        }

        private void ListFiles(string[] files)
        {
            foreach (string item in files)
            {
                imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                FileInfo fileInfo = new FileInfo(item);
                filesList.Add(fileInfo);
                listView.Items.Add(fileInfo.Name, imageList.Images.Count - 1);
            }
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
            if (listView.FocusedItem != null)
            {
                if (encryptButton.Text == "Decrypt")
                {
                    DecryptFile(filesList[listView.FocusedItem.Index].FullName);
                }
                else
                {
                    EncryptFile(filesList[listView.FocusedItem.Index].FullName);
                }
            }

            filesList.Clear();
            listView.Items.Clear();
            ListFiles(Directory.GetFiles(pathTextBox.Text));
        }

        private void EncryptFile(string inputFile)
        {
            File.Encrypt(inputFile);
        }

        private void DecryptFile(string inputFile)
        {
            File.Decrypt(inputFile);
        }
    }
}
