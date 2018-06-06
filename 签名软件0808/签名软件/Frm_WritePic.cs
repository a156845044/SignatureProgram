using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 签名软件
{
    public partial class Frm_WritePic : Form
    {

        public Frm_WritePic()
        {
            InitializeComponent();
        }

  

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //var files = Directory.GetFiles(Application.StartupPath + @"\WriteImage", "*.jpg");

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\WriteImage");
            DataTable dr=new DataTable ();
            dr.Columns.Add("Names");
            dr.Columns.Add("Times");
            foreach (FileInfo fi in di.GetFiles("*.jpg"))
            {
               dr.Rows.Add();
               dr.Rows[dr.Rows.Count-1][1]= fi.CreationTime;
               dr.Rows[dr.Rows.Count - 1][0] = fi.Name;
                //fi.Name //获取文件名。
                //fi.CreationTime  //获取或设置当前 FileSystemInfo 对象的创建时间。 
                //fi.LastAccessTime  //获取或设置上次访问当前文件或目录的时间。
                //fi.LastWriteTime   //获取或设置上次写入当前文件或目录的时间。 
            }
          DataView dv = new DataView(dr);
          dv.Sort = "Times desc";
          dr = dv.ToTable();

          for (int index = 0; index < dr.Rows.Count;index++ )
          {

              Button btn = new Button();
              btn.BackgroundImage = Bitmap.FromFile(Application.StartupPath + @"\WriteImage\"+dr.Rows[index][0].ToString());
              btn.Size = new Size(400, this.flowLayoutPanel1.Height - 50);
              btn.Location = new Point(0, 0);
              btn.FlatStyle = FlatStyle.Flat;
              btn.FlatAppearance.BorderSize = 0;
              btn.BackgroundImageLayout = ImageLayout.Stretch;
              btn.Click+=btn_Click;
              this.flowLayoutPanel1.Controls.Add(btn);



          }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = ((Button)sender).BackgroundImage;
        }

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






    }
}
