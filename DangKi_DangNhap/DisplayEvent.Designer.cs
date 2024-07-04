namespace DangKi_DangNhap
{
    partial class DisplayEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayEvent));
            bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            bunifuPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // bunifuPanel1
            // 
            bunifuPanel1.BackgroundColor = Color.OldLace;
            bunifuPanel1.BackgroundImage = (Image)resources.GetObject("bunifuPanel1.BackgroundImage");
            bunifuPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            bunifuPanel1.BorderColor = Color.Navy;
            bunifuPanel1.BorderRadius = 50;
            bunifuPanel1.BorderThickness = 2;
            bunifuPanel1.Controls.Add(label2);
            bunifuPanel1.Controls.Add(label3);
            bunifuPanel1.Controls.Add(label5);
            bunifuPanel1.Controls.Add(label7);
            bunifuPanel1.Controls.Add(label6);
            bunifuPanel1.Location = new Point(23, 79);
            bunifuPanel1.Name = "bunifuPanel1";
            bunifuPanel1.ShowBorders = true;
            bunifuPanel1.Size = new Size(577, 424);
            bunifuPanel1.TabIndex = 20;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(107, 30);
            label2.TabIndex = 1;
            label2.Text = "Ngày:";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(85, 56);
            label3.Name = "label3";
            label3.Size = new Size(383, 40);
            label3.TabIndex = 2;
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(170, 110);
            label5.Name = "label5";
            label5.Size = new Size(354, 46);
            label5.TabIndex = 4;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Navy;
            label7.Location = new Point(147, 138);
            label7.Name = "label7";
            label7.Size = new Size(411, 268);
            label7.TabIndex = 6;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(3, 138);
            label6.Name = "label6";
            label6.Size = new Size(159, 35);
            label6.TabIndex = 5;
            label6.Text = "Chi tiết sự kiện:";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(142, 17);
            label1.Name = "label1";
            label1.Size = new Size(329, 59);
            label1.TabIndex = 21;
            label1.Text = "Sự kiện nhóm";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DisplayEvent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(628, 535);
            Controls.Add(label1);
            Controls.Add(bunifuPanel1);
            Name = "DisplayEvent";
            Text = "DisplayEvent";
            Load += DisplayEvent_Load;
            bunifuPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label6;
        private Label label1;
    }
}