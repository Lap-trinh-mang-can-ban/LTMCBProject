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
            saveFileDialog1 = new SaveFileDialog();
            button3 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(-5, 0);
            listView1.Margin = new Padding(4);
            listView1.Name = "listView1";
            listView1.Size = new Size(605, 212);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Location = new Point(-1, 208);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 720);
            panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(630, 39);
            richTextBox1.Margin = new Padding(0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(715, 756);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            //richTextBox1.TextChanged += richTextBox1_TextChanged;

            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(928, 890);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(134, 36);
            button1.TabIndex = 3;
            button1.Text = "Đăng";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(633, 814);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(715, 31);
            textBox1.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Location = new Point(1240, 862);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(108, 36);
            button2.TabIndex = 6;
            button2.Text = "Chọn file ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.BackColor = Color.White;
            linkLabel1.Location = new Point(652, 681);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(694, 74);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "File môn học";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.AutoSize = true;
            button3.BackColor = Color.SlateBlue;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.AppWorkspace;
            button3.Location = new Point(617, 0);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(116, 40);
            button3.TabIndex = 8;
            button3.Text = "Rời nhóm";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FormNhom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(1380, 939);
            Controls.Add(button3);
            Controls.Add(linkLabel1);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(listView1);
            Margin = new Padding(4);
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
        private SaveFileDialog saveFileDialog1;
        private Button button3;
    }
}