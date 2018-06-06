namespace 签名软件
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Photo = new System.Windows.Forms.Button();
            this.btn_Video = new System.Windows.Forms.Button();
            this.btn_Write = new System.Windows.Forms.Button();
            this.cmBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(806, 12);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.button1.Size = new System.Drawing.Size(39, 31);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Photo
            // 
            this.btn_Photo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Photo.BackColor = System.Drawing.Color.Transparent;
            this.btn_Photo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Photo.BackgroundImage")));
            this.btn_Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Photo.FlatAppearance.BorderSize = 0;
            this.btn_Photo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Photo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Photo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Photo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Photo.Location = new System.Drawing.Point(300, 324);
            this.btn_Photo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Photo.Name = "btn_Photo";
            this.btn_Photo.Size = new System.Drawing.Size(300, 92);
            this.btn_Photo.TabIndex = 1;
            this.btn_Photo.UseVisualStyleBackColor = false;
            this.btn_Photo.Click += new System.EventHandler(this.btn_Photo_Click);
            // 
            // btn_Video
            // 
            this.btn_Video.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Video.BackColor = System.Drawing.Color.Transparent;
            this.btn_Video.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Video.BackgroundImage")));
            this.btn_Video.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Video.FlatAppearance.BorderSize = 0;
            this.btn_Video.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Video.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Video.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Video.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Video.Location = new System.Drawing.Point(291, 219);
            this.btn_Video.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Video.Name = "btn_Video";
            this.btn_Video.Size = new System.Drawing.Size(317, 99);
            this.btn_Video.TabIndex = 1;
            this.btn_Video.UseVisualStyleBackColor = false;
            this.btn_Video.Click += new System.EventHandler(this.btn_Video_Click);
            // 
            // btn_Write
            // 
            this.btn_Write.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Write.BackColor = System.Drawing.Color.Transparent;
            this.btn_Write.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Write.BackgroundImage")));
            this.btn_Write.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Write.FlatAppearance.BorderSize = 0;
            this.btn_Write.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Write.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Write.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Write.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Write.Location = new System.Drawing.Point(300, 115);
            this.btn_Write.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(300, 92);
            this.btn_Write.TabIndex = 1;
            this.btn_Write.UseVisualStyleBackColor = false;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // cmBox
            // 
            this.cmBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem});
            this.cmBox.Name = "cmBox";
            this.cmBox.Size = new System.Drawing.Size(125, 26);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改ToolStripMenuItem.Text = "背景图片";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(867, 492);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Photo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Video);
            this.Controls.Add(this.btn_Write);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Frm_Main_Activated);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Frm_Main_MouseClick);
            this.cmBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Photo;
        private System.Windows.Forms.Button btn_Video;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.ContextMenuStrip cmBox;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

