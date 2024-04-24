namespace DangKi_DangNhap
{
    partial class LapLich
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            button1 = new Button();
            button2 = new Button();
            lbDates = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 115);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1077, 532);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(781, 67);
            label6.Name = "label6";
            label6.Size = new Size(110, 45);
            label6.TabIndex = 2;
            label6.Text = "FRIDAY";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 67);
            label1.Name = "label1";
            label1.Size = new Size(110, 45);
            label1.TabIndex = 1;
            label1.Text = "SUNDAY";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(165, 67);
            label2.Name = "label2";
            label2.Size = new Size(115, 45);
            label2.TabIndex = 2;
            label2.Text = "MONDAY";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(318, 67);
            label3.Name = "label3";
            label3.Size = new Size(116, 45);
            label3.TabIndex = 3;
            label3.Text = "TUESDAY";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(461, 67);
            label4.Name = "label4";
            label4.Size = new Size(135, 45);
            label4.TabIndex = 4;
            label4.Text = "WENESDAY";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(622, 67);
            label5.Name = "label5";
            label5.Size = new Size(131, 45);
            label5.TabIndex = 5;
            label5.Text = "THURSDAY";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(897, 67);
            label7.Name = "label7";
            label7.Size = new Size(126, 45);
            label7.TabIndex = 2;
            label7.Text = "SATURDAY";
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(809, 662);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "previous";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Location = new Point(929, 662);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "next";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lbDates
            // 
            lbDates.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDates.Location = new Point(327, 9);
            lbDates.Name = "lbDates";
            lbDates.Size = new Size(392, 45);
            lbDates.TabIndex = 8;
            lbDates.Text = "Month Year";
            lbDates.TextAlign = ContentAlignment.MiddleCenter;
            lbDates.Click += lbDates_Click;
            // 
            // LapLich
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1083, 733);
            Controls.Add(lbDates);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Name = "LapLich";
            Text = "LapLich";
            Load += LapLich_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private Button button2;
        private Label lbDates;
    }
}