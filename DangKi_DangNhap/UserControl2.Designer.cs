namespace DangKi_DangNhap
{
    partial class UserControl2
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
            lbDays = new Label();
            lbEvent = new Label();
            SuspendLayout();
            // 
            // lbDays
            // 
            lbDays.Location = new Point(17, 11);
            lbDays.Name = "lbDays";
            lbDays.Size = new Size(44, 25);
            lbDays.TabIndex = 0;
            lbDays.Text = "00";
            lbDays.Click += lbDays_Click;
            // 
            // lbEvent
            // 
            lbEvent.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEvent.ForeColor = Color.White;
            lbEvent.Location = new Point(51, 36);
            lbEvent.Name = "lbEvent";
            lbEvent.Size = new Size(96, 64);
            lbEvent.TabIndex = 1;
            lbEvent.Click += lbEvent_Click;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbEvent);
            Controls.Add(lbDays);
            Name = "UserControl2";
            Size = new Size(147, 90);
            Load += UserControl2_Load;
            Click += UserControl2_Click;
            ResumeLayout(false);
        }

        #endregion

        private Label lbDays;
        private Label lbEvent;
    }
}
