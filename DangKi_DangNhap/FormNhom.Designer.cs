namespace DangKi_DangNhap
{
    partial class FormNhom
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
            listView1 = new ListView();
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(-4, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(485, 170);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Location = new Point(-1, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 576);
            panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(504, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(573, 606);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(742, 699);
            button1.Name = "button1";
            button1.Size = new Size(107, 29);
            button1.TabIndex = 3;
            button1.Text = "Đăng";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(504, 635);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(573, 27);
            textBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Location = new Point(991, 668);
            button2.Name = "button2";
            button2.Size = new Size(86, 29);
            button2.TabIndex = 6;
            button2.Text = "Chọn file ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor = Color.White;
            linkLabel1.Location = new Point(522, 545);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(555, 59);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "File môn học";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FormNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(1089, 740);
            Controls.Add(linkLabel1);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(listView1);
            Name = "FormNhom";
            Text = "FormNhom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public ListView listView1;
        private Panel panel1;
        public Button button1;
        private TextBox textBox1;
        public RichTextBox richTextBox1;
        private Button button2;
        private LinkLabel linkLabel1;
    }
}