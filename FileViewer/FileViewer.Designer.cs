using BlueprintIT.Controls;
namespace BlueprintIT.FileViewer
{
  partial class FileViewer
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
      System.Windows.Forms.SplitContainer splitContainer;
      System.Windows.Forms.ColumnHeader nameHeader;
      System.Windows.Forms.ColumnHeader typeHeader;
      System.Windows.Forms.ColumnHeader sizeHeader;
      this.listView = new System.Windows.Forms.ListView();
      this.mainMenu = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupByTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.iconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
      this.fileWatcher = new System.IO.FileSystemWatcher();
      this.viewers = new BlueprintIT.Controls.BpTabControl();
      splitContainer = new System.Windows.Forms.SplitContainer();
      nameHeader = new System.Windows.Forms.ColumnHeader();
      typeHeader = new System.Windows.Forms.ColumnHeader();
      sizeHeader = new System.Windows.Forms.ColumnHeader();
      splitContainer.Panel1.SuspendLayout();
      splitContainer.Panel2.SuspendLayout();
      splitContainer.SuspendLayout();
      this.mainMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer
      // 
      splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer.Location = new System.Drawing.Point(0, 0);
      splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      splitContainer.Panel1.Controls.Add(this.listView);
      splitContainer.Panel1.Controls.Add(this.mainMenu);
      // 
      // splitContainer.Panel2
      // 
      splitContainer.Panel2.Controls.Add(this.viewers);
      splitContainer.Size = new System.Drawing.Size(712, 527);
      splitContainer.SplitterDistance = 242;
      splitContainer.TabIndex = 1;
      // 
      // listView
      // 
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            nameHeader,
            typeHeader,
            sizeHeader});
      this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView.LabelEdit = true;
      this.listView.Location = new System.Drawing.Point(0, 24);
      this.listView.MultiSelect = false;
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(242, 503);
      this.listView.TabIndex = 0;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      this.listView.ItemActivate += new System.EventHandler(this.ItemSelected);
      this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
      // 
      // nameHeader
      // 
      nameHeader.Text = "Name";
      nameHeader.Width = 200;
      // 
      // typeHeader
      // 
      typeHeader.Text = "Type";
      typeHeader.Width = 150;
      // 
      // sizeHeader
      // 
      sizeHeader.Text = "File Size";
      // 
      // mainMenu
      // 
      this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
      this.mainMenu.Location = new System.Drawing.Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new System.Drawing.Size(242, 24);
      this.mainMenu.TabIndex = 2;
      this.mainMenu.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupByTypeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.largeToolStripMenuItem,
            this.iconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // groupByTypeToolStripMenuItem
      // 
      this.groupByTypeToolStripMenuItem.Checked = true;
      this.groupByTypeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.groupByTypeToolStripMenuItem.Name = "groupByTypeToolStripMenuItem";
      this.groupByTypeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.groupByTypeToolStripMenuItem.Text = "Group by type";
      this.groupByTypeToolStripMenuItem.Click += new System.EventHandler(this.groupByTypeToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
      // 
      // largeToolStripMenuItem
      // 
      this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
      this.largeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.largeToolStripMenuItem.Text = "Tiles";
      this.largeToolStripMenuItem.Click += new System.EventHandler(this.largeToolStripMenuItem_Click);
      // 
      // iconsToolStripMenuItem
      // 
      this.iconsToolStripMenuItem.Name = "iconsToolStripMenuItem";
      this.iconsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.iconsToolStripMenuItem.Text = "Icons";
      this.iconsToolStripMenuItem.Click += new System.EventHandler(this.iconsToolStripMenuItem_Click);
      // 
      // listToolStripMenuItem
      // 
      this.listToolStripMenuItem.Name = "listToolStripMenuItem";
      this.listToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.listToolStripMenuItem.Text = "List";
      this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
      // 
      // detailsToolStripMenuItem
      // 
      this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
      this.detailsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
      this.detailsToolStripMenuItem.Text = "Details";
      this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
      // 
      // folderBrowser
      // 
      this.folderBrowser.ShowNewFolderButton = false;
      // 
      // fileWatcher
      // 
      this.fileWatcher.EnableRaisingEvents = true;
      this.fileWatcher.SynchronizingObject = this;
      this.fileWatcher.Created += new System.IO.FileSystemEventHandler(this.FileAdded);
      this.fileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.FileDeleted);
      this.fileWatcher.Renamed += new System.IO.RenamedEventHandler(this.FileRenamed);
      // 
      // viewers
      // 
      this.viewers.BackColor = System.Drawing.SystemColors.Control;
      this.viewers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.viewers.ImageList = null;
      this.viewers.Location = new System.Drawing.Point(0, 0);
      this.viewers.Name = "viewers";
      this.viewers.SelectedIndex = -1;
      this.viewers.SelectedTab = null;
      this.viewers.Size = new System.Drawing.Size(466, 527);
      this.viewers.TabCloseStyle = BlueprintIT.Controls.TabCloseStyle.SelectedAndHover;
      this.viewers.TabIndex = 0;
      this.viewers.TabClosed += new BlueprintIT.Controls.TabEventHandler(this.ViewerClosed);
      // 
      // FileViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 527);
      this.Controls.Add(splitContainer);
      this.MainMenuStrip = this.mainMenu;
      this.Name = "FileViewer";
      this.Text = "Paper Viewer";
      splitContainer.Panel1.ResumeLayout(false);
      splitContainer.Panel1.PerformLayout();
      splitContainer.Panel2.ResumeLayout(false);
      splitContainer.ResumeLayout(false);
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    private System.IO.FileSystemWatcher fileWatcher;
    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem groupByTypeToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem iconsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
    private BpTabControl viewers;

  }
}

