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
            CONSOLE.Size = new Size(865, 308);
            CONSOLE.TabIndex = 0;
            CONSOLE.Text = "";
            // 
            // BT_SQL_Start
            // 
            BT_SQL_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_SQL_Start.BackColor = Color.Gray;
            BT_SQL_Start.FlatStyle = FlatStyle.Flat;
            BT_SQL_Start.Font = new Font("Segoe UI", 9F);
            BT_SQL_Start.Location = new Point(12, 326);
            BT_SQL_Start.Name = "BT_SQL_Start";
            BT_SQL_Start.Size = new Size(75, 30);
            BT_SQL_Start.TabIndex = 1;
            BT_SQL_Start.Text = "Start SQL";
            BT_SQL_Start.UseVisualStyleBackColor = false;
            // 
            // BT_SQL_Stop
            // 
            BT_SQL_Stop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_SQL_Stop.BackColor = Color.Gray;
            BT_SQL_Stop.FlatStyle = FlatStyle.Flat;
            BT_SQL_Stop.Font = new Font("Segoe UI", 9F);
            BT_SQL_Stop.Location = new Point(12, 362);
            BT_SQL_Stop.Name = "BT_SQL_Stop";
            BT_SQL_Stop.Size = new Size(75, 30);
            BT_SQL_Stop.TabIndex = 2;
            BT_SQL_Stop.Text = "Stop SQL";
            BT_SQL_Stop.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(889, 450);
            Controls.Add(BT_SQL_Stop);
            Controls.Add(BT_SQL_Start);
            Controls.Add(CONSOLE);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Syfur Admin Panel";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox CONSOLE;
        private Button BT_SQL_Start;
        private Button BT_SQL_Stop;
    }
}
