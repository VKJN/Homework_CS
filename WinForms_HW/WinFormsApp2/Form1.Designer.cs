namespace WinFormsApp2
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
            TopLevelMenu = new TextBox();
            SubItem = new TextBox();
            button1 = new Button();
            button2 = new Button();
            menuStrip1 = new MenuStrip();
            SuspendLayout();
            // 
            // TopLevelMenu
            // 
            TopLevelMenu.Location = new Point(44, 134);
            TopLevelMenu.Name = "TopLevelMenu";
            TopLevelMenu.Size = new Size(146, 23);
            TopLevelMenu.TabIndex = 0;
            // 
            // SubItem
            // 
            SubItem.Location = new Point(44, 194);
            SubItem.Name = "SubItem";
            SubItem.Size = new Size(146, 23);
            SubItem.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(233, 134);
            button1.Name = "button1";
            button1.Size = new Size(154, 23);
            button1.TabIndex = 2;
            button1.Text = "Добавить пункт меню";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(233, 193);
            button2.Name = "button2";
            button2.Size = new Size(154, 23);
            button2.TabIndex = 3;
            button2.Text = "Добавить подменю";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(SubItem);
            Controls.Add(TopLevelMenu);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TopLevelMenu;
        private TextBox SubItem;
        private Button button1;
        private Button button2;
        private MenuStrip menuStrip1;
    }
}
