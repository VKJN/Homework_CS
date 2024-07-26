namespace WinFormsApp1
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
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            textBox6 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1061, 585);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(textBox5);
            splitContainer1.Panel1.Controls.Add(textBox4);
            splitContainer1.Panel1.Controls.Add(textBox3);
            splitContainer1.Panel1.Controls.Add(textBox2);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox6);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(1061, 585);
            splitContainer1.SplitterDistance = 519;
            splitContainer1.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(26, 217);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(220, 23);
            textBox5.TabIndex = 14;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(26, 143);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(220, 23);
            textBox4.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(26, 278);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(220, 23);
            textBox3.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(26, 340);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(220, 23);
            textBox2.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 125);
            label4.Name = "label4";
            label4.Size = new Size(138, 15);
            label4.TabIndex = 9;
            label4.Text = "Паспорт (серия/номер)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 322);
            label7.Name = "label7";
            label7.Size = new Size(125, 15);
            label7.TabIndex = 8;
            label7.Text = "Почему выбрали нас";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 260);
            label6.Name = "label6";
            label6.Size = new Size(120, 15);
            label6.TabIndex = 7;
            label6.Text = "Кем хотите работать";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 199);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 6;
            label5.Text = "Место жительства";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 58);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 4;
            label3.Text = "ФИО";
            // 
            // button1
            // 
            button1.Location = new Point(127, 495);
            button1.Name = "button1";
            button1.Size = new Size(219, 23);
            button1.TabIndex = 2;
            button1.Text = "Показать результат";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(211, 19);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 0;
            label1.Text = "Анкета";
            // 
            // button2
            // 
            button2.Location = new Point(157, 495);
            button2.Name = "button2";
            button2.Size = new Size(237, 23);
            button2.TabIndex = 3;
            button2.Text = "Сохранить и отправить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(248, 19);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 1;
            label2.Text = "Результат";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(36, 76);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(464, 302);
            textBox6.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 585);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox6;
    }
}
