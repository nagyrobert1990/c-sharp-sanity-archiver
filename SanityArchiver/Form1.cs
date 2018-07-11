using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        List<string> filesList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filesList.Clear();
            listView1.Items.Clear();
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select path" })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                    {
                        imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        FileInfo fileInfo = new FileInfo(item);
                        filesList.Add(fileInfo.FullName);
                        listView1.Items.Add(fileInfo.Name, imageList1.Images.Count - 1);

                    }
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                Process.Start(filesList[listView1.FocusedItem.Index]);
            }
        }
    }
}
