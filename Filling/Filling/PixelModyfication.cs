using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    class PixelModyfication
    {
        public Color LightColor { get; set; }
        public Vector LightSource { get; set; }

        public int CalculateColor(Color col, int x, int y)
        {
            // TODO What is right representation of colour?
            Vector l = GetVersor(new Point(x, y), LightSource);
            double dot = DotProduct(GetNormalVersor(x, y), l);
            int r = (int)(LightColor.R * col.R * dot);
            int g = (int)(LightColor.G * col.G * dot);
            int b = (int)(LightColor.B * col.B * dot);
            return Color.FromArgb(col.A, r, g, b).ToArgb();
        }

        private Vector GetVersor(Point from, Vector to)
        {
            Vector res = new Vector { X = to.X - from.X, Y = to.Y - from.Y, Z = to.Z };
            double d = Math.Sqrt(res.X * res.X + res.Y * res.Y + res.Z * res.Z);
            res.X = res.X / d;
            res.Y = res.Y / d;
            res.Z = res.Z / d;
            return res;
        }

        private Vector GetNormalVersor(int x, int y)
        {
            return new Vector(0, 0, 1);
        }

        private double DotProduct(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }
}
