namespace DangKi_DangNhap
{
    partial class TTFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTFile));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            bunifuPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(81, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 48);
            label1.TabIndex = 0;
            label1.Text = "Thông tin file";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên file:";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(85, 56);
            label3.Name = "label3";
            label3.Size = new Size(360, 30);
            label3.TabIndex = 2;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(5, 110);
            label4.Name = "label4";
            label4.Size = new Size(157, 30);
            label4.TabIndex = 3;
            label4.Text = "Tên người đăng:";
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(170, 110);
            label5.Name = "label5";
            label5.Size = new Size(205, 30);
            label5.TabIndex = 4;
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(5, 173);
            label6.Name = "label6";
            label6.Size = new Size(133, 35);
            label6.TabIndex = 5;
            label6.Text = "Ngày đăng:";
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(170, 173);
            label7.Name = "label7";
            label7.Size = new Size(205, 30);
            label7.TabIndex = 6;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(7, 234);
            label8.Name = "label8";
            label8.Size = new Size(157, 34);
            label8.TabIndex = 7;
            label8.Text = "Đường dẫn file:";
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(170, 234);
            label9.Name = "label9";
            label9.Size = new Size(273, 101);
            label9.TabIndex = 8;
            label9.Click += label9_Click;
            // 
            // bunifuPanel1
            // 
            bunifuPanel1.BackgroundColor = Color.OldLace;
            bunifuPanel1.BackgroundImage = (Image)resources.GetObject("bunifuPanel1.BackgroundImage");
            bunifuPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            bunifuPanel1.BorderColor = Color.Navy;
            bunifuPanel1.BorderRadius = 50;
            bunifuPanel1.BorderThickness = 2;
            bunifuPanel1.Controls.Add(label9);
            bunifuPanel1.Controls.Add(label2);
            bunifuPanel1.Controls.Add(label3);
            bunifuPanel1.Controls.Add(label5);
            bunifuPanel1.Controls.Add(label7);
            bunifuPanel1.Controls.Add(label8);
            bunifuPanel1.Controls.Add(label6);
            bunifuPanel1.Controls.Add(label4);
            bunifuPanel1.Location = new Point(18, 60);
            bunifuPanel1.Name = "bunifuPanel1";
            bunifuPanel1.ShowBorders = true;
            bunifuPanel1.Size = new Size(448, 373);
            bunifuPanel1.TabIndex = 19;
            // 
            // TTFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(473, 445);
            Controls.Add(label1);
            Controls.Add(bunifuPanel1);
            Name = "TTFile";
            Text = "TTFile";
            Load += TTFile_Load;
            bunifuPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
    }
}