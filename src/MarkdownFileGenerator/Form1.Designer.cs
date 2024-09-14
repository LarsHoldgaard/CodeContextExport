namespace CodeContextExport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            treeViewFiles = new TreeView();
            imageListIcons = new ImageList(components);
            btnGenerate = new Button();
            FolderBrowserDialog = new FolderBrowserDialog();
            btnSetBasePath = new Button();
            txtBasePath = new TextBox();
            btnSetSavePath = new Button();
            txtSavePath = new TextBox();
            SuspendLayout();
            // 
            // treeViewFiles
            // 
            treeViewFiles.ImageIndex = 0;
            treeViewFiles.ImageList = imageListIcons;
            treeViewFiles.Location = new Point(12, 97);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.SelectedImageIndex = 0;
            treeViewFiles.Size = new Size(685, 341);
            treeViewFiles.TabIndex = 0;
            // 
            // imageListIcons
            // 
            imageListIcons.ColorDepth = ColorDepth.Depth32Bit;
            imageListIcons.ImageStream = (ImageListStreamer)resources.GetObject("imageListIcons.ImageStream");
            imageListIcons.TransparentColor = Color.Transparent;
            imageListIcons.Images.SetKeyName(0, "Foldericon.jpg");
            imageListIcons.Images.SetKeyName(1, "File.jpg");
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(713, 415);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnSetBasePath
            // 
            btnSetBasePath.Location = new Point(12, 12);
            btnSetBasePath.Name = "btnSetBasePath";
            btnSetBasePath.Size = new Size(99, 23);
            btnSetBasePath.TabIndex = 2;
            btnSetBasePath.Text = "Set Base Path";
            btnSetBasePath.UseVisualStyleBackColor = true;
            // 
            // txtBasePath
            // 
            txtBasePath.Location = new Point(117, 13);
            txtBasePath.Name = "txtBasePath";
            txtBasePath.Size = new Size(580, 23);
            txtBasePath.TabIndex = 3;
            // 
            // btnSetSavePath
            // 
            btnSetSavePath.Location = new Point(12, 41);
            btnSetSavePath.Name = "btnSetSavePath";
            btnSetSavePath.Size = new Size(99, 23);
            btnSetSavePath.TabIndex = 4;
            btnSetSavePath.Text = "Set Save Path";
            btnSetSavePath.UseVisualStyleBackColor = true;
            // 
            // txtSavePath
            // 
            txtSavePath.Location = new Point(117, 42);
            txtSavePath.Name = "txtSavePath";
            txtSavePath.Size = new Size(580, 23);
            txtSavePath.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSavePath);
            Controls.Add(btnSetSavePath);
            Controls.Add(txtBasePath);
            Controls.Add(btnSetBasePath);
            Controls.Add(btnGenerate);
            Controls.Add(treeViewFiles);
            Name = "MainForm";
            Text = "CodeContextExport";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewFiles;
        private Button btnGenerate;
        private FolderBrowserDialog FolderBrowserDialog;
        private ImageList imageListIcons;
        private Button btnSetBasePath;
        private TextBox txtBasePath;
        private Button btnSetSavePath;
        private TextBox txtSavePath;
    }
}