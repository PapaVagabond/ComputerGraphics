using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyEditor
{
    class Polygon
    {
        //public List<Vertice> Vertices { get; set; }
        public LinkedList<Vertice> Vertices { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }

        public Polygon(IEnumerable<Vertice> vertices = null, string name = "figure", bool visible = true)
        {
            //Vertices = vertices != null ? vertices : new List<Vertice>();
            Vertices = vertices == null ? null : new LinkedList<Vertice>(vertices);
            Visible = visible;
            Name = name;
        }

        public void SetEdgeHorizontal(int k)
        {
            Vertice a = Vertices.ElementAt(k);
            Vertice b = Vertices.ElementAt((k + 1) < Vertices.Count ? k + 1 : 0);

        }

        private double Distance(Point p1, Point p2) => (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);

        public void UpdateVertices(LinkedListNode<Vertice> start)
        {
            if (start.List!=Vertices)
                throw new ArgumentException();

            var node = start;
            LinkedListNode<Vertice> v;
            Point newPoint;
            double eps = 3;
            int i = 0;
            for (; i < Vertices.Count; i++)
            {
                v = node.Next != null ? node.Next : Vertices.First;
                if (v.Value.IsAngleSet)
                {
                    Point p1 = node.Value.Location, p2 = v.Value.Location, p3 = v.Next != null ? v.Next.Value.Location : Vertices.First().Location;

                    if(double.IsPositiveInfinity(v.Value.aPrev) && double.IsPositiveInfinity(v.Value.aNext))
                    {
                        newPoint = new Point(p1.X, p2.Y);
                    }
                    else if (v.Value.aPrev == v.Value.aNext)
                    {
                        if (Math.Abs(v.Value.aNext) > 1)
                            newPoint = new Point((int)((p2.Y - p1.Y) / v.Value.aNext + p1.X), p2.Y);
                        else
                            newPoint = new Point(p2.X, (int)(v.Value.aNext * (p2.X - p1.X) + p1.Y));
                    }
                    else if (double.IsPositiveInfinity(v.Value.aPrev))
                    {
                        newPoint = new Point(p1.X, (int)(v.Value.aNext * (p1.X - p3.X) + p3.Y));
                    }
                    else if (double.IsPositiveInfinity(v.Value.aNext))
                    {
                        newPoint = new Point(p3.X, (int)(v.Value.aPrev * (p3.X - p1.X) + p1.Y));
                    }
                    else
                    {
                        double x = (p1.X * v.Value.aPrev - p3.X * v.Value.aNext + p3.Y - p1.Y) / (v.Value.aPrev - v.Value.aNext);
                        double y = v.Value.aNext * (x - p3.X) + p3.Y;
                        newPoint = new Point((int)x, (int)y);
                    }
                }
                else if (node.Value.IsAngleSet)
                {
                    Point p1 = node.Value.Location, p2 = v.Value.Location;

                    if(double.IsPositiveInfinity(node.Value.aNext))
                    {
                        newPoint = new Point(p1.X, p2.Y);
                    }
                    else if (Math.Abs(node.Value.aNext)>1)
                    {
                        newPoint = new Point((int)((p2.Y - p1.Y) / node.Value.aNext + p1.X), p2.Y);
                    }
                    else if (node.Value.aNext==0)
                    {
                        newPoint = new Point(p2.X, p1.Y);
                    }
                    else
                    {
                        newPoint = new Point(p2.X, (int)(node.Value.aNext * (p2.X - p1.X) + p1.Y));
                    }
                }
                else if (node.Value.IsHorizontal == 1 && v.Value.Location.Y != node.Value.Location.Y)
                {
                    newPoint = new Point(v.Value.Location.X, node.Value.Location.Y);
                }
                else if (node.Value.IsVertical == 1 && v.Value.Location.X != node.Value.Location.X)
                {
                    newPoint = new Point(node.Value.Location.X, v.Value.Location.Y);
                }
                else
                    break;

                if (Distance(v.Value.Location, newPoint) < eps)
                    break;

                v.Value.Location = newPoint;
                node = node.Next != null ? node.Next : Vertices.First;
            }
            node = start;
            for (; i < Vertices.Count; i++)
            {
                v = node.Previous != null ? node.Previous : Vertices.Last;
                if (v.Value.IsAngleSet)
                {
                    Point p1 = node.Value.Location, p2 = v.Value.Location, p3 = v.Previous != null ? v.Previous.Value.Location : Vertices.Last().Location;

                    if (double.IsPositiveInfinity(v.Value.aPrev) && double.IsPositiveInfinity(v.Value.aNext))
                    {
                        newPoint = new Point(p1.X, p2.Y);
                    }
                    else if (v.Value.aPrev == v.Value.aNext)
                    {
                        if (Math.Abs(v.Value.aNext) > 1)
                            newPoint = new Point((int)((p2.Y - p1.Y) / v.Value.aNext + p1.X), p2.Y);
                        else
                            newPoint = new Point(p2.X, (int)(v.Value.aNext * (p2.X - p1.X) + p1.Y));
                    }
                    else if (double.IsPositiveInfinity(v.Value.aNext))
                    {
                        newPoint = new Point(p1.X, (int)(v.Value.aPrev * (p1.X - p3.X) + p3.Y));
                    }
                    else if (double.IsPositiveInfinity(v.Value.aPrev))
                    {
                        newPoint = new Point(p3.X, (int)(v.Value.aNext * (p3.X - p1.X) + p1.Y));
                    }
                    else
                    {
                        double x = (p1.X * v.Value.aNext - p3.X * v.Value.aPrev + p3.Y - p1.Y) / (v.Value.aNext - v.Value.aPrev);
                        double y = v.Value.aPrev * (x - p3.X) + p3.Y;
                        newPoint = new Point((int)x, (int)y);     
                    }
                }
                else if (node.Value.IsAngleSet)
                {
                    Point p1 = node.Value.Location, p2 = v.Value.Location;

                    if (double.IsPositiveInfinity(node.Value.aPrev))
                    {
                        newPoint = new Point(p1.X, p2.Y);
                    }
                    else if (Math.Abs(node.Value.aPrev) > 1)
                    {
                        newPoint = new Point((int)((p2.Y - p1.Y) / node.Value.aPrev + p1.X), p2.Y);
                    }
                    else if (node.Value.aPrev == 0)
                    {
                        newPoint = new Point(p2.X, p1.Y);
                    }
                    else
                    {
                        newPoint = new Point(p2.X, (int)(node.Value.aPrev * (p2.X - p1.X) + p1.Y));
                    }
                }
                else if (node.Value.IsHorizontal == 2 && v.Value.Location.Y != node.Value.Location.Y)
                {
                    newPoint = new Point(v.Value.Location.X, node.Value.Location.Y);
                }
                else if (node.Value.IsVertical == 2 && v.Value.Location.X != node.Value.Location.X)
                {
                    newPoint = new Point(node.Value.Location.X, v.Value.Location.Y);
                }
                else
                    return;

                if (Distance(v.Value.Location, newPoint) < eps)
                    break;

                v.Value.Location = newPoint;
                node = node.Previous != null ? node.Previous : Vertices.Last;
            }
        }
    }

    class Vertice
    {
        public Point Location { get; set; }
        public double ConstantAngle { get; set; }
        public bool IsAngleSet { get; set; }
        public int IsHorizontal { get; set; } // 0 - no, 1 - leftV, 2 - rightV, 3 - both
        public int IsVertical { get; set; } // 0 - no, 1 - leftV, 2 - rightV, 3 - both

        public double aPrev { get; set; }
        public double aNext { get; set; }

        public Vertice(Point location, double constantAngle = 0, bool isAngleSet = false)
        {
            Location = location;
            ConstantAngle = constantAngle;
            IsAngleSet = isAngleSet;
        }
        public Vertice(int x, int y)
        {
            Location = new Point(x, y);
        }
        public bool UpdateCoordinates(Vertice v,bool isVPrev)
        {
            if(isVPrev)
            {
                
            }
            return false;
        }
    }

    class Edge
    {
        public Vertice From { get; set; }
        public Vertice To { get; set; }

        public Edge(Vertice from, Vertice to)
        {
            From = from;
            To = to;
        }

        public static bool operator ==(Edge e1, Edge e2) => (e1.From == e2.From && e1.To == e2.To) || (e1.From == e2.To && e1.To == e2.From);
        public static bool operator !=(Edge e1, Edge e2) => !(e1 == e2);

        public override bool Equals(object obj) => this == (Edge)obj;
        public override int GetHashCode() => From.GetHashCode() * To.GetHashCode();
    }
}
