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
    private double zoom = 1;

    public ImageViewer()
    {
      InitializeComponent();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);
      Capture = true;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      Capture = false;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      if (Bounds.Contains(e.Location))
      {
        if (picture.SizeMode == PictureBoxSizeMode.AutoSize)
        {
          zoom = picture.Image.Size.Width / picture.Size.Width;
          picture.SizeMode = PictureBoxSizeMode.StretchImage;
          picture.Dock = DockStyle.None;
        }
        if (e.Delta < 0)
        {
          zoom /= 1.5;
        }
        else if (e.Delta > 0)
        {
          zoom *= 1.5;
        }
        zoom = Math.Min(zoom, 5.0625);
        zoom = Math.Max(zoom, 0.087791495198902606310013717421125);
        picture.Size = new Size((int)Math.Round(picture.Image.Width * zoom), (int)Math.Round(picture.Image.Height * zoom));
      }
    }

    protected override void OnFileChanged(FileChangedEventArgs e)
    {
      base.OnFileChanged(e);
      picture.Dock = DockStyle.Fill;
      picture.SizeMode = PictureBoxSizeMode.AutoSize;
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

