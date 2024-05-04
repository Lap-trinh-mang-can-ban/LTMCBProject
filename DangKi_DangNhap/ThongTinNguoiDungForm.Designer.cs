namespace DangKi_DangNhap
{
    partial class ThongTinNguoiDungForm
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.user_11775681;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(118, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 125);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 214);
            label1.Name = "label1";
            label1.Size = new Size(134, 28);
            label1.TabIndex = 1;
            label1.Text = "Tên người dùng:";
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(134, 214);
            label2.Name = "label2";
            label2.Size = new Size(201, 25);
            label2.TabIndex = 2;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 262);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 3;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.ForeColor = Color.White;
            label4.Location = new Point(90, 262);
            label4.Name = "label4";
            label4.Size = new Size(287, 25);
            label4.TabIndex = 4;
            label4.Click += label4_Click;
            // 
            // label6
            // 
            label6.ForeColor = Color.White;
            label6.Location = new Point(107, 322);
            label6.Name = "label6";
            label6.Size = new Size(152, 25);
            label6.TabIndex = 6;
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 322);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 5;
            label5.Text = "Ngày sinh:";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(12, 371);
            label7.Name = "label7";
            label7.Size = new Size(89, 25);
            label7.TabIndex = 7;
            label7.Text = "Giới tính:";
            // 
            // label8
            // 
            label8.ForeColor = Color.White;
            label8.Location = new Point(107, 371);
            label8.Name = "label8";
            label8.Size = new Size(152, 25);
            label8.TabIndex = 8;
            // 
            // ThongTinNguoiDungForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(389, 450);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "ThongTinNguoiDungForm";
            Text = "ThongTinNguoiDungForm";
            Load += ThongTinNguoiDungForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label7;
        private Label label8;
    }
}