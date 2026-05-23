namespace View.Design.StyleForms
{
    partial class SF_WindowsDefault
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            checkBox1 = new CheckBox();
            radioButton1 = new RadioButton();
            progressBar1 = new ProgressBar();
            numericUpDown1 = new NumericUpDown();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            listBox1 = new ListBox();
            test1 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "test", "test2", "test3" });
            comboBox1.Location = new Point(12, 88);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 47);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(237, 12);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(115, 23);
            progressBar1.TabIndex = 6;
            progressBar1.Value = 60;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(6, 72);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(99, 23);
            numericUpDown1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Location = new Point(118, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(113, 99);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { test1, Column1, Column2 });
            dataGridView1.Location = new Point(10, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(342, 111);
            dataGridView1.TabIndex = 10;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "el niño del oxxo", "enrique", "test", "el pepe", "ete sech" });
            listBox1.Location = new Point(237, 41);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(115, 64);
            listBox1.TabIndex = 11;
            // 
            // test1
            // 
            test1.HeaderText = "Column1";
            test1.Name = "test1";
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // SF_WindowsDefault
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 239);
            Controls.Add(listBox1);
            Controls.Add(dataGridView1);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "SF_WindowsDefault";
            Text = "SF_WindowsDefault";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private RadioButton radioButton1;
        private ProgressBar progressBar1;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private ListBox listBox1;
        private DataGridViewTextBoxColumn test1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}