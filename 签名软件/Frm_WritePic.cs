using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using 签名软件.Entity;

namespace 签名软件
{
    public partial class Frm_WritePic : Form
    {

        public Frm_WritePic()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable("dt");
        int height = 200;

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {

            this.monthCalendar1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            //monthCalendar1.Size = new Size(400, 380);
            #region 注释
            //dt.Columns.Add("Names");
            //dt.Columns.Add("Times");
            //dt.Columns.Add("CreateDate");


            //// dateTimePicker1.CustomFormat = "yyyy-MM-dd";


            ////var files = Directory.GetFiles(Application.StartupPath + @"\WriteImage", "*.jpg");

            //DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\WriteImage");
            //DataTable dr = new DataTable();

            //dr.Columns.Add("Names");
            //dr.Columns.Add("Times");
            //dr.Columns.Add("CreateDate");
            //foreach (FileInfo fi in di.GetFiles("*.jpg"))
            //{
            //    dt.Rows.Add();
            //    dt.Rows[dt.Rows.Count - 1][1] = fi.CreationTime;
            //    dt.Rows[dt.Rows.Count - 1][0] = fi.Name;

            //    if (fi.CreationTime.CompareTo(fi.LastWriteTime) >= 0)
            //    {
            //        dt.Rows[dt.Rows.Count - 1][2] = string.Format("{0:yyyy-MM-dd}", fi.LastWriteTime);
            //    }
            //    else
            //    {
            //        dt.Rows[dt.Rows.Count - 1][2] = string.Format("{0:yyyy-MM-dd}", fi.CreationTime);
            //    }



            //    dr.Rows.Add();
            //    dr.Rows[dr.Rows.Count - 1][1] = fi.CreationTime;
            //    dr.Rows[dr.Rows.Count - 1][0] = fi.Name;
            //    dr.Rows[dr.Rows.Count - 1][2] = string.Format("{0:yyyy-MM-dd}", fi.CreationTime);

            //    //fi.Name //获取文件名。
            //    //fi.CreationTime  //获取或设置当前 FileSystemInfo 对象的创建时间。 
            //    //fi.LastAccessTime  //获取或设置上次访问当前文件或目录的时间。
            //    //fi.LastWriteTime   //获取或设置上次写入当前文件或目录的时间。 



            //}

            //DataView dv = new DataView(dr);
            //dv.Sort = "Times desc";
            //dr = dv.ToTable();

            //DataView dv2 = new DataView(dt);
            //dt = dv2.ToTable();
            ////int height = this.flowLayoutPanel1.Height - 50;

            //for (int index = 0; index < dr.Rows.Count; index++)
            //{
            //    //Button btn = new Button();
            //    //btn.BackgroundImage = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\" + dr.Rows[index][0].ToString());
            //    //btn.Size = new Size(400, this.flowLayoutPanel1.Height - 50);
            //    //btn.Location = new Point(0, 0);
            //    //btn.FlatStyle = FlatStyle.Flat;
            //    //btn.FlatAppearance.BorderSize = 0;
            //    //btn.BackgroundImageLayout = ImageLayout.Stretch;
            //    //btn.Click += btn_Click;
            //    //this.flowLayoutPanel1.Controls.Add(btn);

            //    Image b = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\" + dr.Rows[index][0].ToString());
            //    Button btn = new Button();
            //    btn.Size = Thumbnail.ResizeImage(b.Width, b.Height, 150, height);
            //    btn.BackgroundImage = b;
            //    btn.Location = new Point(0, 0);
            //    btn.FlatStyle = FlatStyle.Flat;
            //    btn.FlatAppearance.BorderSize = 0;
            //    btn.BackgroundImageLayout = ImageLayout.Stretch;
            //    btn.Click += btn_Click;
            //    this.flowLayoutPanel1.Controls.Add(btn);



            //} 
            #endregion

            initImgList();
        }

        /// <summary>
        /// 初始化图片列表
        /// </summary>
        private void initImgList()
        {
            flowLayoutPanel1.Controls.Clear();//清除子空间

            //创建列标题
            dt.Columns.Add("Names");
            dt.Columns.Add("Times");
            dt.Columns.Add("CreateDate");


            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\WriteImage");
            foreach (FileInfo fi in di.GetFiles("*.jpg"))
            {
                dt.Rows.Add();

                //  dt.Rows[dt.Rows.Count - 1][1] = fi.CreationTime;
                // dt.Rows[dt.Rows.Count - 1][0] = fi.Name;
                dt.Rows[dt.Rows.Count - 1]["Names"] = fi.Name;
                if (fi.CreationTime.CompareTo(fi.LastWriteTime) >= 0)
                {
                    dt.Rows[dt.Rows.Count - 1]["Times"] = fi.LastWriteTime;
                    dt.Rows[dt.Rows.Count - 1]["CreateDate"] = string.Format("{0:yyyy-MM-dd}", fi.LastWriteTime);
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["Times"] = fi.CreationTime;
                    dt.Rows[dt.Rows.Count - 1]["CreateDate"] = string.Format("{0:yyyy-MM-dd}", fi.CreationTime);
                }
            }
            //fi.Name //获取文件名。
            //fi.CreationTime  //获取或设置当前 FileSystemInfo 对象的创建时间。 
            //fi.LastAccessTime  //获取或设置上次访问当前文件或目录的时间。
            //fi.LastWriteTime   //获取或设置上次写入当前文件或目录的时间。 



            DataView dv2 = new DataView(dt);
            dv2.Sort = "Times desc";
            dt = dv2.ToTable();

            DataRow[] drs = dt.Select(string.Format("CreateDate >= '{0}'", DateTime.Now.AddDays(-31)));

            foreach (DataRow dr in drs)
            {
                Image b = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\" + dr["Names"].ToString());
                Button btn = new Button();
                btn.Size = Thumbnail.ResizeImage(b.Width, b.Height, 150, height);
                btn.BackgroundImage = b;
                btn.Location = new Point(0, 0);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Click += btn_Click;
                this.flowLayoutPanel1.Controls.Add(btn);
            }

        }

        /// <summary>
        /// 点击查看图片
        /// </summary>
        private void btn_Click(object sender, EventArgs e)
        {
            //this.pictureBox1.BackgroundImage = ((Button)sender).BackgroundImage;

            //Image img = Thumbnail.pictureProcess(b, 900, 800);
            Image img = Thumbnail.GetThumbnail(new Bitmap(((Button)sender).BackgroundImage), 890, 700);
            this.pictureBox1.BackgroundImage = img;
        }

        /// <summary>
        /// 返回
        /// </summary>
        private void btn_Write_Click(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_Main frm = new Frm_Main();
            frm.MdiParent = staticMain.MainMDI;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
            frm.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.Show();
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string date = string.Format("{0:yyyy-MM-dd}", monthCalendar1.SelectionStart);
            //string date = "";
            DataRow[] drs = dt.Select(string.Format("CreateDate='{0}'", date));
            if (drs.Length <= 0)
            {
                MessageBox.Show("您当前查询的日期不存在签名记录！");
                return;
            }

            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow dr in drs)
            {
                Image b = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\" + dr["Names"].ToString());
                Button btn = new Button();
                btn.Size = Thumbnail.ResizeImage(b.Width, b.Height, 150, height);
                btn.BackgroundImage = b;
                btn.Location = new Point(0, 0);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Click += btn_Click;
                this.flowLayoutPanel1.Controls.Add(btn);
            }

        }

        /// <summary>
        /// 清除
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            DataRow[] drs = dt.Select(string.Format("CreateDate >= '{0}'", DateTime.Now.AddDays(-31)));

            foreach (DataRow dr in drs)
            {
                Image b = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\" + dr["Names"].ToString());
                Button btn = new Button();
                btn.Size = Thumbnail.ResizeImage(b.Width, b.Height, 150, height);
                btn.BackgroundImage = b;
                btn.Location = new Point(0, 0);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Click += btn_Click;
                this.flowLayoutPanel1.Controls.Add(btn);
            }
        }
    }
}
