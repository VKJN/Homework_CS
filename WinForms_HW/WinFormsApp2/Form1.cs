namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuStrip1.Items.Add(TopLevelMenu.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < menuStrip1.Items.Count; i++)
            {
                if (menuStrip1.Items[i].Text == TopLevelMenu.Text)
                {
                    ToolStripMenuItem currentTopLevel = (ToolStripMenuItem)menuStrip1.Items[i];
                    currentTopLevel.DropDownItems.Add(SubItem.Text);
                }
            }
        }
    }
}
