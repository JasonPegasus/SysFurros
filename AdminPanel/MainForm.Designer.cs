namespace AdminPanel
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            CONSOLE = new RichTextBox();
            BT_SQL_Start = new Button();
            BT_SQL_Stop = new Button();
            BT_Test = new Button();
            CH_AutoScroll = new CheckBox();
            SuspendLayout();
            // 
            // CONSOLE
            // 
            CONSOLE.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CONSOLE.BackColor = Color.Black;
            CONSOLE.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CONSOLE.ForeColor = Color.White;
            CONSOLE.Location = new Point(12, 12);
            CONSOLE.Name = "CONSOLE";
            CONSOLE.ReadOnly = true;
            CONSOLE.Size = new Size(865, 354);
            CONSOLE.TabIndex = 0;
            CONSOLE.Text = "";
            // 
            // BT_SQL_Start
            // 
            BT_SQL_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_SQL_Start.BackColor = Color.DimGray;
            BT_SQL_Start.FlatStyle = FlatStyle.Popup;
            BT_SQL_Start.Font = new Font("Segoe UI", 9F);
            BT_SQL_Start.Location = new Point(12, 372);
            BT_SQL_Start.Name = "BT_SQL_Start";
            BT_SQL_Start.Size = new Size(75, 30);
            BT_SQL_Start.TabIndex = 1;
            BT_SQL_Start.Text = "Start SQL";
            BT_SQL_Start.UseVisualStyleBackColor = false;
            // 
            // BT_SQL_Stop
            // 
            BT_SQL_Stop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_SQL_Stop.BackColor = Color.DimGray;
            BT_SQL_Stop.FlatStyle = FlatStyle.Popup;
            BT_SQL_Stop.Font = new Font("Segoe UI", 9F);
            BT_SQL_Stop.Location = new Point(12, 408);
            BT_SQL_Stop.Name = "BT_SQL_Stop";
            BT_SQL_Stop.Size = new Size(75, 30);
            BT_SQL_Stop.TabIndex = 2;
            BT_SQL_Stop.Text = "Stop SQL";
            BT_SQL_Stop.UseVisualStyleBackColor = false;
            // 
            // BT_Test
            // 
            BT_Test.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_Test.BackColor = Color.DimGray;
            BT_Test.FlatStyle = FlatStyle.Popup;
            BT_Test.Font = new Font("Segoe UI", 9F);
            BT_Test.Location = new Point(93, 372);
            BT_Test.Name = "BT_Test";
            BT_Test.Size = new Size(75, 30);
            BT_Test.TabIndex = 3;
            BT_Test.Text = "TEST";
            BT_Test.UseVisualStyleBackColor = false;
            // 
            // CH_AutoScroll
            // 
            CH_AutoScroll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CH_AutoScroll.AutoSize = true;
            CH_AutoScroll.Checked = true;
            CH_AutoScroll.CheckState = CheckState.Checked;
            CH_AutoScroll.Location = new Point(796, 372);
            CH_AutoScroll.Name = "CH_AutoScroll";
            CH_AutoScroll.Size = new Size(81, 19);
            CH_AutoScroll.TabIndex = 4;
            CH_AutoScroll.Text = "AutoScroll";
            CH_AutoScroll.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(889, 450);
            Controls.Add(CH_AutoScroll);
            Controls.Add(BT_Test);
            Controls.Add(BT_SQL_Stop);
            Controls.Add(BT_SQL_Start);
            Controls.Add(CONSOLE);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Syfur Admin Panel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox CONSOLE;
        private Button BT_SQL_Start;
        private Button BT_SQL_Stop;
        private Button BT_Test;
        private CheckBox CH_AutoScroll;
    }
}
