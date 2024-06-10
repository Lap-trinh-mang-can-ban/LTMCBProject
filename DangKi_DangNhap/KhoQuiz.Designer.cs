namespace DangKi_DangNhap
{
    partial class KhoQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhoQuiz));
            bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            label1 = new Label();
            SuspendLayout();
            // 
            // bunifuPanel1
            // 
            bunifuPanel1.BackgroundColor = Color.OldLace;
            bunifuPanel1.BackgroundImage = (Image)resources.GetObject("bunifuPanel1.BackgroundImage");
            bunifuPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            bunifuPanel1.BorderColor = Color.Transparent;
            bunifuPanel1.BorderRadius = 80;
            bunifuPanel1.BorderThickness = 1;
            bunifuPanel1.Location = new Point(46, 92);
            bunifuPanel1.Name = "bunifuPanel1";
            bunifuPanel1.ShowBorders = true;
            bunifuPanel1.Size = new Size(761, 358);
            bunifuPanel1.TabIndex = 1;
            bunifuPanel1.Click += bunifuPanel1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(162, -1);
            label1.Name = "label1";
            label1.Size = new Size(505, 80);
            label1.TabIndex = 2;
            label1.Text = "Kho Quiz";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KhoQuiz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(853, 517);
            Controls.Add(label1);
            Controls.Add(bunifuPanel1);
            Name = "KhoQuiz";
            Text = "KhoQuiz";
            ResumeLayout(false);
        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Label label1;
    }
}