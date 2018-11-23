using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageOnBezierCurve
{
    public class Node
    {
        public Point Location { get; set; }
        public int X
        {
            get => Location.X;
            set { Location = new Point(value, Location.Y); }
        }
        public int Y
        {
            get => Location.Y;
            set { Location = new Point(Location.X, value); }
        }

        public Node(Point p) => Location = p;
        public Node(int x, int y) => Location = new Point(x, y);

        //public static explicit operator Point(Node n) => n.Location;
        //public static implicit operator Point(Node n) => n.Location;
    }

    public class BezierCurve
    {
        public int N;
        public IEnumerable<Point> ControlPoints { get { foreach (Node n in Nodes) yield return n.Location; } }
        public Node[] Nodes { get; private set; }
        private int[] binomials;
        //private int[,] bases;

        public BezierCurve(int n, int w, int y, int maxW)
        {
            N = n;
            Nodes = new Node[N + 1];
            int d = w / (n - 1);
            for (int i = 0; i < Nodes.Length; i++)
            {
                Point p = new Point((i + 1) * d, i % 2 == 0 ? y - 50 : y + 50);
                Nodes[i] = new Node(p);
            }
            binomials = new int[n + 1];
            int t = 1;
            for (int i = 0; i < binomials.Length; i++)
            {
                binomials[i] = t;
                t = t * (n - i) / (i + 1);
            }

        }

        public IEnumerable<Point> CurvePoints(int k)
        {
            double step = 1.0 / k;
            for (double t = 0; t < 1; t += step)
            {
                Point p = new Point(0, 0);
                for (int i = 0; i < Nodes.Length; i++)
                {
                    int z = (int)(Nodes[i].X * binomials[i] * Math.Pow(t, i) * Math.Pow(1 - t, N - i));
                    p.X += z;
                    p.Y += (int)(Nodes[i].Y * binomials[i] * Math.Pow(t, i) * Math.Pow(1 - t, N - i));
                }
                yield return p;
            }

            //for (int t = Nodes[0].X; t < Nodes[Nodes.Length - 1].X; t++)
            //{
            //    int s = 1 - t;
            //    int p = Nodes[0].Y;
            //    int d = t;
            //    int b = Nodes.Length;
            //    for (int i = 1; i < Nodes.Length; i++)
            //    {
            //        p = s * p + b * d * Nodes[i].Y;
            //        d *= t;
            //        b = b * (Nodes.Length - i) / (i + 1);
            //    }
            //    yield return new Point(t, p);
            //}
        }
    }
}
