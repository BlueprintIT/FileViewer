using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using BlueprintIT.Shell;
using BlueprintIT.Controls;

namespace BlueprintIT.FileViewer
{
  public partial class FileViewer : Form
  {
    private string path;
    private IDictionary<FileDetails, BpTabPage> tabs = new Dictionary<FileDetails, BpTabPage>();

    public FileViewer(string path)
    {
      InitializeComponent();
      listView.SmallImageList = FileDetails.SmallIcons;
      listView.LargeImageList = FileDetails.LargeIcons;
      viewers.ImageList = FileDetails.SmallIcons;
      if (path != null)
        UpdatePath(path);
      else if (folderBrowser.ShowDialog() == DialogResult.OK)
        UpdatePath(folderBrowser.SelectedPath);
      else
        Close();
    }

    private void AddFile(FileDetails file)
    {
      if ((file.File.Attributes & FileAttributes.Hidden) != 0)
        return;
      ListViewGroup type = null;
      foreach (ListViewGroup group in listView.Groups)
      {
        if (group.Header == file.TypeName)
        {
          type = group;
          break;
        }
      }
      if (type == null)
      {
        type = new ListViewGroup(file.TypeName);
        listView.Groups.Add(type);
      }

      string name = file.FileName;
      int pos = name.LastIndexOf('.');
      if (pos > 0)
        name = name.Substring(0, pos);
      ListViewItem item = new ListViewItem(name, file.IconIndex, type);
      item.SubItems.Add(file.TypeName);
      item.SubItems.Add(file.ReadableSize);
      item.Tag = file;
      listView.Items.Add(item);
    }

    private void RemoveFile(FileDetails file)
    {
      if (tabs.ContainsKey(file))
      {
        BpTabPage page = tabs[file];
        viewers.Controls.Remove(page);
      }
      foreach (ListViewItem item in listView.Items)
      {
        if (item.Tag == file)
          listView.Items.Remove(item);
      }
    }

    private void UpdatePath(string path)
    {
      this.path = path;
      string[] files = Directory.GetFiles(path);
      listView.Items.Clear();
      listView.Groups.Clear();
      foreach (string file in files)
      {
        FileDetails details = FileDetails.GetFileDetails(file);
        AddFile(details);
      }
      fileWatcher.Path = path;
      fileWatcher.EnableRaisingEvents = true;
    }

    private void FileAdded(object sender, FileSystemEventArgs e)
    {
      FileDetails file = FileDetails.GetFileDetails(e.FullPath);
      AddFile(file);
    }

    private void FileDeleted(object sender, FileSystemEventArgs e)
    {
      FileDetails file = FileDetails.GetFileDetails(e.FullPath);
      RemoveFile(file);
    }

    private void FileRenamed(object sender, RenamedEventArgs e)
    {
      FileDetails file = FileDetails.GetFileDetails(e.OldFullPath);
      RemoveFile(file);
      file = FileDetails.GetFileDetails(e.FullPath);
      AddFile(file);
    }

    private void ItemSelected(object sender, EventArgs e)
    {
      ListViewItem item = listView.SelectedItems[0];
      FileDetails file = (FileDetails)item.Tag;
      if (tabs.ContainsKey(file))
      {
        viewers.SelectedTab = tabs[file];
      }
      else
      {
        Viewer viewer = Viewer.CreateViewer(file);
        BpTabPage newpage = new BpTabPage();
        newpage.Text = viewer.Title;
        newpage.ImageIndex = item.ImageIndex;
        tabs[file] = newpage;
        viewers.Controls.Add(newpage);
        viewers.SelectedTab = newpage;
        newpage.Controls.Add(viewer);
        viewer.Dock = DockStyle.Fill;
      }
    }

    private void groupByTypeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView.ShowGroups = !listView.ShowGroups;
      groupByTypeToolStripMenuItem.Checked = listView.ShowGroups;
    }

    private void largeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView.View = View.Tile;
    }

    private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView.View = View.LargeIcon;
    }

    private void listToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView.View = View.SmallIcon;
    }

    private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      listView.View = View.Details;
    }

    private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
      if (e.Label != null)
      {
        ListViewItem item = listView.Items[e.Item];
        FileInfo file = ((FileDetails)item.Tag).File;
        try
        {
          string ext = "";
          int pos = file.Name.LastIndexOf('.');
          if (pos > 0)
            ext = file.Name.Substring(pos);
          string newname = file.DirectoryName + "\\" + e.Label + ext;
          file.MoveTo(newname);
        }
        catch (Exception ex)
        {
          e.CancelEdit = true;
          Debug.WriteLine(ex.ToString());
        }
      }
    }

    private void ViewerClosed(object sender, TabEventArgs e)
    {
      FileDetails file = null;
      viewers.Controls.Remove(e.TabPage);
      foreach (KeyValuePair<FileDetails, BpTabPage> kvp in tabs)
      {
        if (kvp.Value == e.TabPage)
        {
          file = kvp.Key;
        }
      }
      if (file != null)
        tabs.Remove(file);
    }
  }
}