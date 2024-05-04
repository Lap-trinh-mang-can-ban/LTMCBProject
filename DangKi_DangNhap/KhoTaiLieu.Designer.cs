namespace DangKi_DangNhap
{
    partial class KhoTaiLieu
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
            textBox1 = new TextBox();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 497);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(732, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(887, 545);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Đăng";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(37, 31);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(926, 373);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Location = new Point(435, 419);
            button2.Name = "button2";
            button2.Size = new Size(130, 29);
            button2.TabIndex = 4;
            button2.Text = "Mở file";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(37, 497);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 7;
            label2.Text = "Đường dẫn";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(131, 455);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(732, 27);
            textBox2.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(37, 455);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 6;
            label1.Text = "Tên file";
            // 
            // KhoTaiLieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(993, 589);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "KhoTaiLieu";
            Text = "KhoTaiLieu";
            Load += KhoTaiLieu_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button button1;
        private RichTextBox richTextBox1;
        private Button button2;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
    }
}