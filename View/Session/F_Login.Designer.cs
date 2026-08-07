namespace View
{
    partial class F_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
            pictureBox1 = new PictureBox();
            TX_Username = new TextBox();
            label1 = new Label();
            label2 = new Label();
            TX_Password = new TextBox();
            BT_PasswordView = new Button();
            BT_Login = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(15, 17);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TX_Username
            // 
            TX_Username.Location = new Point(60, 95);
            TX_Username.Margin = new Padding(4);
            TX_Username.Name = "TX_Username";
            TX_Username.Size = new Size(157, 28);
            TX_Username.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 69);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 22);
            label1.TabIndex = 2;
            label1.Text = "Username";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 127);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 22);
            label2.TabIndex = 4;
            label2.Text = "Password";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TX_Password
            // 
            TX_Password.Location = new Point(60, 153);
            TX_Password.Margin = new Padding(4);
            TX_Password.Name = "TX_Password";
            TX_Password.Size = new Size(157, 28);
            TX_Password.TabIndex = 3;
            // 
            // BT_PasswordView
            // 
            BT_PasswordView.BackColor = Color.FromArgb(64, 64, 64);
            BT_PasswordView.Location = new Point(224, 152);
            BT_PasswordView.Name = "BT_PasswordView";
            BT_PasswordView.Size = new Size(28, 28);
            BT_PasswordView.TabIndex = 5;
            BT_PasswordView.Tag = "backcolor";
            BT_PasswordView.Text = "♣";
            BT_PasswordView.UseVisualStyleBackColor = false;
            // 
            // BT_Login
            // 
            BT_Login.BackColor = Color.Red;
            BT_Login.Location = new Point(60, 188);
            BT_Login.Name = "BT_Login";
            BT_Login.Size = new Size(157, 43);
            BT_Login.TabIndex = 6;
            BT_Login.Tag = "";
            BT_Login.Text = "Login";
            BT_Login.UseVisualStyleBackColor = false;
            // 
            // F_Login
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 266);
            Controls.Add(BT_Login);
            Controls.Add(BT_PasswordView);
            Controls.Add(label2);
            Controls.Add(TX_Password);
            Controls.Add(label1);
            Controls.Add(TX_Username);
            Controls.Add(pictureBox1);
            Font = new Font("Bahnschrift Light", 13F);
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "F_Login";
            Text = "Login to Syfur";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox TX_Username;
        private Label label1;
        private Label label2;
        private TextBox TX_Password;
        private Button BT_PasswordView;
        private Button BT_Login;
    }
}
