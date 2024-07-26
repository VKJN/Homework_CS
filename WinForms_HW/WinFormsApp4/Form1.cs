using System;
using System.Drawing;

namespace WinFormsApp4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Graphics graphics;
        private int resolution;
        private GameEngine engine;
        private int countNextGeneration;

        public Form()
        {
            InitializeComponent();
            this.Text = "Generations: 0";
        }

        private void StartGame()
        {
            if (timer1.Enabled)
                return;

            numResolution.Enabled = false;
            numDensity.Enabled = false;

            resolution = (int)numResolution.Value;

            engine = new GameEngine
                (
                    rows: pictureBox1.Height / resolution,
                    cols: pictureBox1.Width / resolution,
                    density: (int)numDensity.Minimum + (int)numDensity.Maximum - (int)numDensity.Value
                );

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
            //graphics.FillRectangle(Brushes.Crimson, 0, 0, resolution, resolution);
        }

        private void DrawNextGeneration()
        {
            graphics.Clear(Color.Black);
            var field = engine.GetCurrentGeneration();
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x,y])
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, 
                            y * resolution, resolution - 1, resolution - 1);
                }
            }

            pictureBox1.Refresh();
            engine.NextGeneration();

            countNextGeneration++;
            this.Text = "Generations: " + countNextGeneration.ToString();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;

            timer1.Stop();
            numResolution.Enabled = true;
            numDensity.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawNextGeneration();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled) return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                engine.AddCell(x, y);
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                engine.RemoveCell(x, y);
            }
        }
    }
}
