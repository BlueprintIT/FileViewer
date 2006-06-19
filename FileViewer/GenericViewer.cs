using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using BlueprintIT.Shell;

namespace BlueprintIT.FileViewer
{
  public partial class GenericViewer : Viewer
  {
    private object browserFlags = -1;
    private object editFlags = -1;
    private RegistryKey fileClass;

    public GenericViewer()
    {
      InitializeComponent();
    }

    protected override void OnFileChanged(FileChangedEventArgs e)
    {
 	    base.OnFileChanged(e);
      if (fileClass != null)
        FileLoaded(null, null);

      RegistryKey key = Registry.ClassesRoot.OpenSubKey("." + file.Extension);
      if (key != null)
      {
        string classname = key.GetValue(null).ToString();
        fileClass = Registry.ClassesRoot.OpenSubKey(classname, true);
        if (fileClass != null)
        {
          browserFlags = fileClass.GetValue("BrowserFlags");
          if (browserFlags != null)
          {
            int bflags = (int)browserFlags;
            if ((bflags & 8) > 0)
            {
              bflags -= 8;
              if (bflags == 0)
                fileClass.DeleteValue("BrowserFlags");
              else
                fileClass.SetValue("BrowserFlags", bflags);
            }
          }

          editFlags = fileClass.GetValue("EditFlags");
          int flags;
          if (editFlags != null)
          {
            if (fileClass.GetValueKind("EditFlags")==RegistryValueKind.Binary)
            {
              byte[] parts = (byte[])editFlags;
              flags = parts[0] +
                      parts[1] << 8 +
                      parts[2] << 16 +
                      parts[3] << 24;
            }
            else
              flags = (int)editFlags;
          }
          else
            flags = 0;

          if ((flags & 65536) == 0)
          {
            flags += 65536;
            fileClass.SetValue("EditFlags", flags);
          }
        }
      }
      webBrowser.Navigate(new Uri(file.Path));
    }

    private void FileLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (fileClass == null)
        return;

      if (browserFlags == null)
        fileClass.DeleteValue("BrowserFlags");
      else
        fileClass.SetValue("BrowserFlags", browserFlags);

      if (editFlags == null)
        fileClass.DeleteValue("EditFlags");
      else
        fileClass.SetValue("EditFlags", editFlags);

      fileClass = null;
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

