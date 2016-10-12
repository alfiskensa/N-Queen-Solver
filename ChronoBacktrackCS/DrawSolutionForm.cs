using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChronoBacktrackCS
{
    public partial class DrawSolutionForm : Form
    {
        int n;
        List<int> solution = new List<int>();
        List<int> unlabelled = new List<int>();

        public DrawSolutionForm(int N, int seed)
        {
            n = N;
            InitializeComponent();

            ChronoBacktrack bt = new ChronoBacktrack();
            int[] compoundLabel = new int[n];

            Random rand = new Random(seed);

	        for (int i = 0; i < n; i++)
            {
                compoundLabel[i] = -1;
   		        unlabelled.Add(i);
            }

            bool found = bt.Backtrack(unlabelled, ref compoundLabel,
                ref solution, ref rand);
        }

        void DrawQueen(Graphics graphics, int x, int y, int w)
        {
            Brush brush = new SolidBrush(Color.Red);
            Point[] triangle1 = new Point[3];
            Point[] triangle2 = new Point[3];

            triangle1[0].X = x + 35;
            triangle1[0].Y = y + 35;
            triangle1[1].X = x + 55;
            triangle1[1].Y = y + 35;
            triangle1[2].X = x + 45;
            triangle1[2].Y = y + 55;

            triangle2[0].X = x + 45;
            triangle2[0].Y = y + 55;
            triangle2[1].X = x + 35;
            triangle2[1].Y = y + 75;
            triangle2[2].X = x + 55;
            triangle2[2].Y = y + 75;

            graphics.FillRectangle(brush, x + 35, y + 15, 20, 10);
            graphics.FillEllipse(brush, x + 40, y + 25, 10, 10);
            graphics.FillPolygon(brush, triangle1);
            graphics.FillPolygon(brush, triangle2);
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            ClientSize = new Size(n * 90, n * 90);
            
            int s = 90;
            int y =0;
            Graphics graphics = pea.Graphics;

            for (int row = 0; row < n; row++)
            {
                int x = 0;

                if (row % 2 == 0)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col % 2 == 0)
                        {
                            Brush brush = new SolidBrush(Color.White);

                            graphics.FillRectangle(brush, x, y, s, s);
                        }
                        else
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            graphics.FillRectangle(brush, x, y, s, s);
                        }
                        x += s;
                    }
                }
                else
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (col % 2 == 0)
                        {
                            Brush brush = new SolidBrush(Color.Black);

                            graphics.FillRectangle(brush, x, y, s, s);
                        }
                        else
                        {
                            Brush brush = new SolidBrush(Color.White);

                            graphics.FillRectangle(brush, x, y, s, s);
                        }
                        x += s;
                    }
                }
                y += s;
            }

            y = 0;

            for (int row = 0; row < n; row++)
            {
                int column = solution.ElementAt<int>(row), x;

                x = column * s;
                DrawQueen(graphics, x, y, s);
                y += s;
            }
        }
    }
}
