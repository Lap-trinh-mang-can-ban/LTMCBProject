namespace DangKi_DangNhap
{
    partial class ThongBao
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            vScrollBar1 = new VScrollBar();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 9);
            label1.Name = "label1";
            label1.Size = new Size(200, 53);
            label1.TabIndex = 0;
            label1.Text = "Thông báo";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(label8);
            flowLayoutPanel1.Location = new Point(21, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(767, 383);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.Indigo;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(764, 93);
            label2.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = Color.Indigo;
            label3.Location = new Point(3, 93);
            label3.Name = "label3";
            label3.Size = new Size(764, 93);
            label3.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.Indigo;
            label4.Location = new Point(3, 186);
            label4.Name = "label4";
            label4.Size = new Size(764, 93);
            label4.TabIndex = 2;
            // 
            // label5
            // 
            label5.BackColor = Color.Indigo;
            label5.Location = new Point(3, 279);
            label5.Name = "label5";
            label5.Size = new Size(764, 95);
            label5.TabIndex = 3;
            // 
            // label6
            // 
            label6.BackColor = Color.Indigo;
            label6.Location = new Point(3, 374);
            label6.Name = "label6";
            label6.Size = new Size(764, 95);
            label6.TabIndex = 4;
            // 
            // label7
            // 
            label7.BackColor = Color.Indigo;
            label7.Location = new Point(3, 469);
            label7.Name = "label7";
            label7.Size = new Size(764, 95);
            label7.TabIndex = 5;
            // 
            // label8
            // 
            label8.BackColor = Color.Indigo;
            label8.Location = new Point(3, 564);
            label8.Name = "label8";
            label8.Size = new Size(764, 95);
            label8.TabIndex = 6;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(791, 67);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(26, 479);
            vScrollBar1.TabIndex = 7;
            vScrollBar1.Scroll += vScrollBar1_Scroll_1;
            // 
            // ThongBao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(840, 572);
            Controls.Add(vScrollBar1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Name = "ThongBao";
            Text = "ThongBao";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private VScrollBar vScrollBar1;
    }
}