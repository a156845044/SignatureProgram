using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace 签名软件
{
    public partial class Frm_WriteName : Form
    {
        Bitmap bitmap, bitPicture;
        bool flag = true;
        int intTimes = 0;
        Thread th;
        //private Point p1, p2;//定义两个点（启点，终点）  
        //private static bool drawing = false;//设置一个启动标志  
        Pen pen = new Pen(Color.Black, 2);
        List<Point> currentScribble = null;
        List<Point[]> scribbles = new List<Point[]>();
        private FilterInfoCollection videoDevices;
        public Frm_WriteName()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;
        }
        SynchronizationContext _syncContext = null;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;

            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    tscbxCameras.Items.Add(device.Name);
                }


                tscbxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                tscbxCameras.Items.Add("无视频设备");
                videoDevices = null;
            }
            //Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //img = Image.FromHbitmap(bmp.GetHbitmap());
            //pictureBox1.Image = img;
            //Point p = new Point( (this.Size.Width - this.pan_Menus.Width) / 2, (this.Size.Height-this.pan_Menus.Size.Height)/2);
            //this.pan_Menus.Location = p;
        }



        private void btn_Write_Click(object sender, EventArgs e)
        {

            Frm_Main frm = new Frm_Main();
            frm.ShowDialog();
            this.Hide();
        }

        private void pic_Write_MouseDown(object sender, MouseEventArgs e)
        {
            //p1 = new Point(e.X, e.Y);
            //p2 = new Point(e.X, e.Y);
            //drawing = true;  

            currentScribble = new List<Point>();
            currentScribble.Add(e.Location);
        }

        private void pic_Write_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics g = pictureBox1.CreateGraphics();
            //if (e.Button == MouseButtons.Left)
            //{
            //    if (drawing)
            //    {
            //        //drawing = true;  
            //        Point currentPoint = new Point(e.X, e.Y);
            //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除锯齿  
            //        g.DrawLine(pen, p2, currentPoint);

            //        p2.X = currentPoint.X;
            //        p2.Y = currentPoint.Y;
            //    }

            //}  

            if (e.Button == MouseButtons.Left && this.currentScribble != null)
            {
                currentScribble.Add(e.Location);
                RedrawPictureBox();
            }

        }

        private void RedrawPictureBox()
        {
            if (currentScribble.Count >= 2)
            {
                Rectangle last = new Rectangle(currentScribble[currentScribble.Count - 2], Size.Empty);
                Rectangle current = new Rectangle(currentScribble[currentScribble.Count - 1], Size.Empty);
                Rectangle invalidateArea = Rectangle.Inflate(Rectangle.Union(last, current), 2, 2);
                this.pictureBox1.Invalidate(invalidateArea);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentScribble != null && currentScribble.Count > 1)
            {
                RedrawPictureBox();
                this.scribbles.Add(currentScribble.ToArray());
            }
            this.currentScribble = null;
            //drawing = false;  
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string strFileName = DateTime.Today.ToString("yyyyMMdd") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".jpg";
            Rectangle rect = new Rectangle(Point.Empty, this.pictureBox1.Size);
            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height))
            {
                this.pictureBox1.DrawToBitmap(bmp, rect);  // 画pictureBox1显示的图，假定它没有边框
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    pictureBox1_Paint(this, new PaintEventArgs(g, rect)); // 画自定义标记
                }
                bmp.Save(Application.StartupPath + @"\WriteImage\" + strFileName, ImageFormat.Jpeg);

                Frm_Print frmprint = new Frm_Print(Application.StartupPath + @"\WriteImage\" + strFileName);
                frmprint.MdiParent = staticMain.MainMDI;
                //frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
                frmprint.Dock = DockStyle.Fill;
                frmprint.TopMost = true;
                frmprint.Show();


                //MessageBox.Show("保存成功！");
            }



            ////videPlayer.SignalToStop();
            ////videPlayer.WaitForStop();
            ////this.Close();
            //string strFileName = DateTime.Today.ToString("yyyyMMdd") + DateTime.Today.Hour.ToString() + DateTime.Today.Minute.ToString() + DateTime.Today.Second.ToString() + ".jpg";
            //System.Drawing.Image img = pictureBox1.BackgroundImage;
            //img.Save(strFileName);
            ////this.pictureBox1.Image.Save(Application.StartupPath + @"\WriteImage\" + strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        private delegate void FlushClient();//代理
        public void SetText()
        {
            button5.Text = "1";
            Thread.Sleep(1000);
            button5.Text = "2";
            Thread.Sleep(1000);
            button5.Text = "3";
            Thread.Sleep(1000);
            button5.Text = "";

        }
        public int Index = 0;
        public void SetLabelText(object text)
        {
            this.button5.Text = text.ToString();
        }
        private void threadMethod()
        {
            while (true)
            {
                this.Index++;
                if (this.Index <= 3)
                {
                    _syncContext.Post(SetLabelText, this.Index);//子线程中通过UI线程上下文更新UI 
                    Thread.Sleep(1000);
                }
                else
                {
                    _readThread.Abort();
                }
            }
        }
        private Thread _readThread;
        private void button5_Click(object sender, EventArgs e)
        {
            //TextBoxSetValue tbsv = new TextBoxSetValue(this.button5, "1"); 
            //ThreadStart TS = new ThreadStart(SetText);
            //Thread T = new Thread(TS);
            //T.Start();

            _readThread = new Thread(new ThreadStart(this.threadMethod));
            _readThread.Start();

        }


        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                pen.Width = this.zoomTrackBarControl1.Value;
            }
            catch { }
        }

        private void colorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Color c = this.colorPickEdit1.Color;
                pen.Color = c;
            }
            catch { }
        }

        private void tscbxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {

            CameraConn();

        }

        private void CameraConn()
        {
            try
            {
                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[tscbxCameras.SelectedIndex].MonikerString);
                videoSource.DesiredFrameSize = new Size(1670, 892);
                videoSource.DesiredFrameRate = 1;

                videPlayer.VideoSource = videoSource;
                videPlayer.Start();
            }
            catch { }
        }

        private void videPlayer_NewFrame(object sender, ref Bitmap image)
        {
            bitPicture = image;
            //this.pictureBox1.Refresh();

            this.pictureBox1.BackgroundImage = bitPicture.Clone(new Rectangle(0, 0, bitPicture.Width, bitPicture.Height), bitPicture.PixelFormat);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG|*.JPG";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (this.openFileDialog1.FileName.Length > 0)
            {
                this.pictureBox1.BackgroundImage = (System.Drawing.Image.FromFile(openFileDialog1.FileName, false));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_WriteName frm = new Frm_WriteName();
            frm.MdiParent = staticMain.MainMDI;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
            frm.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.Show();





        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Color c = this.colorPickEdit1.Color;


            using (pen = new Pen(c, this.zoomTrackBarControl1.Value))
            {
                foreach (Point[] points in scribbles)
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除锯齿  
                    e.Graphics.DrawLines(pen, points);

                }
                if (this.currentScribble != null)
                {
                    try
                    {
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//消除锯齿  
                        e.Graphics.DrawLines(pen, this.currentScribble.ToArray());
                    }
                    catch { }
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_Main frm = new Frm_Main();
            frm.MdiParent = staticMain.MainMDI;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            intTimes++;
            this.button5.Text = intTimes.ToString();
            if (intTimes > 3)
            {
                try
                {
                    videPlayer.SignalToStop();
                    videPlayer.WaitForStop();

                    this.timer1.Stop();
                    intTimes = 0;
                    this.button5.Text = "";
                    this.pictureBox1.Image = null;
                    //this.pictureBox1.Refresh();
                    this.pictureBox1.BackgroundImage = bitPicture.Clone(new Rectangle(0, 0, bitPicture.Width, bitPicture.Height), bitPicture.PixelFormat);

                }
                catch { }
            }

        }

        private void Frm_WriteName_FormClosing(object sender, FormClosingEventArgs e)
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
            _readThread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button5.Text = "1212";
        }

        private void button5_TextChanged(object sender, EventArgs e)
        {
            if (this.button5.Text == "1")
            {
                this.button5.Text = "1";
            }
            if (this.button5.Text == "2")
            {
                this.button5.Text = "2";
            }
            if (this.button5.Text == "3")
            {
                try
                {
                    videPlayer.SignalToStop();
                    videPlayer.WaitForStop();


                    this.pictureBox1.Image = null;
                    //this.pictureBox1.Refresh();
                    this.pictureBox1.BackgroundImage = bitPicture.Clone(new Rectangle(0, 0, bitPicture.Width, bitPicture.Height), bitPicture.PixelFormat);

                }
                catch { }
            }
        }
    }

    //class TextBoxSetValue
    //{ 
    //    private Button _TextBox; 
    //    private string _Value; 
    //    public TextBoxSetValue(Button TxtBox, String Value) 
    //    { 
    //        _TextBox = TxtBox; 
    //        _Value = Value; 
    //    }

    //}
}
