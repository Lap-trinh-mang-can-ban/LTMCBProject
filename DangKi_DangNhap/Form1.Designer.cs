﻿namespace DangKi_DangNhap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            ShowPasswordButton = new Button();
            errorLabel = new Label();
            bunifuButton22 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            bunifuButton21 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            bunifuButton23 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            bunifuPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(185, 328);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 53);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(185, 400);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(298, 53);
            textBox2.TabIndex = 2;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.SteelBlue;
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.DeepSkyBlue;
            linkLabel1.Location = new Point(227, 654);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(85, 28);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Đăng kí";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.ActiveLinkColor = Color.SteelBlue;
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel2.ForeColor = Color.WhiteSmoke;
            linkLabel2.LinkColor = Color.DeepSkyBlue;
            linkLabel2.Location = new Point(190, 602);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(159, 28);
            linkLabel2.TabIndex = 6;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Quên mật khẩu ?";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.OldLace;
            pictureBox2.BackgroundImage = Properties.Resources.AnhDoAn_NT106;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(111, 91);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(316, 206);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(51, 20);
            label4.Name = "label4";
            label4.Size = new Size(445, 43);
            label4.TabIndex = 9;
            label4.Text = "Ứng dụng quản lý học nhóm ";
            // 
            // bunifuPanel1
            // 
            bunifuPanel1.BackgroundColor = Color.OldLace;
            bunifuPanel1.BackgroundImage = (Image)resources.GetObject("bunifuPanel1.BackgroundImage");
            bunifuPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            bunifuPanel1.BorderColor = Color.Navy;
            bunifuPanel1.BorderRadius = 50;
            bunifuPanel1.BorderThickness = 2;
            bunifuPanel1.Controls.Add(ShowPasswordButton);
            bunifuPanel1.Controls.Add(errorLabel);
            bunifuPanel1.Controls.Add(bunifuButton22);
            bunifuPanel1.Controls.Add(bunifuButton21);
            bunifuPanel1.Controls.Add(bunifuButton23);
            bunifuPanel1.Controls.Add(linkLabel1);
            bunifuPanel1.Controls.Add(linkLabel2);
            bunifuPanel1.Controls.Add(pictureBox2);
            bunifuPanel1.Controls.Add(label4);
            bunifuPanel1.Controls.Add(textBox1);
            bunifuPanel1.Controls.Add(textBox2);
            bunifuPanel1.Location = new Point(360, 10);
            bunifuPanel1.Name = "bunifuPanel1";
            bunifuPanel1.ShowBorders = true;
            bunifuPanel1.Size = new Size(526, 722);
            bunifuPanel1.TabIndex = 10;
            // 
            // ShowPasswordButton
            // 
            ShowPasswordButton.Image = (Image)resources.GetObject("ShowPasswordButton.Image");
            ShowPasswordButton.ImageAlign = ContentAlignment.TopLeft;
            ShowPasswordButton.Location = new Point(427, 405);
            ShowPasswordButton.Name = "ShowPasswordButton";
            ShowPasswordButton.Size = new Size(50, 44);
            ShowPasswordButton.TabIndex = 20;
            ShowPasswordButton.UseVisualStyleBackColor = true;
            ShowPasswordButton.UseWaitCursor = true;
            ShowPasswordButton.Click += ShowPasswordButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.BackColor = Color.Transparent;
            errorLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(185, 468);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(323, 29);
            errorLabel.TabIndex = 19;
            errorLabel.Text = "errorLabel";
            errorLabel.Click += errorLabel_Click;
            // 
            // bunifuButton22
            // 
            bunifuButton22.AllowAnimations = true;
            bunifuButton22.AllowMouseEffects = true;
            bunifuButton22.AllowToggling = false;
            bunifuButton22.AnimationSpeed = 200;
            bunifuButton22.AutoGenerateColors = false;
            bunifuButton22.AutoRoundBorders = false;
            bunifuButton22.AutoSizeLeftIcon = true;
            bunifuButton22.AutoSizeRightIcon = true;
            bunifuButton22.BackColor = Color.Transparent;
            bunifuButton22.BackColor1 = Color.Transparent;
            bunifuButton22.BackgroundImage = (Image)resources.GetObject("bunifuButton22.BackgroundImage");
            bunifuButton22.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton22.ButtonText = "Mật khẩu";
            bunifuButton22.ButtonTextMarginLeft = 0;
            bunifuButton22.ColorContrastOnClick = 45;
            bunifuButton22.ColorContrastOnHover = 45;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            bunifuButton22.CustomizableEdges = borderEdges1;
            bunifuButton22.DialogResult = DialogResult.None;
            bunifuButton22.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton22.DisabledFillColor = Color.FromArgb(204, 204, 204);
            bunifuButton22.DisabledForecolor = Color.FromArgb(168, 160, 168);
            bunifuButton22.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            bunifuButton22.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bunifuButton22.ForeColor = Color.Black;
            bunifuButton22.IconLeftAlign = ContentAlignment.MiddleLeft;
            bunifuButton22.IconLeftCursor = Cursors.Default;
            bunifuButton22.IconLeftPadding = new Padding(11, 3, 3, 3);
            bunifuButton22.IconMarginLeft = 11;
            bunifuButton22.IconPadding = 10;
            bunifuButton22.IconRightAlign = ContentAlignment.MiddleRight;
            bunifuButton22.IconRightCursor = Cursors.Default;
            bunifuButton22.IconRightPadding = new Padding(3, 3, 7, 3);
            bunifuButton22.IconSize = 25;
            bunifuButton22.IdleBorderColor = Color.DodgerBlue;
            bunifuButton22.IdleBorderRadius = 25;
            bunifuButton22.IdleBorderThickness = 1;
            bunifuButton22.IdleFillColor = Color.Transparent;
            bunifuButton22.IdleIconLeftImage = null;
            bunifuButton22.IdleIconRightImage = null;
            bunifuButton22.IndicateFocus = false;
            bunifuButton22.Location = new Point(27, 400);
            bunifuButton22.Name = "bunifuButton22";
            bunifuButton22.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton22.OnDisabledState.BorderRadius = 25;
            bunifuButton22.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton22.OnDisabledState.BorderThickness = 1;
            bunifuButton22.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            bunifuButton22.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            bunifuButton22.OnDisabledState.IconLeftImage = null;
            bunifuButton22.OnDisabledState.IconRightImage = null;
            bunifuButton22.onHoverState.BorderColor = Color.DodgerBlue;
            bunifuButton22.onHoverState.BorderRadius = 25;
            bunifuButton22.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton22.onHoverState.BorderThickness = 1;
            bunifuButton22.onHoverState.FillColor = Color.OldLace;
            bunifuButton22.onHoverState.ForeColor = Color.Black;
            bunifuButton22.onHoverState.IconLeftImage = null;
            bunifuButton22.onHoverState.IconRightImage = null;
            bunifuButton22.OnIdleState.BorderColor = Color.DodgerBlue;
            bunifuButton22.OnIdleState.BorderRadius = 25;
            bunifuButton22.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton22.OnIdleState.BorderThickness = 1;
            bunifuButton22.OnIdleState.FillColor = Color.Transparent;
            bunifuButton22.OnIdleState.ForeColor = Color.Black;
            bunifuButton22.OnIdleState.IconLeftImage = null;
            bunifuButton22.OnIdleState.IconRightImage = null;
            bunifuButton22.OnPressedState.BorderColor = Color.DodgerBlue;
            bunifuButton22.OnPressedState.BorderRadius = 25;
            bunifuButton22.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton22.OnPressedState.BorderThickness = 1;
            bunifuButton22.OnPressedState.FillColor = Color.OldLace;
            bunifuButton22.OnPressedState.ForeColor = Color.Black;
            bunifuButton22.OnPressedState.IconLeftImage = null;
            bunifuButton22.OnPressedState.IconRightImage = null;
            bunifuButton22.Size = new Size(139, 49);
            bunifuButton22.TabIndex = 18;
            bunifuButton22.TextAlign = ContentAlignment.MiddleCenter;
            bunifuButton22.TextAlignment = HorizontalAlignment.Center;
            bunifuButton22.TextMarginLeft = 0;
            bunifuButton22.TextPadding = new Padding(0);
            bunifuButton22.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuButton21
            // 
            bunifuButton21.AllowAnimations = true;
            bunifuButton21.AllowMouseEffects = true;
            bunifuButton21.AllowToggling = false;
            bunifuButton21.AnimationSpeed = 200;
            bunifuButton21.AutoGenerateColors = false;
            bunifuButton21.AutoRoundBorders = false;
            bunifuButton21.AutoSizeLeftIcon = true;
            bunifuButton21.AutoSizeRightIcon = true;
            bunifuButton21.BackColor = Color.Transparent;
            bunifuButton21.BackColor1 = Color.Transparent;
            bunifuButton21.BackgroundImage = (Image)resources.GetObject("bunifuButton21.BackgroundImage");
            bunifuButton21.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton21.ButtonText = "Tài khoản";
            bunifuButton21.ButtonTextMarginLeft = 0;
            bunifuButton21.ColorContrastOnClick = 45;
            bunifuButton21.ColorContrastOnHover = 45;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            bunifuButton21.CustomizableEdges = borderEdges2;
            bunifuButton21.DialogResult = DialogResult.None;
            bunifuButton21.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton21.DisabledFillColor = Color.FromArgb(204, 204, 204);
            bunifuButton21.DisabledForecolor = Color.FromArgb(168, 160, 168);
            bunifuButton21.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            bunifuButton21.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bunifuButton21.ForeColor = Color.Black;
            bunifuButton21.IconLeftAlign = ContentAlignment.MiddleLeft;
            bunifuButton21.IconLeftCursor = Cursors.Default;
            bunifuButton21.IconLeftPadding = new Padding(11, 3, 3, 3);
            bunifuButton21.IconMarginLeft = 11;
            bunifuButton21.IconPadding = 10;
            bunifuButton21.IconRightAlign = ContentAlignment.MiddleRight;
            bunifuButton21.IconRightCursor = Cursors.Default;
            bunifuButton21.IconRightPadding = new Padding(3, 3, 7, 3);
            bunifuButton21.IconSize = 25;
            bunifuButton21.IdleBorderColor = Color.DodgerBlue;
            bunifuButton21.IdleBorderRadius = 25;
            bunifuButton21.IdleBorderThickness = 1;
            bunifuButton21.IdleFillColor = Color.Transparent;
            bunifuButton21.IdleIconLeftImage = null;
            bunifuButton21.IdleIconRightImage = null;
            bunifuButton21.IndicateFocus = false;
            bunifuButton21.Location = new Point(29, 332);
            bunifuButton21.Name = "bunifuButton21";
            bunifuButton21.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton21.OnDisabledState.BorderRadius = 25;
            bunifuButton21.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton21.OnDisabledState.BorderThickness = 1;
            bunifuButton21.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            bunifuButton21.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            bunifuButton21.OnDisabledState.IconLeftImage = null;
            bunifuButton21.OnDisabledState.IconRightImage = null;
            bunifuButton21.onHoverState.BorderColor = Color.DodgerBlue;
            bunifuButton21.onHoverState.BorderRadius = 25;
            bunifuButton21.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton21.onHoverState.BorderThickness = 1;
            bunifuButton21.onHoverState.FillColor = Color.OldLace;
            bunifuButton21.onHoverState.ForeColor = Color.Black;
            bunifuButton21.onHoverState.IconLeftImage = null;
            bunifuButton21.onHoverState.IconRightImage = null;
            bunifuButton21.OnIdleState.BorderColor = Color.DodgerBlue;
            bunifuButton21.OnIdleState.BorderRadius = 25;
            bunifuButton21.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton21.OnIdleState.BorderThickness = 1;
            bunifuButton21.OnIdleState.FillColor = Color.Transparent;
            bunifuButton21.OnIdleState.ForeColor = Color.Black;
            bunifuButton21.OnIdleState.IconLeftImage = null;
            bunifuButton21.OnIdleState.IconRightImage = null;
            bunifuButton21.OnPressedState.BorderColor = Color.DodgerBlue;
            bunifuButton21.OnPressedState.BorderRadius = 25;
            bunifuButton21.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton21.OnPressedState.BorderThickness = 1;
            bunifuButton21.OnPressedState.FillColor = Color.OldLace;
            bunifuButton21.OnPressedState.ForeColor = Color.Black;
            bunifuButton21.OnPressedState.IconLeftImage = null;
            bunifuButton21.OnPressedState.IconRightImage = null;
            bunifuButton21.Size = new Size(137, 49);
            bunifuButton21.TabIndex = 17;
            bunifuButton21.TextAlign = ContentAlignment.MiddleCenter;
            bunifuButton21.TextAlignment = HorizontalAlignment.Center;
            bunifuButton21.TextMarginLeft = 0;
            bunifuButton21.TextPadding = new Padding(0);
            bunifuButton21.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuButton23
            // 
            bunifuButton23.AllowAnimations = true;
            bunifuButton23.AllowMouseEffects = true;
            bunifuButton23.AllowToggling = false;
            bunifuButton23.AnimationSpeed = 200;
            bunifuButton23.AutoGenerateColors = false;
            bunifuButton23.AutoRoundBorders = false;
            bunifuButton23.AutoSizeLeftIcon = true;
            bunifuButton23.AutoSizeRightIcon = true;
            bunifuButton23.BackColor = Color.Transparent;
            bunifuButton23.BackColor1 = Color.DeepSkyBlue;
            bunifuButton23.BackgroundImage = (Image)resources.GetObject("bunifuButton23.BackgroundImage");
            bunifuButton23.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton23.ButtonText = "Đăng nhập";
            bunifuButton23.ButtonTextMarginLeft = 0;
            bunifuButton23.ColorContrastOnClick = 45;
            bunifuButton23.ColorContrastOnHover = 45;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            bunifuButton23.CustomizableEdges = borderEdges3;
            bunifuButton23.DialogResult = DialogResult.None;
            bunifuButton23.DisabledBorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton23.DisabledFillColor = Color.FromArgb(204, 204, 204);
            bunifuButton23.DisabledForecolor = Color.FromArgb(168, 160, 168);
            bunifuButton23.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            bunifuButton23.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bunifuButton23.ForeColor = Color.WhiteSmoke;
            bunifuButton23.IconLeftAlign = ContentAlignment.MiddleLeft;
            bunifuButton23.IconLeftCursor = Cursors.Default;
            bunifuButton23.IconLeftPadding = new Padding(11, 3, 3, 3);
            bunifuButton23.IconMarginLeft = 11;
            bunifuButton23.IconPadding = 10;
            bunifuButton23.IconRightAlign = ContentAlignment.MiddleRight;
            bunifuButton23.IconRightCursor = Cursors.Default;
            bunifuButton23.IconRightPadding = new Padding(3, 3, 7, 3);
            bunifuButton23.IconSize = 25;
            bunifuButton23.IdleBorderColor = Color.SteelBlue;
            bunifuButton23.IdleBorderRadius = 50;
            bunifuButton23.IdleBorderThickness = 1;
            bunifuButton23.IdleFillColor = Color.DeepSkyBlue;
            bunifuButton23.IdleIconLeftImage = null;
            bunifuButton23.IdleIconRightImage = null;
            bunifuButton23.IndicateFocus = false;
            bunifuButton23.Location = new Point(166, 514);
            bunifuButton23.Name = "bunifuButton23";
            bunifuButton23.OnDisabledState.BorderColor = Color.FromArgb(191, 191, 191);
            bunifuButton23.OnDisabledState.BorderRadius = 50;
            bunifuButton23.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton23.OnDisabledState.BorderThickness = 1;
            bunifuButton23.OnDisabledState.FillColor = Color.FromArgb(204, 204, 204);
            bunifuButton23.OnDisabledState.ForeColor = Color.FromArgb(168, 160, 168);
            bunifuButton23.OnDisabledState.IconLeftImage = null;
            bunifuButton23.OnDisabledState.IconRightImage = null;
            bunifuButton23.onHoverState.BorderColor = Color.SteelBlue;
            bunifuButton23.onHoverState.BorderRadius = 50;
            bunifuButton23.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton23.onHoverState.BorderThickness = 1;
            bunifuButton23.onHoverState.FillColor = Color.Cyan;
            bunifuButton23.onHoverState.ForeColor = Color.White;
            bunifuButton23.onHoverState.IconLeftImage = null;
            bunifuButton23.onHoverState.IconRightImage = null;
            bunifuButton23.OnIdleState.BorderColor = Color.SteelBlue;
            bunifuButton23.OnIdleState.BorderRadius = 50;
            bunifuButton23.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton23.OnIdleState.BorderThickness = 1;
            bunifuButton23.OnIdleState.FillColor = Color.DeepSkyBlue;
            bunifuButton23.OnIdleState.ForeColor = Color.WhiteSmoke;
            bunifuButton23.OnIdleState.IconLeftImage = null;
            bunifuButton23.OnIdleState.IconRightImage = null;
            bunifuButton23.OnPressedState.BorderColor = Color.FromArgb(40, 96, 144);
            bunifuButton23.OnPressedState.BorderRadius = 50;
            bunifuButton23.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            bunifuButton23.OnPressedState.BorderThickness = 1;
            bunifuButton23.OnPressedState.FillColor = Color.FromArgb(40, 96, 144);
            bunifuButton23.OnPressedState.ForeColor = Color.White;
            bunifuButton23.OnPressedState.IconLeftImage = null;
            bunifuButton23.OnPressedState.IconRightImage = null;
            bunifuButton23.Size = new Size(203, 61);
            bunifuButton23.TabIndex = 12;
            bunifuButton23.TextAlign = ContentAlignment.MiddleCenter;
            bunifuButton23.TextAlignment = HorizontalAlignment.Center;
            bunifuButton23.TextMarginLeft = 0;
            bunifuButton23.TextPadding = new Padding(0);
            bunifuButton23.UseDefaultRadiusAndThickness = true;
            bunifuButton23.Click += bunifuButton23_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1219, 732);
            Controls.Add(bunifuPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Đăng nhập ";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            bunifuPanel1.ResumeLayout(false);
            bunifuPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private PictureBox pictureBox2;
        private Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton23;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton22;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton21;
        private Button ShowPasswordButton;
        private Label errorLabel;
    }
}