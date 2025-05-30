namespace CodeContextExport
{
    partial class Form1
    {
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
            linkClearSelection = new LinkLabel();
            lstRecents = new ListBox();
            lblRecents = new Label();
            lblFilter = new Label();
            txtFilter = new TextBox();
            SuspendLayout();
            // 
            // treeViewFiles
            // 
            treeViewFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewFiles.ImageIndex = 0;
            treeViewFiles.ImageList = imageListIcons;
            treeViewFiles.Location = new Point(12, 100);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.SelectedImageIndex = 0;
            treeViewFiles.Size = new Size(660, 338);
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
            btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerate.Location = new Point(690, 415);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(247, 23);
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
            txtBasePath.Size = new Size(555, 23);
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
            txtSavePath.Size = new Size(555, 23);
            txtSavePath.TabIndex = 5;
            // 
            // linkClearSelection
            // 
            linkClearSelection.AutoSize = true;
            linkClearSelection.Location = new Point(12, 70);
            linkClearSelection.Name = "linkClearSelection";
            linkClearSelection.Size = new Size(84, 15);
            linkClearSelection.TabIndex = 6;
            linkClearSelection.TabStop = true;
            linkClearSelection.Text = "Clear selection";
            // 
            // lstRecents
            // 
            lstRecents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstRecents.FormattingEnabled = true;
            lstRecents.ItemHeight = 15;
            lstRecents.Location = new Point(690, 116);
            lstRecents.Name = "lstRecents";
            lstRecents.Size = new Size(247, 289);
            lstRecents.TabIndex = 7;
            // 
            // lblRecents
            // 
            lblRecents.AutoSize = true;
            lblRecents.Location = new Point(690, 98);
            lblRecents.Name = "lblRecents";
            lblRecents.Size = new Size(48, 15);
            lblRecents.TabIndex = 8;
            lblRecents.Text = "Recents";
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(450, 74);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(36, 15);
            lblFilter.TabIndex = 9;
            lblFilter.Text = "Filter:";
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(492, 71);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(180, 23);
            txtFilter.TabIndex = 10;
            txtFilter.TextChanged += txtFilter_TextChanged;

            linkExpandAll = new LinkLabel();
            linkExpandAll.AutoSize = true;
            linkExpandAll.Location = new Point(110, 70);          // just to the right of “Clear selection”
            linkExpandAll.Name = "linkExpandAll";
            linkExpandAll.Size = new Size(63, 15);
            linkExpandAll.TabIndex = 11;
            linkExpandAll.TabStop = true;
            linkExpandAll.Text = "Expand all";
            linkExpandAll.LinkClicked += linkExpandAll_LinkClicked;

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 450);
            Controls.Add(lblRecents);
            Controls.Add(lstRecents);
            Controls.Add(linkClearSelection);
            Controls.Add(txtSavePath);
            Controls.Add(btnSetSavePath);
            Controls.Add(txtBasePath);
            Controls.Add(btnSetBasePath);
            Controls.Add(btnGenerate);
            Controls.Add(treeViewFiles);
            Controls.Add(linkExpandAll);
            Controls.Add(lblFilter);
            Controls.Add(txtFilter);
            Name = "Form1";
            Text = "CodeContextExport";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFiles;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.Button btnSetBasePath;
        private System.Windows.Forms.TextBox txtBasePath;
        private System.Windows.Forms.Button btnSetSavePath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.LinkLabel linkClearSelection;
        private System.Windows.Forms.ListBox lstRecents;
        private System.Windows.Forms.Label lblRecents;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.LinkLabel linkExpandAll;
    }
}
