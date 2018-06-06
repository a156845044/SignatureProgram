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
    public partial class Frm_Print : Form
    {
        string  strimage;
        public Frm_Print(string strimageInput)
        {
            InitializeComponent();
            strimage = strimageInput;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.pictureBox1.BackgroundImage = (System.Drawing.Image.FromFile(strimage, false));
            //Point p = new Point( (this.Size.Width - this.pan_Menus.Width) / 2, (this.Size.Height-this.pan_Menus.Size.Height)/2);
            //this.pan_Menus.Location = p;
        }




        private void btn_Write_Click(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_Main frm = new Frm_Main();
            frm.MdiParent = staticMain.MainMDI;
            frm.Dock = DockStyle.Fill;
            frm.Show();


            //if (this.MdiParent.MdiChildren.Contains(frm) == true)
            //{
            //    frm.Show();
            //}
            //else
            //{
  
            //}

            //foreach (Form childForm in this.MdiParent.MdiChildren)
            //{

            //    childForm.Close();

            //}

           
            //Frm_Main frm = new Frm_Main();
            //frm.MdiParent = this.MdiParent;
            //frm.ShowDialog();
            //this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //staticMain.MainMDI.CloseAllForm();

            Frm_WriteName frm = new Frm_WriteName();
            frm.MdiParent = staticMain.MainMDI;
            //frm.Dock = DockStyle.Top ;
            frm.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
