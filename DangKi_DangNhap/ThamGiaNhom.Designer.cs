namespace DangKi_DangNhap
{
    partial class ThamGiaNhom
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
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(47, 126);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên nhóm";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(47, 231);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 1;
            label2.Text = "ID nhóm";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(200, 231);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(203, 27);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(181, 9);
            label3.Name = "label3";
            label3.Size = new Size(186, 34);
            label3.TabIndex = 4;
            label3.Text = "Tham gia nhóm";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(422, 68);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "Tìm kiếm ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(47, 70);
            label4.Name = "label4";
            label4.Size = new Size(137, 25);
            label4.TabIndex = 6;
            label4.Text = "Tên người dùng";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(200, 125);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(203, 28);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(227, 293);
            button2.Name = "button2";
            button2.Size = new Size(124, 29);
            button2.TabIndex = 9;
            button2.Text = "Tham gia nhóm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(200, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(203, 27);
            textBox1.TabIndex = 12;
            // 
            // ThamGiaNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(553, 334);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ThamGiaNhom";
            Text = "ThamGiaNhom";
            Load += ThamGiaNhom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Label label4;
        private ComboBox comboBox1;
        private Button button2;
        private TextBox textBox1;
    }
}