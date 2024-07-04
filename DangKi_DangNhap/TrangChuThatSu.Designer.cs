namespace DangKi_DangNhap
{
    partial class TrangChuThatSu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkLabel1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChuThatSu));
            lblTitle = new Label();
            linkLabel1 = new LinkLabel();
            bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            tbDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)bunifuPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(3, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1065, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // linkLabel1
            // 
            linkLabel1.Location = new Point(11, 113);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(102, 31);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = " Xem chi tiết";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // bunifuPictureBox1
            // 
            bunifuPictureBox1.AllowFocused = false;
            bunifuPictureBox1.Anchor = AnchorStyles.None;
            bunifuPictureBox1.AutoSizeHeight = true;
            bunifuPictureBox1.BackColor = Color.Transparent;
            bunifuPictureBox1.BorderRadius = 0;
            bunifuPictureBox1.Image = (Image)resources.GetObject("bunifuPictureBox1.Image");
            bunifuPictureBox1.InitialImage = (Image)resources.GetObject("bunifuPictureBox1.InitialImage");
            bunifuPictureBox1.IsCircle = false;
            bunifuPictureBox1.Location = new Point(142, -10);
            bunifuPictureBox1.Name = "bunifuPictureBox1";
            bunifuPictureBox1.Size = new Size(762, 762);
            bunifuPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            bunifuPictureBox1.TabIndex = 3;
            bunifuPictureBox1.TabStop = false;
            bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            bunifuPictureBox1.WaitOnLoad = true;
            // 
            // timer1
            // 
            timer1.Interval = 50000;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 84);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 4;
            label1.Text = "Đường dẫn :";
            // 
            // label2
            // 
            label2.BackColor = Color.BlanchedAlmond;
            label2.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(492, 41);
            label2.TabIndex = 5;
            label2.Text = "Bảng tin Giáo dục VnExpress ";
            // 
            // tbDescription
            // 
            tbDescription.BorderStyle = BorderStyle.None;
            tbDescription.Location = new Point(108, 84);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(960, 20);
            tbDescription.TabIndex = 6;
            tbDescription.Text = "Description";
            // 
            // TrangChuThatSu
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 628);
            Controls.Add(tbDescription);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(lblTitle);
            Controls.Add(bunifuPictureBox1);
            Name = "TrangChuThatSu";
            Text = "TrangChuThatSu";
            Load += TrangChuThatSu_Load;
            ((System.ComponentModel.ISupportInitialize)bunifuPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        protected internal System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
        private TextBox tbDescription;
    }
}