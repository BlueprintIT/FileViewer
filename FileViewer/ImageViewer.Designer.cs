namespace BlueprintIT.FileViewer
{
  partial class ImageViewer
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
      System.Windows.Forms.Panel panel1;
      this.picture = new System.Windows.Forms.PictureBox();
      panel1 = new System.Windows.Forms.Panel();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      panel1.AutoScroll = true;
      panel1.Controls.Add(this.picture);
      panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      panel1.Location = new System.Drawing.Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new System.Drawing.Size(150, 150);
      panel1.TabIndex = 0;
      // 
      // picture
      // 
      this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picture.Location = new System.Drawing.Point(0, 0);
      this.picture.Name = "picture";
      this.picture.Size = new System.Drawing.Size(150, 150);
      this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picture.TabIndex = 0;
      this.picture.TabStop = false;
      // 
      // ImageViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Controls.Add(panel1);
      this.Name = "ImageViewer";
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picture;

  }
}
