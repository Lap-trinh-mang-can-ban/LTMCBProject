namespace DangKi_DangNhap
{
    partial class TrangTaoNhom
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
            groupNameLabel = new Label();
            groupIdLabel = new Label();
            usernameLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            createGroupButton = new Button();
            SuspendLayout();
            // 
            // groupNameLabel
            // 
            groupNameLabel.AutoSize = true;
            groupNameLabel.Location = new Point(38, 38);
            groupNameLabel.Margin = new Padding(4, 0, 4, 0);
            groupNameLabel.Name = "groupNameLabel";
            groupNameLabel.Size = new Size(94, 25);
            groupNameLabel.TabIndex = 0;
            groupNameLabel.Text = "Tên nhóm:";
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new Point(38, 88);
            groupIdLabel.Margin = new Padding(4, 0, 4, 0);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new Size(34, 25);
            groupIdLabel.TabIndex = 1;
            groupIdLabel.Text = "ID:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(38, 138);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(95, 25);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 38);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(150, 88);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(249, 31);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(150, 138);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(249, 31);
            textBox3.TabIndex = 5;
            // 
            // createGroupButton
            // 
            createGroupButton.Location = new Point(150, 200);
            createGroupButton.Margin = new Padding(4);
            createGroupButton.Name = "createGroupButton";
            createGroupButton.Size = new Size(125, 38);
            createGroupButton.TabIndex = 6;
            createGroupButton.Text = "Tạo Nhóm";
            createGroupButton.UseVisualStyleBackColor = true;
            createGroupButton.Click += createGroupButton_Click;
            // 
            // TrangTaoNhom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 262);
            Controls.Add(createGroupButton);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(usernameLabel);
            Controls.Add(groupIdLabel);
            Controls.Add(groupNameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "TrangTaoNhom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Nhóm Mới";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.Label groupIdLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button createGroupButton;
    }
}