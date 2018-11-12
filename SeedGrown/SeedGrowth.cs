using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace SeedGrown
{
    class SeedGrowth : Automat2D
    {
        private List<Color> colors = new List<Color>();

        struct Cell
        {
            int i, j;
            public Cell(int i, int j)
            {
                this.i = i;
                this.j = j;
            }

            public int I { get => i; set => i = value; }
            public int J { get => j; set => j = value; }
        };
        public SeedGrowth(int N, int M, string sasiedztwo, string wb, PictureBox pictureBox, Bitmap bitmap, int x, int y) : base(N, M, wb, sasiedztwo,pictureBox,bitmap)
        {
            setBitmap(N,M,pictureBox, bitmap);
            rownomiernie(x, y, N, M, bitmap, pictureBox);
        }

        public SeedGrowth(int N, int M, string sasiedztwo, string wb, int NumberofInitialSeeds, PictureBox pictureBox, Bitmap bitmap) : base(N, M, wb, sasiedztwo, pictureBox, bitmap)
        {
            setBitmap(N, M, pictureBox, bitmap);
            losowo(NumberofInitialSeeds, N, M, bitmap, pictureBox);
        }

        public SeedGrowth(int N, int M, string sasiedztwo, string wb, int NumberofInitialSeeds, double radius, PictureBox pictureBox, Bitmap bitmap) : base(N, M, wb, sasiedztwo,pictureBox, bitmap)
        {
            setBitmap(N,M,pictureBox, bitmap);
            Withradius(radius, NumberofInitialSeeds, N, M, bitmap, pictureBox);
        }
        public SeedGrowth(int N, int M, string sasiedztwo, string wb, PictureBox pictureBox, Bitmap bitmap) : base(N, M, wb, sasiedztwo, pictureBox, bitmap)
        {
            setBitmap(N, M, pictureBox, bitmap);
            klikniecie(bitmap, pictureBox);
        }
        public override int getCellstate(List<int> neighbours, int i, int j)
        {

            if (Cells[i, j] == Color.Black.ToArgb())
            {
                Color color = Color.Black;


                int count = 0;
                for (int k = 0; k < colors.Count; k++)
                {
                    if (count < neighbours.Count((x) => x == colors[k].ToArgb()))
                    {
                        color = colors[k];
                        count = neighbours.Count((x) => x == colors[k].ToArgb());
                    }
                }
                return color.ToArgb();
            }
            else
                return Cells[i, j];
        }
        public void losowo(int NumberOfSeeds, int N, int M, Bitmap bitmap, PictureBox pictureBox)
        {
            Random random = new Random(DateTime.Now.Second);

            for (int i = 0; i < NumberOfSeeds; i++)
            {
                colors.Add(Color.FromKnownColor(KnownColor.SpringGreen + i));
                Cells[random.Next(1, N), random.Next(1, M)] = colors[i].ToArgb();
            }

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(Cells[i, j]));
                }

            pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));

        }
        public void klikniecie(Bitmap bitmap, PictureBox pictureBox)
        {
            int i = 0;
            Random rnd = new Random();
            pictureBox.MouseClick += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {

                int x = e.X / 3;
                int y = e.Y / 3;
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                Cells[x, y] = colors[i].ToArgb();
                bitmap.SetPixel(x, y, Color.FromArgb(Cells[x, y]));
                pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
                i++;
            });
        }
        public void rownomiernie(int x, int y, int N, int M, Bitmap bitmap, PictureBox pictureBox)
        {
            Random rnd = new Random(DateTime.Now.Second);
            //int spaceX = (((N - x) / x) / 2);
            //int spaceY = (((M - y) / y) / 2);

            int spaceX = (N / x) / 2;
            int spaceY = (M / y) / 2;
            int c = 0;
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));

                    if (j > 1 && i > 1 && j < y && i < x)
                    {

                        Cells[(j * 2 - 1) * spaceY, (i * 2 - 1) * spaceX] = colors[c].ToArgb();
                        bitmap.SetPixel((i * 2 - 1) * spaceX, (j * 2 - 1) * spaceY, Color.FromArgb(Cells[(j * 2 - 1) * spaceY, (i * 2 - 1) * spaceX]));
                    }
                    else if (i == 1 && j > 1 && j != y)
                    {
                        if (j == 2)
                        {
                            Cells[3 * spaceY, spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(spaceX, 3 * spaceY, Color.FromArgb(Cells[3 * spaceY, spaceX]));
                        }
                        else
                        {
                            Cells[(2 * j - 1) * spaceY, spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(spaceX, (2 * j - 1) * spaceY, Color.FromArgb(Cells[(2 * j - 1) * spaceY, spaceX]));
                        }
                    }
                    else if (j == 1 && i > 1 && i != x)
                    {
                        if (i == 2)
                        {
                            Cells[spaceY, 3 * spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(3 * spaceX, spaceY, Color.FromArgb(Cells[spaceY, 3 * spaceX]));
                        }
                        else
                        {
                            Cells[spaceY, (2 * i - 1) * spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel((2 * i - 1) * spaceX, spaceY, Color.FromArgb(Cells[spaceY, (2 * i - 1) * spaceX]));
                        }
                    }
                    else if (j == y && i > 1 && i != x)
                    {
                        if (i == 2)
                        {
                            Cells[M - spaceY, 3 * spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(3 * spaceX, M - spaceY, Color.FromArgb(Cells[M - spaceY, 3 * spaceX]));
                        }
                        else
                        {
                            Cells[M - spaceY, (2 * i - 1) * spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel((2 * i - 1) * spaceX, M - spaceY, Color.FromArgb(Cells[M - spaceY, (2 * i - 1) * spaceX]));
                        }
                    }

                    else if (j > 1 && i == x && j != y)
                    {
                        if (j == 2)
                        {
                            Cells[3 * spaceY, N - spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(N - spaceX, 3 * spaceY, Color.FromArgb(Cells[3 * spaceY, N - spaceX]));
                        }
                        else
                        {
                            Cells[(2 * j - 1) * spaceY, N - spaceX] = colors[c].ToArgb();
                            bitmap.SetPixel(N - spaceX, (2 * j - 1) * spaceY, Color.FromArgb(Cells[(2 * j - 1) * spaceY, N - spaceX]));
                        }
                    }
                    else if (i == 1 && j == 1)
                    {
                        Cells[spaceY, spaceX] = colors[c].ToArgb();
                        bitmap.SetPixel(spaceX, spaceY, Color.FromArgb(Cells[spaceY, spaceX]));
                    }
                    else if (i == x && j == 1)
                    {
                        Cells[spaceY, N - spaceX] = colors[c].ToArgb();
                        bitmap.SetPixel(N - spaceX, spaceY, Color.FromArgb(Cells[spaceY, N - spaceX]));
                    }
                    else if (j == y && i == 1)
                    {
                        Cells[M - spaceY, spaceX] = colors[c].ToArgb();
                        bitmap.SetPixel(spaceX, M - spaceY, Color.FromArgb(Cells[M - spaceY, spaceX]));
                    }
                    else if (j == y && i == x)
                    {
                        Cells[M - spaceY, N - spaceX] = colors[c].ToArgb();
                        bitmap.SetPixel(N - spaceX, M - spaceY, Color.FromArgb(Cells[M - spaceY, N - spaceX]));
                    }
                    c++;
                }
            }
            pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
        }
        public void Withradius(double radius, int NumberOfSeeds, int N, int M, Bitmap bitmap, PictureBox pictureBox)
        {

            Random random = new Random(DateTime.Now.Second);
            Random rnd = new Random();
            List<Cell> newCells = new List<Cell>();
            bool flag;

            int i = 0;
            while (i < NumberOfSeeds)
            {

                flag = true;
                int I = random.Next(1, N);
                int J = random.Next(1, M);

                foreach (Cell c in newCells)
                {
                    if (c.I != I && c.J != J)
                    {
                        if ((Math.Abs(c.I - I) < radius) && (Math.Abs(c.J - J) < radius))
                        {
                            flag = false;
                        }
                    }
                }

                if (flag == true)
                {
                    newCells.Add(new Cell(I, J));
                    i++;
                }
            }

            foreach (Cell c in newCells)
            {
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                Cells[c.I, c.J] = colors[newCells.IndexOf(c)].ToArgb();
                bitmap.SetPixel(c.I, c.J, Color.FromArgb(Cells[c.I, c.J]));
            }
            pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
        }
        public void setBitmap(int N , int M ,PictureBox pictureBox , Bitmap bitmap)
        {
            /////ustawianie poczatkowej bitmapy
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Cells[i, j] = Color.Black.ToArgb();
                    bitmap.SetPixel(i, j, Color.FromArgb(Cells[i, j]));
                }
            }
            pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
            /////////////////////////////////////
        }
    }
}
