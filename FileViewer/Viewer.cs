using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BlueprintIT.Shell;

namespace BlueprintIT.FileViewer
{
  public delegate void FileChangedEventHandler(object sender, FileChangedEventArgs e);

  public delegate void TitleChangedEventHandler(object sender, TitleChangedEventArgs e);

  public class FileChangedEventArgs : EventArgs
  {
    private FileDetails oldfile;
    private FileDetails newfile;

    public FileChangedEventArgs(FileDetails oldfile, FileDetails newfile)
    {
      this.oldfile = oldfile;
      this.newfile = newfile;
    }

    public FileDetails NewFile
    {
      get
      {
        return newfile;
      }
    }

    public FileDetails OldFile
    {
      get
      {
        return oldfile;
      }
    }
  }

  public class TitleChangedEventArgs : EventArgs
  {
    private string title;

    public TitleChangedEventArgs(string title)
    {
      this.title = title;
    }

    public string Title
    {
      get
      {
        return title;
      }
    }
  }

  public interface IViewerFactory
  {
    bool Enabled
    {
      get;
    }

    int GetExtensionPriority(string extension);

    bool CanDisplayFile(FileDetails file);

    Viewer CreateViewer();
  }

  public partial class Viewer : UserControl
  {
    private static IList<IViewerFactory> factories = new List<IViewerFactory>();

    static Viewer()
    {
      new GenericViewerFactory();
      new ImageViewerFactory();
    }

    public static Viewer CreateViewer(FileDetails file)
    {
      IDictionary<int, IViewerFactory> priorities = new SortedDictionary<int, IViewerFactory>();

      foreach (IViewerFactory factory in factories)
      {
        if (factory.Enabled)
        {
          int priority = factory.GetExtensionPriority(file.Extension);
          if (priority >= 0)
            priorities[-priority] = factory;
        }
      }

      foreach (KeyValuePair<int, IViewerFactory> kvp in priorities)
      {
        if (kvp.Value.CanDisplayFile(file))
        {
          try
          {
            Viewer viewer = kvp.Value.CreateViewer();
            viewer.File = file;
            return viewer;
          }
          catch (Exception)
          {
          }
        }
      }
      return null;
    }

    public static void AddViewerFactory(IViewerFactory f)
    {
      factories.Add(f);
    }

    protected FileDetails file;

    public Viewer()
    {
      InitializeComponent();
    }

    public event FileChangedEventHandler FileChanged;
    public event TitleChangedEventHandler TitleChanged;

    protected virtual void OnFileChanged(FileChangedEventArgs e)
    {
      if (FileChanged != null)
        FileChanged(this, e);
    }

    protected virtual void OnTitleChanged(TitleChangedEventArgs e)
    {
      if (TitleChanged != null)
        TitleChanged(this, e);
    }

    public virtual string Title
    {
      get
      {
        if (file == null)
          return "";
        string title = file.FileName;
        if (title.LastIndexOf(".") > 0)
          return title.Substring(0, title.LastIndexOf("."));
        return title;
      }
    }

    public virtual FileDetails File
    {
      get
      {
        return file;
      }

      set
      {
        if (file != value)
        {

          string title = Title;
          FileChangedEventArgs e = new FileChangedEventArgs(file, value);
          file = value;
          OnFileChanged(e);
          if (title != Title)
          {
            TitleChangedEventArgs f = new TitleChangedEventArgs(Title);
            OnTitleChanged(f);
          }
        }
      }
    }
  }
}
