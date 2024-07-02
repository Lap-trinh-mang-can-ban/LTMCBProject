namespace DangKi_DangNhap
{
    partial class UserControl3
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
            lbEvent = new Label();
            lbDays = new Label();
            SuspendLayout();
            // 
            // lbEvent
            // 
            lbEvent.Location = new Point(58, 43);
            lbEvent.Name = "lbEvent";
            lbEvent.Size = new Size(87, 50);
            lbEvent.TabIndex = 0;
            lbEvent.Click += UserControl3_Click;
            // 
            // lbDays
            // 
            lbDays.Location = new Point(3, 0);
            lbDays.Name = "lbDays";
            lbDays.Size = new Size(42, 33);
            lbDays.TabIndex = 1;
            // 
            // UserControl3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbDays);
            Controls.Add(lbEvent);
            Name = "UserControl3";
            Size = new Size(145, 97);
            ResumeLayout(false);
            Load += UserControl3_Load;
            Click += UserControl3_Click;
        }

        #endregion

        private Label lbEvent;
        private Label lbDays;
    }
}
