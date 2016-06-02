using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
//Download by http://www.codefans.net
namespace PictureManage
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region �Զ��巽��
        public int Pindex;
        public string TPath()
        {
            string TemporaryPath;
            TemporaryPath = Application.StartupPath.ToString();
            TemporaryPath = TemporaryPath.Substring(0, TemporaryPath.LastIndexOf("\\"));
            TemporaryPath = TemporaryPath.Substring(0, TemporaryPath.LastIndexOf("\\"));
            TemporaryPath += @"\TemporaryFolder";
            return TemporaryPath;
        }

        public void ToolStatusUnable()
        {
            contextMenuStrip1.Enabled = false;
            ��Ϊ���汳��ToolStripMenuItem1.Enabled = false;
            ת��ΪToolStripMenuItem.Enabled = false;
            ɾ��ToolStripMenuItem1.Enabled = false;
            ������ToolStripMenuItem1.Enabled = false;
            ���ΪToolStripMenuItem1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            ��ӡToolStripMenuItem1.Enabled = false;
            ͼƬ��ЧToolStripMenuItem.Enabled = false;
            ͼƬ����ToolStripMenuItem.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            ͼƬ����ToolStripMenuItem.Enabled = false;
            toolStripButton7.Enabled = false;
        }

        public void ToolStatusEnable()
        {
            contextMenuStrip1.Enabled = true;
            ��Ϊ���汳��ToolStripMenuItem1.Enabled = true;
            ת��ΪToolStripMenuItem.Enabled = true;
            ɾ��ToolStripMenuItem1.Enabled = true;
            ������ToolStripMenuItem1.Enabled = true;
            ���ΪToolStripMenuItem1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            ��ӡToolStripMenuItem1.Enabled = true;
            ͼƬ��ЧToolStripMenuItem.Enabled = true;
            ͼƬ����ToolStripMenuItem.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            ͼƬ����ToolStripMenuItem.Enabled = true;
            toolStripButton7.Enabled = true;
        }
        #endregion

        #region ����API
        [DllImport("user32.dll",EntryPoint="SystemParametersInfoA")]
        static extern Int32 SystemParametersInfo(Int32 uAction,Int32 uParam,string lpvparam,Int32 fuwinIni);
        private const int SPI_SETDESKWALLPAPER=20;
        #endregion

        #region �������
        private void frmMain_Load(object sender, EventArgs e)
        {
            tsslDate.Text = DateTime.Now.ToString();
            DirectoryInfo DInfo = new DirectoryInfo(TPath());
            FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();
            for (int i = 0; i < FSInfo.Length; i++)
            {
                try
                {
                    FileInfo FInfo = new FileInfo(TPath() + "\\" + FSInfo[i].ToString());
                    FInfo.Delete();
                }
                catch
                { }
            }
            if (listBox1.Items.Count == 0)
            {
                ToolStatusUnable();
            }
        }
      
        private void frmMain_Activated_1(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                listBox1_SelectedIndexChanged_1(sender,e);
            }
        }
        #endregion

        #region ������
        string PPath;
        public string sum;
        private void toolStripButton1_Click(object sender, EventArgs e)//�������еġ��򿪡�
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                PPath = folderBrowserDialog1.SelectedPath;
                DirectoryInfo DInfo = new DirectoryInfo(PPath);
                FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();
                for (int i = 0; i < FSInfo.Length; i++)
                {
                    string FileType = FSInfo[i].ToString().Substring(FSInfo[i].ToString().LastIndexOf(".") + 1, (FSInfo[i].ToString().Length - FSInfo[i].ToString().LastIndexOf(".") - 1));
                    FileType = FileType.ToLower();
                    if (FileType == "jpg" || FileType == "png" || FileType == "bmp" || FileType == "gif" || FileType == "jpeg")
                    {
                        listBox1.Items.Add(FSInfo[i].ToString());
                    }
                }
                sum = listBox1.Items.Count.ToString();
            }
        }     
   
        private void toolStripButton2_Click(object sender, EventArgs e)//ˢ�°�ť
        {
            if (listBox1.Items.Count == 0)
            {
                toolStripButton2.Enabled = false;
            }
            else
            {
                toolStripButton2.Enabled = true;
                listBox1.Items.Clear();
                pictureBox1.Image = null;
                DirectoryInfo DInfo = new DirectoryInfo(PPath);
                FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();
                for (int i = 0; i < FSInfo.Length; i++)
                {
                    string FileType = FSInfo[i].ToString().Substring(FSInfo[i].ToString().LastIndexOf(".") + 1, (FSInfo[i].ToString().Length - FSInfo[i].ToString().LastIndexOf(".") - 1));
                    FileType = FileType.ToLower();
                    if (FileType == "jpg" || FileType == "png" || FileType == "bmp" || FileType == "gif" || FileType == "jpeg")
                    {
                        listBox1.Items.Add(FSInfo[i].ToString());
                    }
                }
                ToolStatusUnable();
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ��ӡToolStripMenuItem_Click(sender,e);
        }
        private void ״̬��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (״̬��ToolStripMenuItem.CheckState == CheckState.Checked)
            {
                ״̬��ToolStripMenuItem.CheckState = CheckState.Unchecked;
                statusStrip1.Visible = false;
            }
            else
            {
                ״̬��ToolStripMenuItem.CheckState = CheckState.Checked;
                statusStrip1.Visible = true;
            }
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (������ToolStripMenuItem.CheckState == CheckState.Checked)
            {
                ������ToolStripMenuItem.CheckState = CheckState.Unchecked;
                toolStrip1.Visible = false;
            }
            else
            {
                ������ToolStripMenuItem.CheckState = CheckState.Checked;
                toolStrip1.Visible = true;
            }
        }
        private void ͼƬ��ϢToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ͼƬ��ϢToolStripMenuItem.CheckState == CheckState.Checked)
            {
                ͼƬ��ϢToolStripMenuItem.CheckState = CheckState.Unchecked;
                button1.Visible = false;
            }
            else
            {
                ͼƬ��ϢToolStripMenuItem.CheckState = CheckState.Checked;
                button1.Visible = true;
            }
        }       
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ɾ��ToolStripMenuItem_Click(sender, e);
        }
        private void toolStripButton5_Click(object sender, EventArgs e)//�����������ϡ�
        {
            try
            {
                if (listBox1.SelectedIndex != 0)
                {
                    listBox1.SetSelected(listBox1.SelectedIndex - 1, true);
                }
            }
            catch
            { }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)//�����������¡�
        {
            try
            {
                if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                {
                    listBox1.SetSelected(listBox1.SelectedIndex + 1, true);
                }
            }
            catch
            { }
        }
        private void ͼƬ��ЧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                frmSpecialEfficacy special = new frmSpecialEfficacy();
                special.ig = pictureBox1.Image;
                special.ShowDialog();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//��ת
        {
            Image myImage = pictureBox1.Image;
            myImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = myImage;
        }
        #endregion

        #region �����¼�
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int printWidth = printDocument1.DefaultPageSettings.PaperSize.Width;
            int printHeight = printDocument1.DefaultPageSettings.PaperSize.Height;
            if (Convert.ToInt32(PictureWidth) <= printWidth)
            {
                float x = (printWidth - Convert.ToInt32(PictureWidth)) / 2;
                float y=(printHeight-Convert.ToInt32(Pictureheight))/2;
                e.Graphics.DrawImage(Image.FromFile(FPath), x, y, Convert.ToInt32(PictureWidth), Convert.ToInt32(Pictureheight));
            }
            else
            {
                if (Convert.ToInt32(PictureWidth) > Convert.ToInt32(Pictureheight))
                {
                    Bitmap bitmap = (Bitmap)Bitmap.FromFile(FPath);
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    PictureBox pb = new PictureBox();
                    pb.Image = bitmap;
                    Single a = printWidth / Convert.ToSingle(Pictureheight);
                    e.Graphics.DrawImage(pb.Image, 0, 0, Convert.ToSingle(Pictureheight) * a,  Convert.ToSingle(PictureWidth)*a);
                }
                else
                {
                    Single a = printWidth / Convert.ToSingle(PictureWidth);
                    e.Graphics.DrawImage(Image.FromFile(FPath), 0, 0, Convert.ToSingle(PictureWidth) * a, Convert.ToSingle(Pictureheight) * a);
                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                frmPictureMax pictureMax = new frmPictureMax();
                pictureMax.FPath = FPath;
                pictureMax.PictureWidth = PictureWidth;
                pictureMax.Pictureheight = Pictureheight;
                pictureMax.SelectFileSize = SelectFileSize;
                pictureMax.ShowDialog();
            }
        }

        public Bitmap image1;
        public string FPath;
        public string PictureWidth;
        public string Pictureheight;
        public double SelectFileSize;
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    ToolStatusEnable();
                }
                pictureBox1.BackColor = Color.Black;

                string FName = listBox1.SelectedItem.ToString();
                if (PPath.Length == 4)
                {
                    FPath = PPath + FName;
                }
                else
                {
                    FPath = PPath + "\\" + FName;
                }

                DirectoryInfo DInfo = new DirectoryInfo(TPath());
                FileSystemInfo[] FSInfo = DInfo.GetFileSystemInfos();
                for (int i = 0; i < FSInfo.Length; i++)
                {
                    try
                    {
                        FileInfo FInfo = new FileInfo(TPath() + "\\" + FSInfo[i].ToString());
                        FInfo.Delete();
                    }
                    catch
                    { }
                }

                string newFilePath;
                string SFileType = FPath.Substring(FPath.LastIndexOf(".") + 1, (FPath.Length - FPath.LastIndexOf(".") - 1));
                FileInfo finfos = new FileInfo(TPath() + "\\" + FName);
                if (finfos.Exists)
                {
                    newFilePath = TPath() + "\\" + FName;
                }
                else
                {
                    File.Copy(FPath, TPath() + "\\" + FName, true);
                    newFilePath = TPath() + "\\" + FName;
                }
                pictureBox1.Image = Image.FromFile(newFilePath);
                image1 = new Bitmap(newFilePath);
                PictureWidth = image1.Width.ToString();
                Pictureheight = image1.Height.ToString();
                FileInfo finfo = new FileInfo(newFilePath);
                string FileSize = finfo.Length.ToString();
                SelectFileSize = Convert.ToDouble(FileSize) / 1024 / 1024;
                button1.Text = "ͼƬ��С��" + SelectFileSize.ToString("F") + "M   " + "�ֱ��ʣ�" + PictureWidth + "��" + Pictureheight;
                image1.Dispose();
                toolStripStatusLabel3.Text = sum;
                toolStripStatusLabel1.Text = Convert.ToString(listBox1.SelectedIndex + 1);
                toolStripStatusLabel2.Visible = true;
                //contextMenuStrip1.Enabled = true;
                ToolStatusEnable();
                Pindex = listBox1.SelectedIndex;//��ǰѡ������ֵ

            }
            catch
            {}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslDate.Text = DateTime.Now.ToString();
        }
        #endregion

        #region �ļ��˵�

        private void ����Ŀ¼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void ˢ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ��Ϊ���汳��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ��Ϊ���汳��ToolStripMenuItem_Click(sender,e);
        }

        private void ɾ��ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ɾ��ToolStripMenuItem_Click(sender, e);
        }

        private void ������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ������ToolStripMenuItem_Click(sender, e);
        }

        private void ��ӡToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ��ӡToolStripMenuItem_Click(sender, e);
        }

        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            string Opath = FPath.Remove(FPath.LastIndexOf("\\"));
            string Npath;
            if (Opath.Length == 4)
            {
                Npath = Opath;
            }
            else
            {
                Npath = Opath + "\\";
            }
            Bitmap bt = new Bitmap(pictureBox1.Image);
            bt.Save(Npath + fName + ".bmp", ImageFormat.Bmp);
            FileInfo fi = new FileInfo(FPath);
            fi.Delete();
            toolStripButton2_Click(sender, e);

        }

        private void gIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            string Opath = FPath.Remove(FPath.LastIndexOf("\\"));
            string Npath;
            if (Opath.Length == 4)
            {
                Npath = Opath;
            }
            else
            {
                Npath = Opath + "\\";
            }
            Bitmap bt = new Bitmap(pictureBox1.Image);
            bt.Save(Npath + fName + ".gif", ImageFormat.Gif);
            FileInfo fi = new FileInfo(FPath);
            fi.Delete();
            toolStripButton2_Click(sender, e);
        }

        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            string Opath = FPath.Remove(FPath.LastIndexOf("\\"));
            string Npath;
            if (Opath.Length == 4)
            {
                Npath = Opath;
            }
            else
            {
                Npath = Opath + "\\";
            }
            Bitmap bt = new Bitmap(pictureBox1.Image);
            bt.Save(Npath + fName + ".Jpeg", ImageFormat.Jpeg);
            FileInfo fi = new FileInfo(FPath);
            fi.Delete();
            toolStripButton2_Click(sender, e);
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            string Opath = FPath.Remove(FPath.LastIndexOf("\\"));
            string Npath;
            if (Opath.Length == 4)
            {
                Npath = Opath;
            }
            else
            {
                Npath = Opath + "\\";
            }
            Bitmap bt = new Bitmap(pictureBox1.Image);
            bt.Save(Npath + fName + ".Png", ImageFormat.Png);
            FileInfo fi = new FileInfo(FPath);
            fi.Delete();
            toolStripButton2_Click(sender, e);
        }

        private void ͼƬ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPicAdjust picadjust = new frmPicAdjust();
            picadjust.ig = pictureBox1.Image;
            picadjust.PicOldPath = FPath;
            picadjust.ShowDialog();
        }
        private void �˳�CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�˳�ϵͳ��","��ʾ",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void �õ�Ƭ��ӳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog2.SelectedPath;
                frmSlide slide = new frmSlide();
                slide.Ppath = path;
                slide.ShowDialog();
            }
        }

        #endregion

        #region �Ҽ��˵�
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = FPath.Remove(2, 1);
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                files.Add(path);
                Clipboard.SetFileDropList(files);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                                                                                                                                                                                        
                File.Delete(FPath);
                toolStripButton2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ˢ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }
        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            string fType = FPath.Substring(FPath.LastIndexOf(".") + 1, (FPath.Length - FPath.LastIndexOf(".") - 1));
            frmRename rename = new frmRename();
            rename.filename = fName;
            rename.filepath = FPath;
            rename.filetype = fType;
            rename.ShowDialog();
        }

        private void ��ӡToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void ��Ϊ���汳��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //��ȡָ��ͼƬ����չ��
            string SFileType = FPath.Substring(FPath.LastIndexOf(".") + 1, (FPath.Length - FPath.LastIndexOf(".") - 1));
            //����չ��ת����Сд
            SFileType = SFileType.ToLower();
            //��ȡ�ļ���
            string SFileName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            //���ͼƬ��������bmp�����API�еķ�����������Ϊ���汳��
            if (SFileType == "bmp")
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, FPath, 1);
            }
            else
            {
                string SystemPath = Environment.SystemDirectory;//��ȡϵͳ·��
                string path = SystemPath + "\\" + SFileName + ".bmp";
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    fi.Delete();
                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromFile(FPath);
                    pb.Image.Save(SystemPath + "\\" + SFileName + ".bmp", ImageFormat.Bmp);
                }
                else
                {
                    PictureBox pb = new PictureBox();
                    pb.Image = Image.FromFile(FPath);
                    pb.Image.Save(SystemPath + "\\" + SFileName + ".bmp", ImageFormat.Bmp);
                }
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, 1);
            }
        }

        private void ���ΪToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "BMP|*.bmp|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string picPath = saveFileDialog1.FileName;
                    string picType = picPath.Substring(picPath.LastIndexOf(".") + 1, (picPath.Length - picPath.LastIndexOf(".") - 1));
                    switch (picType)
                    {
                        case "bmp":
                            Bitmap bt = new Bitmap(FPath);
                            bt.Save(picPath, ImageFormat.Bmp); break;
                        case "jpeg":
                            Bitmap bt1 = new Bitmap(FPath);
                            bt1.Save(picPath, ImageFormat.Jpeg); break;
                        case "gif":
                            Bitmap bt2 = new Bitmap(FPath);
                            bt2.Save(picPath, ImageFormat.Gif); break;
                        case "png":
                            Bitmap bt3 = new Bitmap(FPath);
                            bt3.Save(picPath, ImageFormat.Png); break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ���ΪToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ���ΪToolStripMenuItem_Click(sender, e);
        }
        #endregion

        private void ͼƬ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                frmWater water = new frmWater();
                water.ig = pictureBox1.Image;
                water.FPath = FPath;
                water.ShowDialog();
            } 
        }

    }
}