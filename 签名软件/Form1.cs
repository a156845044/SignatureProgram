using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3DWall;
//using _3DTools;
//using _3DWall;
using System.Windows;

namespace 签名软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.WindowState = FormWindowState.Maximized;

            _3DWall.WallUserControl Wall = new _3DWall.WallUserControl();
            
            Rectangle ret = Screen.GetWorkingArea(this);

            this.elementHost1.ClientSize = new System.Drawing.Size(ret.Width, ret.Height);
            this.elementHost1.Dock = DockStyle.Fill;
            this.elementHost1.BringToFront();

            elementHost1.Child = Wall;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            staticMain.MainMDI.CloseAllForm();
            Frm_Main frm = new Frm_Main();
            frm.MdiParent = staticMain.MainMDI;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

    }
}
