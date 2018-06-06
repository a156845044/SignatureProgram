using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 签名软件
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dr=new DataTable ();
            dr.Columns.Add("Password");
            dr.Rows.Add();
            Frm_Password frm = new Frm_Password(dr);
            frm.ShowDialog();

            if (dr.Rows[0][0].ToString() == "1223456")
            {
                Application.Exit();
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标经过
      
            //Point p = new Point((this.Size.Width - this.pan_Menus.Width) / 2, (this.Size.Height - this.pan_Menus.Size.Height) / 2);
            //this.pan_Menus.Location = p;
            this.BackgroundImageLayout = ImageLayout.Stretch;
 
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void btn_Write_Click(object sender, EventArgs e)
        {
            Frm_WriteName frm = new Frm_WriteName();
            frm.MdiParent = staticMain.MainMDI;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
            frm.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.Show();

            #region 原来就注释
            //staticMain.MainMDI.CloseAllForm();  
            //Frm_WriteMain frm = new Frm_WriteMain();
            //frm.MdiParent = staticMain.MainMDI;
            //frm.Dock = DockStyle.Fill;
            //frm.Show();
            //if (this.MdiParent.MdiChildren.Contains(frm) == true)
            //{
            //    frm.Show();
            //}
            //else
            //{

            //    frm.Activate();
            //}
            //foreach (Form childForm in this.MdiParent.MdiChildren)
            //{
            //    if (childForm.Name == frm.Name)
            //    {
            //        frm.Show();
            //    }
            //    childForm.Close();

            //} 
            #endregion

        }

        private void Frm_Main_Activated(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
        }

        private void Frm_Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmBox.Show(this, PointToClient(MousePosition));
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dr = new DataTable();
            dr.Columns.Add("Password");
            dr.Rows.Add();
            Frm_Password frm = new Frm_Password(dr);
            frm.ShowDialog();

            if (dr.Rows[0][0].ToString() == "1223456")
            {
                openFileDialog1.Filter = "JPG|*.JPG";
                openFileDialog1.ShowDialog();
            }


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (this.openFileDialog1.FileName.Length > 0)
            {
                this.BackgroundImage = (System.Drawing.Image.FromFile(openFileDialog1.FileName, false));
            }
        }

        private void btn_Video_Click(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_WritePic frm = new Frm_WritePic();
            frm.MdiParent = staticMain.MainMDI;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
            frm.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.Show();
        }

        private void btn_Photo_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = staticMain.MainMDI;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;// Forms.
            frm.Dock = DockStyle.Fill;
            frm.TopMost = true;
            frm.Show();
        }
    }
}
