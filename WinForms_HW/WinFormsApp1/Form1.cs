namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Анкета отправлена");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Text = label3.Text + " - " + textBox1.Text;
            textBox6.Text += Environment.NewLine + label4.Text + " - " + textBox4.Text;
            textBox6.Text += Environment.NewLine + label5.Text + " - " + textBox5.Text;
            textBox6.Text += Environment.NewLine + label6.Text + " - " + textBox3.Text;
            textBox6.Text += Environment.NewLine + label7.Text + " - " + textBox2.Text;
        }
    }
}
