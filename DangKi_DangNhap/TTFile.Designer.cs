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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Cyan;
            label1.Location = new Point(75, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 48);
            label1.TabIndex = 0;
            label1.Text = "Thông tin file";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 101);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên file:";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(81, 96);
            label3.Name = "label3";
            label3.Size = new Size(333, 30);
            label3.TabIndex = 2;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 167);
            label4.Name = "label4";
            label4.Size = new Size(134, 25);
            label4.TabIndex = 3;
            label4.Text = "Tên người đăng:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(128, 162);
            label5.Name = "label5";
            label5.Size = new Size(277, 30);
            label5.TabIndex = 4;
            // 
            // label6
            // 
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 226);
            label6.Name = "label6";
            label6.Size = new Size(134, 25);
            label6.TabIndex = 5;
            label6.Text = "Ngày đăng:";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(107, 226);
            label7.Name = "label7";
            label7.Size = new Size(235, 30);
            label7.TabIndex = 6;
            // 
            // label8
            // 
            label8.ForeColor = Color.White;
            label8.Location = new Point(12, 290);
            label8.Name = "label8";
            label8.Size = new Size(134, 25);
            label8.TabIndex = 7;
            label8.Text = "Đường dẫn file:";
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(141, 288);
            label9.Name = "label9";
            label9.Size = new Size(273, 139);
            label9.TabIndex = 8;
            label9.Click += label9_Click;
            // 
            // TTFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(417, 436);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TTFile";
            Text = "TTFile";
            Load += TTFile_Load;
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
    }
}