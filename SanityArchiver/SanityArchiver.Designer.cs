namespace SanityArchiver
{
    partial class SanityArchiver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openButtonLeft = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.pathLabelLeft = new System.Windows.Forms.Label();
            this.pathTextBoxLeft = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button();
            this.listViewRight = new System.Windows.Forms.ListView();
            this.pathTextBoxRight = new System.Windows.Forms.TextBox();
            this.pathLabelRight = new System.Windows.Forms.Label();
            this.openButtonRight = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.sizeLabelLeft = new System.Windows.Forms.Label();
            this.sizeLabelRight = new System.Windows.Forms.Label();
            this.searchField = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openButtonLeft
            // 
            this.openButtonLeft.Location = new System.Drawing.Point(368, 304);
            this.openButtonLeft.Name = "openButtonLeft";
            this.openButtonLeft.Size = new System.Drawing.Size(75, 23);
            this.openButtonLeft.TabIndex = 0;
            this.openButtonLeft.Text = "Open";
            this.openButtonLeft.UseVisualStyleBackColor = true;
            this.openButtonLeft.Click += new System.EventHandler(this.OpenButtonLeft_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewLeft
            // 
            this.listViewLeft.LargeImageList = this.imageList;
            this.listViewLeft.Location = new System.Drawing.Point(93, 12);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(350, 286);
            this.listViewLeft.TabIndex = 1;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewLeft_MouseClick);
            this.listViewLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewLeft_MouseDoubleClick);
            // 
            // pathLabelLeft
            // 
            this.pathLabelLeft.AutoSize = true;
            this.pathLabelLeft.Location = new System.Drawing.Point(90, 307);
            this.pathLabelLeft.Name = "pathLabelLeft";
            this.pathLabelLeft.Size = new System.Drawing.Size(32, 13);
            this.pathLabelLeft.TabIndex = 2;
            this.pathLabelLeft.Text = "Path:";
            // 
            // pathTextBoxLeft
            // 
            this.pathTextBoxLeft.Location = new System.Drawing.Point(131, 304);
            this.pathTextBoxLeft.Name = "pathTextBoxLeft";
            this.pathTextBoxLeft.Size = new System.Drawing.Size(231, 20);
            this.pathTextBoxLeft.TabIndex = 3;
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(12, 41);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 4;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(12, 12);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 5;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.CompressButton_Click);
            // 
            // listViewRight
            // 
            this.listViewRight.LargeImageList = this.imageList;
            this.listViewRight.Location = new System.Drawing.Point(449, 12);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(350, 286);
            this.listViewRight.TabIndex = 6;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            // 
            // pathTextBoxRight
            // 
            this.pathTextBoxRight.Location = new System.Drawing.Point(490, 304);
            this.pathTextBoxRight.Name = "pathTextBoxRight";
            this.pathTextBoxRight.Size = new System.Drawing.Size(228, 20);
            this.pathTextBoxRight.TabIndex = 9;
            // 
            // pathLabelRight
            // 
            this.pathLabelRight.AutoSize = true;
            this.pathLabelRight.Location = new System.Drawing.Point(449, 307);
            this.pathLabelRight.Name = "pathLabelRight";
            this.pathLabelRight.Size = new System.Drawing.Size(32, 13);
            this.pathLabelRight.TabIndex = 8;
            this.pathLabelRight.Text = "Path:";
            // 
            // openButtonRight
            // 
            this.openButtonRight.Location = new System.Drawing.Point(724, 304);
            this.openButtonRight.Name = "openButtonRight";
            this.openButtonRight.Size = new System.Drawing.Size(75, 23);
            this.openButtonRight.TabIndex = 7;
            this.openButtonRight.Text = "Open";
            this.openButtonRight.UseVisualStyleBackColor = true;
            this.openButtonRight.Click += new System.EventHandler(this.OpenButtonRight_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(12, 70);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 10;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(12, 99);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 11;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 128);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // sizeLabelLeft
            // 
            this.sizeLabelLeft.AutoSize = true;
            this.sizeLabelLeft.Location = new System.Drawing.Point(131, 331);
            this.sizeLabelLeft.Name = "sizeLabelLeft";
            this.sizeLabelLeft.Size = new System.Drawing.Size(76, 13);
            this.sizeLabelLeft.TabIndex = 13;
            this.sizeLabelLeft.Text = "Directory size: ";
            // 
            // sizeLabelRight
            // 
            this.sizeLabelRight.AutoSize = true;
            this.sizeLabelRight.Location = new System.Drawing.Point(490, 331);
            this.sizeLabelRight.Name = "sizeLabelRight";
            this.sizeLabelRight.Size = new System.Drawing.Size(73, 13);
            this.sizeLabelRight.TabIndex = 14;
            this.sizeLabelRight.Text = "Directory size:";
            // 
            // searchField
            // 
            this.searchField.Location = new System.Drawing.Point(9, 300);
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(75, 20);
            this.searchField.TabIndex = 15;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(9, 327);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SanityArchiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 357);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchField);
            this.Controls.Add(this.sizeLabelRight);
            this.Controls.Add(this.sizeLabelLeft);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.pathTextBoxRight);
            this.Controls.Add(this.pathLabelRight);
            this.Controls.Add(this.openButtonRight);
            this.Controls.Add(this.listViewRight);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.pathTextBoxLeft);
            this.Controls.Add(this.pathLabelLeft);
            this.Controls.Add(this.listViewLeft);
            this.Controls.Add(this.openButtonLeft);
            this.Name = "SanityArchiver";
            this.Text = "SanitiyArchiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButtonLeft;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.Label pathLabelLeft;
        private System.Windows.Forms.TextBox pathTextBoxLeft;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.ListView listViewRight;
        private System.Windows.Forms.TextBox pathTextBoxRight;
        private System.Windows.Forms.Label pathLabelRight;
        private System.Windows.Forms.Button openButtonRight;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label sizeLabelLeft;
        private System.Windows.Forms.Label sizeLabelRight;
        private System.Windows.Forms.TextBox searchField;
        private System.Windows.Forms.Button searchButton;
    }
}

