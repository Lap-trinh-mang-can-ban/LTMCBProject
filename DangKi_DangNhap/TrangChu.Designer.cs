namespace DangKi_DangNhap
{
    partial class TrangChu
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
            button1 = new Button();
            panel1 = new Panel();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(686, 13);
            button1.Name = "button1";
            button1.Size = new Size(114, 30);
            button1.TabIndex = 1;
            button1.Text = "Đăng xuất ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InfoText;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(1, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(171, 409);
            panel1.TabIndex = 2;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkViolet;
            button5.Location = new Point(-10, 227);
            button5.Name = "button5";
            button5.Size = new Size(192, 78);
            button5.TabIndex = 10;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.AnhTingTing;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.AnhTingTing1;
            pictureBox1.Location = new Point(298, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(324, 247);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Firebrick;
            button4.Location = new Point(-10, 152);
            button4.Name = "button4";
            button4.Size = new Size(192, 84);
            button4.TabIndex = 8;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Olive;
            button3.Location = new Point(-21, 71);
            button3.Name = "button3";
            button3.Size = new Size(203, 85);
            button3.TabIndex = 7;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Teal;
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(-21, 3);
            button2.Name = "button2";
            button2.Size = new Size(203, 83);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CadetBlue;
            panel2.Controls.Add(button1);
            panel2.Location = new Point(170, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(811, 91);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkGreen;
            panel3.Location = new Point(1, -1);
            panel3.Name = "panel3";
            panel3.Size = new Size(171, 91);
            panel3.TabIndex = 5;
            // 
            // TrangChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 544);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TrangChu";
            Text = "TrangChu";
            Load += TrangChu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button button2;
        private Button button4;
        private Button button3;
        private PictureBox pictureBox1;
        private Button button5;
    }
}