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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "窗口 " + childFormNumber++;
            //childForm.Show();
        }




        public void CloseAllForm()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        public void CloseAllForm(string strName)
        {
            foreach (Form childForm in MdiChildren)
            {
                if (childForm.Name == strName)
                {
                    childForm.Close();
                    break;
                }
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Frm_Main frm = new Frm_Main();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void MDIParent1_Activated(object sender, EventArgs e)
        {

        }

        private void MDIParent1_MdiChildActivate(object sender, EventArgs e)
        {
            //foreach (Form childForm in MdiChildren)
            //{
            //    if (childForm.Name != ((Form)sender).Name)
            //    {
            //        childForm.Close();
            //    }
            //}
        }
    }
}
