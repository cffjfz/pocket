namespace Main
{
    partial class FrmAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdd));
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnRfid = new System.Windows.Forms.Button();
            this.lvInfo = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 60;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数量";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类别";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 60;
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(63, 267);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(33, 20);
            this.lblCount.Text = "0";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(3, 25);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(172, 21);
            this.txtBarcode.TabIndex = 12;
            // 
            // txtRfid
            // 
            this.txtRfid.Location = new System.Drawing.Point(2, 52);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(172, 21);
            this.txtRfid.TabIndex = 11;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(181, 26);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(51, 20);
            this.btnBarcode.TabIndex = 10;
            this.btnBarcode.Text = "Scan";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click_1);
            // 
            // btnRfid
            // 
            this.btnRfid.Location = new System.Drawing.Point(180, 52);
            this.btnRfid.Name = "btnRfid";
            this.btnRfid.Size = new System.Drawing.Size(51, 20);
            this.btnRfid.TabIndex = 9;
            this.btnRfid.Text = "Start";
            this.btnRfid.Click += new System.EventHandler(this.btnRfid_Click_1);
            // 
            // lvInfo
            // 
            this.lvInfo.Columns.Add(this.columnHeader5);
            this.lvInfo.Columns.Add(this.columnHeader6);
            this.lvInfo.Columns.Add(this.columnHeader7);
            this.lvInfo.Columns.Add(this.columnHeader8);
            this.lvInfo.Location = new System.Drawing.Point(2, 26);
            this.lvInfo.Name = "lvInfo";
            this.lvInfo.Size = new System.Drawing.Size(236, 234);
            this.lvInfo.TabIndex = 8;
            this.lvInfo.View = System.Windows.Forms.View.Details;
            this.lvInfo.SelectedIndexChanged += new System.EventHandler(this.lvInfo_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "数量";
            this.columnHeader6.Width = 60;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "型号";
            this.columnHeader7.Width = 60;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "备注";
            this.columnHeader8.Width = 60;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(171, 266);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 20);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(101, 267);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 20);
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(240, 320);
            // 
            // FrmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.lvInfo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtRfid);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btnRfid);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmAdd";
            this.Text = "FrmAdd";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAdd_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtRfid;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnRfid;
        private System.Windows.Forms.ListView lvInfo;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;

    }
}