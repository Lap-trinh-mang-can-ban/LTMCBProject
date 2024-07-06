namespace DangKi_DangNhap
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbText = new Label();
            SuspendLayout();
            // 
            // lbText
            // 
            lbText.ForeColor = Color.White;
            lbText.Location = new Point(0, 34);
            lbText.Name = "lbText";
            lbText.Size = new Size(147, 54);
            lbText.TabIndex = 0;
            lbText.Click += label1_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lbText);
            Name = "UserControl1";
            Size = new Size(147, 88);
            Load += UserControl1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbText;
    }
}
