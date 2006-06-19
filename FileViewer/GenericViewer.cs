using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BlueprintIT.Shell;

namespace BlueprintIT.FileViewer
{
  public partial class GenericViewer : Viewer
  {
    public GenericViewer()
    {
      InitializeComponent();
    }

    protected override void  OnFileChanged(FileChangedEventArgs e)
    {
 	    base.OnFileChanged(e);
      webBrowser.Navigate(new Uri(file.Path));
    }
  }

  public class GenericViewerFactory : IViewerFactory
  {
    public GenericViewerFactory()
    {
      Viewer.AddViewerFactory(this);
    }

    public bool Enabled
    {
      get
      {
        return true;
      }
    }

    public int GetExtensionPriority(string extension)
    {
      if ((extension == "HTML") ||
          (extension == "HTM"))
        return 100;

      return 0;
    }

    public bool CanDisplayFile(FileDetails file)
    {
      return true;
    }

    public Viewer CreateViewer()
    {
      return new GenericViewer();
    }
  }
}

