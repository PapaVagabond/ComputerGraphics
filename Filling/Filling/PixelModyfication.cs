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
        private DirectBitmap Bitmap;
        private Vector LightSource;
        private double[,] DotProducts;
        private Vector[,] NormalVectors;
        private (double R,double G,double B) LightColor;
        private bool isLightRegular;

        public PixelModyfication(DirectBitmap db)
        {
            Bitmap = db;
            SetLightColor(Color.White);
            DotProducts = new double[db.Width, db.Height];
            NormalVectors = new Vector[db.Width, db.Height];
            for (int i=0;i<DotProducts.GetLength(0);i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    NormalVectors[i,j] = new Vector(0, 0, 1);
                    DotProducts[i, j] = DotProduct(NormalVectors[i, j], isLightRegular ? GetVersor(new Point(0, 0), LightSource) : GetVersor(new Point(i, j), LightSource));
                }
            }
        }

        public void SetLightColor(Color col)
        {
            LightColor = ((double)col.R/255, (double)col.G/255, (double)col.B/255);
        }

        public void SetLightSource(Vector location, bool regular = false)
        {
            isLightRegular = regular;
            LightSource = location;
            CalculateDots();
        }

        private void CalculateDots()
        {
            for (int i = 0; i < DotProducts.GetLength(0); i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    DotProducts[i, j] = DotProduct(NormalVectors[i, j], isLightRegular ? GetVersor(new Point(0,0), LightSource) : GetVersor(new Point(i, j), LightSource));
                }
            }
        }

        public void AlterPixels()
        {
            //for (int i = 0; i < Bitmap.Bits.Length; i++)
            //    Bitmap.Bits[i] = CalculateColor(Color.FromArgb(Bitmap.Bits[i]), 0, 0);

            for (int i = 0; i < Bitmap.Width; i++)
            {
                for (int j = 0; j < Bitmap.Height; j++)
                {
                    //Bits[k] = fun(Color.FromArgb(Bits[k]), i, j);
                    Bitmap.Bits[i + j * Bitmap.Width] = CalculateColor(Color.FromArgb(Bitmap.Bits[i + j * Bitmap.Width]), i, j);
                }
            }
        }

        public int CalculateColor(Color col, int x, int y)
        {
            // TODO What is right representation of colour?
            //Vector l = GetVersor(new Point(x, y), LightSource);
            //double dot = DotProduct(GetNormalVersor(x, y), l);
            int r = (int)(LightColor.R * col.R * DotProducts[x, y]);
            int g = (int)(LightColor.G * col.G * DotProducts[x, y]);
            int b = (int)(LightColor.B * col.B * DotProducts[x, y]);
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
