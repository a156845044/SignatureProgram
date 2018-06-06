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
    public partial class Frm_Password : Form
    {

        DataTable dr;
        public Frm_Password(DataTable drInput)
        {
            InitializeComponent();
            dr= drInput;
        }


        private void Frm_Main_Load(object sender, EventArgs e)
        {
            //Point p = new Point( (this.Size.Width - this.pan_Menus.Width) / 2, (this.Size.Height-this.pan_Menus.Size.Height)/2);
            //this.pan_Menus.Location = p;
        }






        private void button3_Click(object sender, EventArgs e)
        {
            dr.Rows[0][0] = this.textBox1.Text.Trim();
            this.Close();
        }
    }
}
