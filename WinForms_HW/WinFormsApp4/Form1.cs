using System;
using System.Drawing;

namespace WinFormsApp4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int cols;
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
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new bool[cols, rows];

            Random random = new Random();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)numDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
            //graphics.FillRectangle(Brushes.Crimson, 0, 0, resolution, resolution);
        }

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);
            var newField = new bool[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var neighboursCount = CountNeighbours(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife && neighboursCount == 3)
                        newField[x, y] = true;

                    else if (hasLife && (neighboursCount < 2 || neighboursCount > 3))
                        newField[x, y] = false;

                    else
                        newField[x, y] = field[x, y];

                    if (hasLife)
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);

                }
            }
            field = newField;
            pictureBox1.Refresh();

            countNextGeneration++;
            this.Text = "Generations: " + countNextGeneration.ToString();
        }

        private int CountNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + cols) % cols;
                    var row = (y + j + rows) % rows;

                    var isSelfCheking = col == x && row == y;
                    var hasLife = field[col, row];

                    if (hasLife && !isSelfCheking)
                    {
                        count++;
                    }
                }
            }
            return count;
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
            NextGeneration();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled) return;

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);

                if (validationPassed)
                    field[x, y] = true;
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var validationPassed = ValidateMousePosition(x, y);

                if (validationPassed)
                    field[x, y] = false;
            }
        }
    }
}
