using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    class Polygon
    {
        public Vertice[] Vertices { get; set; }
        public int[] VerticesSorted { get; set; }
        public int YMin { get; set; }
        public int YMax { get; set; }

        public Polygon(IEnumerable<Point> vertices)
        {
            Vertices = new Vertice[vertices.Count()];

            int k = 0;
            foreach (Point v in vertices)
            {
                Vertices[k] = new Vertice { Location = v };
                k++;
            }
            SortVertices();
            YMin = Vertices[VerticesSorted[0]].Y;
            YMax = Vertices[VerticesSorted[VerticesSorted.Length - 1]].Y;

        }

        private void SortVertices()
        {
            VerticesSorted = new int[Vertices.Length];
            bool[] isSorted = new bool[Vertices.Length];
            int indexMin = 0, yFrom = 0, min = int.MaxValue;
            for (int i = 0; i < Vertices.Length; i++)
            {
                indexMin = 0;
                min = int.MaxValue;
                for (int j = 0; j < Vertices.Length; j++)
                {
                    // TODO
                    if (!isSorted[j] && Vertices[j].Y >= yFrom && Vertices[j].Y < min)
                    {
                        indexMin = j;
                        min = Vertices[j].Y;
                    }
                }
                VerticesSorted[i] = indexMin;
                yFrom = Vertices[indexMin].Y;
                isSorted[indexMin] = true;
            }
        }

        public void UpdateProperties()
        {
            for (int i = 0; i < VerticesSorted.Length - 1; i++)
                if (Vertices[VerticesSorted[i]].Y > Vertices[VerticesSorted[i + 1]].Y)
                {
                    SortVertices();
                    break;
                }

            YMin = Vertices[VerticesSorted[0]].Y;
            YMax = Vertices[VerticesSorted[VerticesSorted.Length - 1]].Y;
        }
    }

    class Edge : IComparable, IEquatable<Edge>
    {
        public int YMax { get; set; }
        public double X { get; set; }
        public double Ctg { get; set; }
        public Edge Next { get; set; }

        public static bool operator ==(Edge e1, Edge e2) => e1.YMax == e2.YMax && e1.Ctg == e2.Ctg;

        public static bool operator !=(Edge e1, Edge e2) => !(e1 == e2);

        public static bool operator >=(Edge e1, Edge e2) => e1.X >= e2.X;

        public static bool operator <=(Edge e1, Edge e2) => e1.X <= e2.X;

        public int CompareTo(object obj)
        {
            if (X < ((Edge)obj).X) return -1;
            else if (X == ((Edge)obj).X) return 0;
            return 1;
        }

        public bool Equals(Edge other) => this == other;

        //public static Comparison<Edge> XComparator = (e1, e2) =>
        //{
        //    if (e1.X < e2.X) return -1;
        //    else if (e1.X == e2.X) return 0;
        //    return 1;
        //};
    }

    class Vertice
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point Location
        {
            get => new Point(X, Y);
            set { X = value.X; Y = value.Y; }
        }
        //public Edge PrevEdge { get; set; }
        //public Edge NextEdge { get; set; }
    }

    struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }
}
