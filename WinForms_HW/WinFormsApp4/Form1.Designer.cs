namespace WinFormsApp4
{
    partial class Form
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            btnStop = new Button();
            btnStart = new Button();
            numDensity = new NumericUpDown();
            label1 = new Label();
            numResolution = new NumericUpDown();
            labelResolution = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDensity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numResolution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnStop);
            splitContainer1.Panel1.Controls.Add(btnStart);
            splitContainer1.Panel1.Controls.Add(numDensity);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(numResolution);
            splitContainer1.Panel1.Controls.Add(labelResolution);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(1093, 635);
            splitContainer1.SplitterDistance = 195;
            splitContainer1.TabIndex = 0;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStop.Location = new Point(10, 148);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(120, 34);
            btnStop.TabIndex = 7;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(10, 110);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(120, 32);
            btnStart.TabIndex = 5;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // numDensity
            // 
            numDensity.Location = new Point(10, 81);
            numDensity.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numDensity.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numDensity.Name = "numDensity";
            numDensity.Size = new Size(120, 23);
            numDensity.TabIndex = 4;
            numDensity.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(10, 57);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 3;
            label1.Text = "Density";
            // 
            // numResolution
            // 
            numResolution.Location = new Point(10, 31);
            numResolution.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numResolution.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numResolution.Name = "numResolution";
            numResolution.Size = new Size(120, 23);
            numResolution.TabIndex = 2;
            numResolution.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // labelResolution
            // 
            labelResolution.AutoSize = true;
            labelResolution.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelResolution.Location = new Point(10, 7);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(92, 21);
            labelResolution.TabIndex = 1;
            labelResolution.Text = "Resolution";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(890, 631);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseMove += pictureBox1_MouseMove_1;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 635);
            Controls.Add(splitContainer1);
            Name = "Form";
            Text = "WinForms";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numDensity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numResolution).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label labelResolution;
        private NumericUpDown numResolution;
        private NumericUpDown numDensity;
        private Label label1;
        private Button btnStart;
        private Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
    }
}
