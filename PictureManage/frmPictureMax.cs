using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PictureManage
{
    public partial class frmPictureMax : Form
    {
        public frmPictureMax()
        {
            InitializeComponent();
        }
        public string FPath;
        public string PictureWidth;
        public string Pictureheight;
        public double SelectFileSize;
        private void frmPictureMax_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(PictureWidth) > 1024)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Image ig = Image.FromFile(FPath);
                
                this.Width = Convert.ToInt32(ig.Width);
                this.Height = Convert.ToInt32(ig.Height);
            }
            try
            {
                pictureBox1.Image = Image.FromFile(FPath);
                this.Text = FPath + "   " + "(" + PictureWidth + "¡Á" + Pictureheight + ")" + "   " + "[" + SelectFileSize.ToString("F") + "M]";
            }
            catch
            { 
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}