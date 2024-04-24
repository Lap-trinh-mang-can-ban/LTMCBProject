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
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            label1 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BackColor = Color.CornflowerBlue;
            label2.Location = new Point(1, -2);
            label2.Name = "label2";
            label2.Size = new Size(906, 90);
            label2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(627, -2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.BackColor = Color.CornflowerBlue;
            label3.Location = new Point(539, 1);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 3;
            label3.Text = "Tên nhóm:";
            // 
            // label4
            // 
            label4.BackColor = Color.CornflowerBlue;
            label4.Location = new Point(539, 33);
            label4.Name = "label4";
            label4.Size = new Size(82, 25);
            label4.TabIndex = 4;
            label4.Text = "ID nhóm:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(627, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Indigo;
            button1.ForeColor = Color.White;
            button1.Location = new Point(37, 12);
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
            button2.Location = new Point(172, 12);
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
            label5.Location = new Point(306, 44);
            label5.Name = "label5";
            label5.Size = new Size(206, 28);
            label5.TabIndex = 8;
            label5.Text = "Danh sách nhóm";
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            label1.Location = new Point(539, 58);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 9;
            label1.Text = "Username:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(627, 61);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 10;
            // 
            // TaoNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(801, 450);
            Controls.Add(textBox3);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "TaoNhom";
            Text = "TaoNhom";
            Load += TaoNhom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label5;
        private Label label1;
        private TextBox textBox3;
    }
}