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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            createGroupButton = new Button();
            SuspendLayout();
            // 
            // groupNameLabel
            // 
            groupNameLabel.AutoSize = true;
            groupNameLabel.Location = new Point(30, 30);
            groupNameLabel.Name = "groupNameLabel";
            groupNameLabel.Size = new Size(77, 20);
            groupNameLabel.TabIndex = 0;
            groupNameLabel.Text = "Tên nhóm:";
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new Point(30, 70);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new Size(27, 20);
            groupIdLabel.TabIndex = 1;
            groupIdLabel.Text = "ID:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(120, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(120, 70);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 27);
            textBox2.TabIndex = 4;
            // 
            // createGroupButton
            // 
            createGroupButton.Location = new Point(120, 115);
            createGroupButton.Name = "createGroupButton";
            createGroupButton.Size = new Size(100, 32);
            createGroupButton.TabIndex = 6;
            createGroupButton.Text = "Tạo Nhóm";
            createGroupButton.UseVisualStyleBackColor = true;
            createGroupButton.Click += createGroupButton_Click;
            // 
            // TrangTaoNhom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 168);
            Controls.Add(createGroupButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(groupIdLabel);
            Controls.Add(groupNameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TrangTaoNhom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Nhóm Mới";
            Load += TrangTaoNhom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.Label groupIdLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button createGroupButton;
    }
}