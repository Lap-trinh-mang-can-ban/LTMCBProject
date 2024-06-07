namespace DangKi_DangNhap
{
    partial class Ds_Diem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ds_Diem));
            bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            listView1 = new ListView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            bunifuPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // bunifuPanel1
            // 
            bunifuPanel1.BackgroundColor = Color.SteelBlue;
            bunifuPanel1.BackgroundImage = (Image)resources.GetObject("bunifuPanel1.BackgroundImage");
            bunifuPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            bunifuPanel1.BorderColor = Color.MidnightBlue;
            bunifuPanel1.BorderRadius = 30;
            bunifuPanel1.BorderThickness = 2;
            bunifuPanel1.Controls.Add(listView1);
            bunifuPanel1.Controls.Add(label1);
            bunifuPanel1.Location = new Point(31, 26);
            bunifuPanel1.Name = "bunifuPanel1";
            bunifuPanel1.ShowBorders = true;
            bunifuPanel1.Size = new Size(771, 488);
            bunifuPanel1.TabIndex = 17;
            // 
            // listView1
            // 
            listView1.Location = new Point(43, 74);
            listView1.Name = "listView1";
            listView1.Size = new Size(710, 382);
            listView1.TabIndex = 11;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(272, 21);
            label1.Name = "label1";
            label1.Size = new Size(253, 33);
            label1.TabIndex = 10;
            label1.Text = "Lịch sử bài làm:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(515, 536);
            label2.Name = "label2";
            label2.Size = new Size(130, 35);
            label2.TabIndex = 18;
            label2.Text = "Điểm trung bình:";
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(651, 533);
            label3.Name = "label3";
            label3.Size = new Size(98, 53);
            label3.TabIndex = 19;
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 540);
            label4.Name = "label4";
            label4.Size = new Size(122, 35);
            label4.TabIndex = 20;
            label4.Text = "Tên thành viên:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkBlue;
            label5.Location = new Point(150, 529);
            label5.Name = "label5";
            label5.Size = new Size(210, 42);
            label5.TabIndex = 21;
            // 
            // Ds_Diem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(820, 610);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(bunifuPanel1);
            ForeColor = Color.Black;
            Name = "Ds_Diem";
            Text = "Ds_Diem";
            Load += Ds_Diem_Load;
            bunifuPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView listView1;
        private Label label4;
        private Label label5;
    }
}