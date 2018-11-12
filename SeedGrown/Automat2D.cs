using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace SeedGrown
{
    enum structure
    {
        Immutable,
        Oscilator,
        Glider,
        Dakota
    }

    class Automat2D
    {
        private int[,] cells;
        private int ibound;
        private int jbound;
        private string wb;
        private string sasiedztwo;
        private volatile bool work = false;
        PictureBox pictureBox;
        Bitmap bitmap;
        private int N, M;
   

        public int[,] Cells
        {
            get
            {
                return cells;
            }

            set
            {
                cells = value;
            }
        }

        public int Ibound
        {
            get
            {
                return ibound;
            }

            set
            {
                ibound = value;
            }
        }

        public int Jbound
        {
            get
            {
                return jbound;
            }

            set
            {
                jbound = value;
            }
        }

        public string Wb { get => wb; set => wb = value; }
        public string Sasiedztwo { get => sasiedztwo; set => sasiedztwo = value; }
        public int N1 { get => N; set => N = value; }
        public int M1 { get => M; set => M = value; }

        public void stop() { work = false; }

        public void setStructure(structure structure)
        {
            int xmid = ibound / 2;
            int ymid = jbound / 2;

            switch (structure)
            {
                case structure.Immutable:
                    cells[xmid, ymid] = 1;
                    cells[xmid, ymid + 1] = 1;
                    cells[xmid + 1, ymid - 1] = 1;
                    cells[xmid + 1, ymid + 2] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid + 2, ymid + 1] = 1;
                    break;
                case structure.Oscilator:
                    cells[xmid, ++ymid] = 1;
                    cells[xmid, ++ymid] = 1;
                    cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    break;
                case structure.Glider:
                    cells[xmid, ymid] = 1;
                    cells[xmid + 1, ymid] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid, ymid + 1] = 1;
                    cells[xmid + 1, ymid + 2] = 1;
                    break;
                case structure.Dakota:
                    cells[xmid, ymid] = 1;
                    cells[xmid, ymid - 1] = 1;
                    cells[xmid, ymid - 2] = 1;
                    cells[xmid + 1, ymid] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid + 3, ymid] = 1;
                    cells[xmid + 1, ymid - 3] = 1;
                    cells[xmid + 4, ymid - 1] = 1;
                    cells[xmid + 4, ymid - 3] = 1;
                    break;
            }
        }
        public void setStructure(structure structure, int x, int y)
        {
            int xmid = x;
            int ymid = y;

            switch (structure)
            {
                case structure.Immutable:
                    cells[xmid, ymid] = 1;
                    cells[xmid, ymid + 1] = 1;
                    cells[xmid + 1, ymid - 1] = 1;
                    cells[xmid + 1, ymid + 2] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid + 2, ymid + 1] = 1;
                    break;
                case structure.Oscilator:
                    cells[xmid, ++ymid] = 1;
                    cells[xmid, ++ymid] = 1;
                    cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    //cells[xmid, ++ymid] = 1;
                    break;
                case structure.Glider:
                    cells[xmid, ymid] = 1;
                    cells[xmid + 1, ymid] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid, ymid + 1] = 1;
                    cells[xmid + 1, ymid + 2] = 1;
                    break;
                case structure.Dakota:
                    cells[xmid, ymid] = 1;
                    cells[xmid, ymid - 1] = 1;
                    cells[xmid, ymid - 2] = 1;
                    cells[xmid + 1, ymid] = 1;
                    cells[xmid + 2, ymid] = 1;
                    cells[xmid + 3, ymid] = 1;
                    cells[xmid + 1, ymid - 3] = 1;
                    cells[xmid + 4, ymid - 1] = 1;
                    cells[xmid + 4, ymid - 3] = 1;
                    break;
            }
        }

        public Automat2D(int N, int M,string wb,string sasiedztwo,PictureBox pictureBox,Bitmap bitmap)
        {
            cells = new int[N, M];
            this.pictureBox = pictureBox;
            this.bitmap = bitmap;
            this.sasiedztwo = sasiedztwo;
            this.wb = wb;
            this.N = N;
            this.M = M;
            ibound = cells.GetUpperBound(0);
            jbound = cells.GetUpperBound(1);

            //cells[23, 24] = 1;
            //cells[23, 25] = 1;
            //cells[23, 26] = 1;
            //cells[24, 24] = 1;
            //cells[25, 25] = 1;
            //cells[100, 100] = 1;
            //cells[100, 101] = 1;
            //cells[100, 102] = 1;
            //cells[100, 103] = 1;
            //cells[100, 104] = 1;
            //cells[100, 105] = 1;
            //cells[100, 106] = 1;
            //cells[100, 107] = 1;
            //cells[100, 108] = 1;
            //cells[100, 109] = 1;
            //cells[100, 110] = 1;
            //cells[100, 111] = 1;

        }

        private void Refresh(PictureBox pictureBox, Bitmap bitmap, int N , int M )
        {
            /////ustawianie poczatkowej bitmapy
            for (int i = 0; i < N ; i++)
                for (int j = 0; j < M; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(Cells[i, j]));
                }
            pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
            /////////////////////////////////////
        }
        //public void Iterate(Action oniterate)
        public void Iterate()
        {

            work = true;
            while (work)
            {

                cells = GetnextIterationCells(wb, sasiedztwo);
                // oniterate();
                Refresh(pictureBox, bitmap, N, M);
                
            }
        }


        private int[,] GetnextIterationCells(string wb , string sąsiedztwo)
        {

            int[,] newCells = new int[cells.GetLength(0), cells.GetLength(1)];
            //Parallel.For(0, ibound + 1, index =>
            //   {
            //       for (int j = 0; j < newCells.GetLength(1); j++)
            //           newCells[index, j] = getCellstate(getNeighbours(index, j), index, j);
            //   });

            switch (sąsiedztwo) {
                case "von neumann":
                    for (int i = 0; i < newCells.GetLength(0); i++)
                        for (int j = 0; j < newCells.GetLength(1); j++)
                            newCells[i, j] = getCellstate(getNeighboursVonNeumann(i, j, wb), i, j);
                    break;
                case "Moore":
                    for (int i = 0; i < newCells.GetLength(0); i++)
                        for (int j = 0; j < newCells.GetLength(1); j++)
                            newCells[i, j] = getCellstate(getNeighboursMoore(i, j, wb), i, j);
                    break;
                case "Heksagonal left":
                    for (int i = 0; i < newCells.GetLength(0); i++)
                        for (int j = 0; j < newCells.GetLength(1); j++)
                            newCells[i, j] = getCellstate(getNeighboursHexLeft(i, j, wb), i, j);
                    break;
                case "Hexagonal right":
                    for (int i = 0; i < newCells.GetLength(0); i++)
                        for (int j = 0; j < newCells.GetLength(1); j++)
                            newCells[i, j] = getCellstate(getNeighboursHexRight(i, j, wb), i, j);
                    break;
                case "Hexagonal losowe":
                    Random random = new Random();
                    if(random.Next(1,3) == 1)
                    {
                        for (int i = 0; i < newCells.GetLength(0); i++)
                            for (int j = 0; j < newCells.GetLength(1); j++)
                                newCells[i, j] = getCellstate(getNeighboursHexLeft(i, j, wb), i, j);
                    }
                    else
                    {
                        for (int i = 0; i < newCells.GetLength(0); i++)
                            for (int j = 0; j < newCells.GetLength(1); j++)
                                newCells[i, j] = getCellstate(getNeighboursHexRight(i, j, wb), i, j);
                    }
                    break;
                case "Pentagonal losowe":
                    for (int i = 0; i < newCells.GetLength(0); i++)
                        for (int j = 0; j < newCells.GetLength(1); j++)
                            newCells[i, j] = getCellstate(getNeighboursPentaRandom(i, j, wb), i, j);
                    
                    break;

                default:
                    break;
            }
            return newCells;
        }
        private List<int> getNeighboursMoore(int i, int j,string wb)
        {
            List<int> neighbours = new List<int>();


            if (wb == "periodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[ibound, k]);
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[0, k]);
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, jbound]);
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, 0]);
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, jbound]);
                    neighbours.Add(cells[i + 1, jbound]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[ibound, j + 1]);
                    neighbours.Add(cells[ibound, jbound]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[0, j]);
                    neighbours.Add(cells[0, j + 1]);
                    neighbours.Add(cells[i - 1, jbound]);
                    neighbours.Add(cells[i, jbound]);
                    neighbours.Add(cells[0, jbound]);
                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, 0]);
                    neighbours.Add(cells[i, 0]);
                    neighbours.Add(cells[0, j - 1]);
                    neighbours.Add(cells[0, jbound]);
                    neighbours.Add(cells[0, 0]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[ibound, j - 1]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[i, 0]);
                    neighbours.Add(cells[i + 1, 0]);
                    neighbours.Add(cells[ibound, 0]);

                }
                else
                {
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i + 1, j + 1]);
                }

            }

            if (wb == "nieperiodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j + 1; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i + 1; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else
                {
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i + 1, j + 1]);
                }
            }

            return neighbours;
        }
        private List<int> getNeighboursVonNeumann(int i, int j,string wb)
        {
            List<int> neighbours = new List<int>();

            if (wb == "periodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[0, j]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i, jbound]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, 0]);

                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, jbound]);
                    neighbours.Add(cells[ibound, j]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i, jbound]);
                    neighbours.Add(cells[0, j]);

                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[ibound, 0]);
                    neighbours.Add(cells[0, jbound]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[i, 0]);
                }
                else
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
            }
            if (wb == "nieperiodyczne")
            {
                 if (i == 0 && j != 0 && j != jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j - 1]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);

                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
            }

           return neighbours;
        }
        private List<int> getNeighboursHexLeft(int i, int j,string wb)
        {
            List<int> neighbours = new List<int>();

            if (wb == "periodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[ibound, k]);
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[0, k]);
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, jbound]);
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, 0]);
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[jbound, i]);
                    neighbours.Add(cells[ibound, jbound]);
                    neighbours.Add(cells[ibound, j]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[0, j + 1]);
                    neighbours.Add(cells[0, j]);
                    neighbours.Add(cells[ibound, jbound]);
                    neighbours.Add(cells[ibound - 1, jbound]);

                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[ibound, 0]);
                    neighbours.Add(cells[0, 0]);
                    neighbours.Add(cells[0, jbound]);

                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[ibound, j - 1]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[i, 0]);
                    neighbours.Add(cells[i + 1, 0]);
                    neighbours.Add(cells[i + 1, j]);

                }
                else
                {
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                }
            }
            if(wb == "nieperiodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i + 1, j]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i, j + 1]);

                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else
                {
                    neighbours.Add(cells[i + 1, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                }
            }


            return neighbours;
        }
        private List<int> getNeighboursHexRight(int i , int j,string wb)
        {
            List<int> neighbours = new List<int>();

            if (wb == "periodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[ibound, k]);
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[0, k]);
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, jbound]);
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, 0]);
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i, jbound]);
                    neighbours.Add(cells[i + 1, jbound]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[ibound, j + 1]);

                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[0, j]);
                    neighbours.Add(cells[0, jbound]);
                    neighbours.Add(cells[i, jbound]);

                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[ibound - 1, 0]);
                    neighbours.Add(cells[ibound, 0]);
                    neighbours.Add(cells[0, jbound]);
                    neighbours.Add(cells[0, jbound - 1]);

                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[ibound, j]);
                    neighbours.Add(cells[ibound, 0]);
                    neighbours.Add(cells[i, 0]);
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i + 1, j - 1]);
                }
                else
                {
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i, j - 1]);
                }
            }
            if(wb == "nieperiodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    for (int k = j - 1; k <= j; k++)
                        neighbours.Add(cells[i + 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    for (int k = j; k <= j + 1; k++)
                        neighbours.Add(cells[ibound - 1, k]);
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    for (int k = i - 1; k <= i; k++)
                        neighbours.Add(cells[k, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (j == jbound && i != 0 && i != ibound)
                { 
                    for (int k = i; k <= i + 1; k++)
                        neighbours.Add(cells[k, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == 0)
                {
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                }
                else if (i == ibound && j == 0)
                {
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j + 1]);
                    neighbours.Add(cells[i, j + 1]);
                }
                else if (i == ibound && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i + 1, j]);
                }
                else if (i == 0 && j == jbound)
                {
                    neighbours.Add(cells[i, j - 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j - 1]);
                }
                else
                {
                    neighbours.Add(cells[i + 1, j]);
                    neighbours.Add(cells[i + 1, j + 1]);
                    neighbours.Add(cells[i, j + 1]);
                    neighbours.Add(cells[i - 1, j]);
                    neighbours.Add(cells[i - 1, j - 1]);
                    neighbours.Add(cells[i, j - 1]);
                }
            }

            return neighbours;

        }
        private List<int> getNeighboursPentaRandom(int i, int j, string wb)
        {
            Random random = new Random(DateTime.Now.Second);
            List<int> neighbours = getNeighboursMoore(i, j, wb);

            if (wb == "periodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                    }
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 4:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                    }
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 2:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(5);
                            break;
                    }
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 3:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(2);
                            break;
                    }
                }
                else if (i == 0 && j == 0)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 3:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                        case 4:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                    }
                }
                else if (i == ibound && j == 0)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                        case 3:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                    }
                }
                else if (i == ibound && j == jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 2:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                    }
                }
                else if (i == 0 && j == jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                        case 2:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(3);
                            break;
                        case 4:
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                    }
                }
                else
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                    }
                }
            }
            else if(wb == "nieperiodyczne")
            {
                if (i == 0 && j != 0 && j != jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            break;
                        case 4:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                    }
                }
                else if (i == ibound && j != 0 && j != jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            break;
                    }
                }
                else if (j == 0 && i != 0 && i != ibound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            break;
                        case 3:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                    }
                }
                else if (j == jbound && i != 0 && i != ibound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            break;
                        case 2:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);                           
                            break;
                        case 3:
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                    }
                }
                else if (i == 0 && j == 0)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                    }
                }
                else if (i == ibound && j == 0)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(0);
                            break;
                        case 2:
                            break;
                        case 3:
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            break;
                    }
                }
                else if (i == ibound && j == jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            break;
                        case 2:
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                        case 4:
                            break;
                    }
                }
                else if (i == 0 && j == jbound)
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            break;
                        case 2:
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:                           
                            break;
                        case 4:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            break;
                    }
                }
                else
                {
                    switch (random.Next(1, 5))
                    {
                        case 1:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(4);
                            neighbours.RemoveAt(2);
                            break;
                        case 2:
                            neighbours.RemoveAt(5);
                            neighbours.RemoveAt(3);
                            neighbours.RemoveAt(0);
                            break;
                        case 3:
                            neighbours.RemoveAt(2);
                            neighbours.RemoveAt(1);
                            neighbours.RemoveAt(0);
                            break;
                        case 4:
                            neighbours.RemoveAt(7);
                            neighbours.RemoveAt(6);
                            neighbours.RemoveAt(5);
                            break;
                    }
                }
            }
            return neighbours;
        }
        public virtual int getCellstate(List<int> neighbours, int i, int j)
        {
            int count = (from x in neighbours
                         where x != 0
                         select x).Count();
            switch (cells[i, j])
            {
                case 0:
                    return count == 3 ? 1 : 0;
                case 1:
                    if (count == 2 || count == 3)
                        return 1;
                    else if (count > 3 || count < 2)
                        return 0;
                    break;
            }
            return 0;
        }
    }
}
