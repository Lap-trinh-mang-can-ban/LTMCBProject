namespace DangKi_DangNhap
{
    partial class TaoNhom
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
            button2 = new Button();
            label5 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.ForeColor = Color.White;
            button1.Location = new Point(35, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Tạo nhóm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Indigo;
            button2.ForeColor = Color.White;
            button2.Location = new Point(35, 47);
            button2.Name = "button2";
            button2.Size = new Size(137, 29);
            button2.TabIndex = 7;
            button2.Text = "Tham gia nhóm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.CornflowerBlue;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(339, 66);
            label5.Name = "label5";
            label5.Size = new Size(206, 28);
            label5.TabIndex = 8;
            label5.Text = "Danh sách nhóm";
            // 
            // label2
            // 
            label2.BackColor = Color.CornflowerBlue;
            label2.Location = new Point(12, -7);
            label2.Name = "label2";
            label2.Size = new Size(906, 115);
            label2.TabIndex = 1;
            label2.Click += label2_Click;
            // 
            // TaoNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(905, 450);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "TaoNhom";
            Text = "TaoNhom";
            Load += TaoNhom_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Label label5;
        private Label label2;
    }
}