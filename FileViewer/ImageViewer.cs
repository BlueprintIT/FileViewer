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
  public partial class ImageViewer : Viewer
  {
    public ImageViewer()
    {
      InitializeComponent();
    }

    protected override void OnFileChanged(FileChangedEventArgs e)
    {
      base.OnFileChanged(e);
      picture.Image = Image.FromFile(file.Path);
    }
  }

  public class ImageViewerFactory : IViewerFactory
  {
    public ImageViewerFactory()
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
      if ((extension == "GIF") ||
          (extension == "PNG") ||
          (extension == "JPG") ||
          (extension == "JPEG") ||
          (extension == "BMP"))
      {
        return 10;
      }
      return -1;
    }

    public bool CanDisplayFile(FileDetails file)
    {
      return true;
    }

    public Viewer CreateViewer()
    {
      return new ImageViewer();
    }
  }
}

