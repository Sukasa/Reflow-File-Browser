namespace Reflow_Oven_File_Browser
{
    partial class frmMain
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
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnRescan = new System.Windows.Forms.Button();
            this.olvFiles = new BrightIdeasSoftware.ObjectListView();
            this.RemoteFileTree = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RemoteFileSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.olvServers = new BrightIdeasSoftware.ObjectListView();
            this.ServerNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ServerIPColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ServerStatusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvServers)).BeginInit();
            this.SuspendLayout();
            // 
            // ilIcons
            // 
            this.ilIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRescan
            // 
            this.btnRescan.Location = new System.Drawing.Point(366, 86);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(75, 23);
            this.btnRescan.TabIndex = 4;
            this.btnRescan.Text = "Rescan";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // olvFiles
            // 
            this.olvFiles.AllColumns.Add(this.RemoteFileTree);
            this.olvFiles.AllColumns.Add(this.RemoteFileSize);
            this.olvFiles.CellEditUseWholeCell = false;
            this.olvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RemoteFileTree,
            this.RemoteFileSize});
            this.olvFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvFiles.FullRowSelect = true;
            this.olvFiles.HasCollapsibleGroups = false;
            this.olvFiles.SelectedBackColor = System.Drawing.Color.Empty;
            this.olvFiles.SelectedForeColor = System.Drawing.Color.Empty;
            this.olvFiles.IsSearchOnSortColumn = false;
            this.olvFiles.Location = new System.Drawing.Point(12, 142);
            this.olvFiles.Name = "olvFiles";
            this.olvFiles.ShowGroups = false;
            this.olvFiles.Size = new System.Drawing.Size(348, 305);
            this.olvFiles.SmallImageList = this.ilIcons;
            this.olvFiles.TabIndex = 5;
            this.olvFiles.UseCompatibleStateImageBehavior = false;
            this.olvFiles.View = System.Windows.Forms.View.Details;
            this.olvFiles.DoubleClick += new System.EventHandler(this.olvFiles_DoubleClick);
            // 
            // RemoteFileTree
            // 
            this.RemoteFileTree.AspectName = "Name";
            this.RemoteFileTree.AutoCompleteEditor = false;
            this.RemoteFileTree.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.RemoteFileTree.FillsFreeSpace = true;
            this.RemoteFileTree.Hideable = false;
            this.RemoteFileTree.IsEditable = false;
            this.RemoteFileTree.Text = "File";
            // 
            // RemoteFileSize
            // 
            this.RemoteFileSize.AspectName = "FileSize";
            this.RemoteFileSize.AspectToStringFormat = "{0}";
            this.RemoteFileSize.Hideable = false;
            this.RemoteFileSize.IsEditable = false;
            this.RemoteFileSize.Text = "Size";
            this.RemoteFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RemoteFileSize.Width = 80;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(366, 142);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(366, 171);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(366, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // olvServers
            // 
            this.olvServers.AllColumns.Add(this.ServerNameColumn);
            this.olvServers.AllColumns.Add(this.ServerIPColumn);
            this.olvServers.AllColumns.Add(this.ServerStatusColumn);
            this.olvServers.CellEditUseWholeCell = false;
            this.olvServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerNameColumn,
            this.ServerIPColumn,
            this.ServerStatusColumn});
            this.olvServers.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvServers.SelectedBackColor = System.Drawing.Color.Empty;
            this.olvServers.SelectedForeColor = System.Drawing.Color.Empty;
            this.olvServers.Location = new System.Drawing.Point(12, 12);
            this.olvServers.Name = "olvServers";
            this.olvServers.ShowGroups = false;
            this.olvServers.Size = new System.Drawing.Size(348, 97);
            this.olvServers.SmallImageList = this.ilIcons;
            this.olvServers.TabIndex = 10;
            this.olvServers.UseCompatibleStateImageBehavior = false;
            this.olvServers.View = System.Windows.Forms.View.Details;
            this.olvServers.SelectedIndexChanged += new System.EventHandler(this.SelectServer);
            // 
            // ServerNameColumn
            // 
            this.ServerNameColumn.AspectName = "FriendlyName";
            this.ServerNameColumn.Text = "Server Name";
            this.ServerNameColumn.Width = 120;
            // 
            // ServerIPColumn
            // 
            this.ServerIPColumn.AspectName = "Endpoint";
            this.ServerIPColumn.Text = "Server IP";
            this.ServerIPColumn.Width = 80;
            // 
            // ServerStatusColumn
            // 
            this.ServerStatusColumn.AspectName = "Status";
            this.ServerStatusColumn.FillsFreeSpace = true;
            this.ServerStatusColumn.Text = "Server Status";
            this.ServerStatusColumn.Width = 120;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Location = new System.Drawing.Point(366, 229);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(75, 23);
            this.btnNewFolder.TabIndex = 11;
            this.btnNewFolder.Text = "New Folder";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(13, 123);
            this.lblCurrentFolder.Name = "label1";
            this.lblCurrentFolder.Size = new System.Drawing.Size(153, 13);
            this.lblCurrentFolder.TabIndex = 12;
            this.lblCurrentFolder.Text = "This is where the file path goes";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 459);
            this.Controls.Add(this.lblCurrentFolder);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.olvServers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.olvFiles);
            this.Controls.Add(this.btnRescan);
            this.Name = "frmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.olvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olvServers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.Button btnRescan;
        private BrightIdeasSoftware.ObjectListView olvFiles;
        private BrightIdeasSoftware.OLVColumn RemoteFileTree;
        private BrightIdeasSoftware.OLVColumn RemoteFileSize;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnDelete;
        private BrightIdeasSoftware.ObjectListView olvServers;
        private BrightIdeasSoftware.OLVColumn ServerNameColumn;
        private BrightIdeasSoftware.OLVColumn ServerIPColumn;
        private BrightIdeasSoftware.OLVColumn ServerStatusColumn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Label lblCurrentFolder;

    }
}

