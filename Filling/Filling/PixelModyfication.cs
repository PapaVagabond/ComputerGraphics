using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    public struct Vector
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
        public override string ToString() => "(" + X.ToString() + "," + Y.ToString() + "," + Z.ToString() + ")";
        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector operator *(Vector v, double k) => new Vector(k * v.X, k * v.Y, k * v.Z);
        public static Vector operator /(Vector v, double k) => new Vector(v.X / k, v.Y / k, v.Z / k);
    }

    public class PixelModyfication
    {
        public DirectBitmap Bitmap { get; private set; }
        public Vector LightSource { get; private set; }
        public DirectBitmap NormalMap { get; private set; }
        public DirectBitmap HeightMap { get; private set; }
        public Point BubbleCentre { get; set; }

        private double[,] DotProducts;
        private Vector[,] NormalVectors;
        private Vector[,] DVectors;
        private Vector[,] NormalPlusDVectors;
        private Vector[,] BubbleNormalVectors;
        private (double R, double G, double B) LightColor;
        private bool isLightRegular = true;
        private bool isBubbleEnabled = false;
        private bool isHeightMapEnabled = false;
        private const int BUBBLE_R = 60;
        private const int BUBBLE_R2 = 60;
        private const int BUBBLE_RSQUARE = BUBBLE_R * BUBBLE_R;
        private const int BUBBLE_R2SQUARE = BUBBLE_R2 * BUBBLE_R2;

        public PixelModyfication(DirectBitmap db)
        {
            Bitmap = db;
            SetLightColor(Color.White);
            DotProducts = new double[db.Width, db.Height];
            NormalVectors = new Vector[db.Width, db.Height];
            DVectors = new Vector[db.Width, db.Height];
            NormalPlusDVectors = new Vector[db.Width, db.Height];
            BubbleNormalVectors = new Vector[2 * BUBBLE_R2, 2 * BUBBLE_R2];
            for (int i = -BUBBLE_R2; i < BUBBLE_R2; i++)
                for (int j = -BUBBLE_R2; j < BUBBLE_R2; j++)
                {
                    int t = i * i + j * j;
                    if (t >= BUBBLE_R2SQUARE)
                        BubbleNormalVectors[BUBBLE_R2 + i, BUBBLE_R2 + j] = new Vector(0, 0, 1);
                    else
                    {
                        Vector v = new Vector(i, j, Math.Sqrt(BUBBLE_RSQUARE + t));
                        v.X /= v.Z;
                        v.Y /= v.Z;
                        v.Z = 1;
                        BubbleNormalVectors[BUBBLE_R2 + i, BUBBLE_R2 + j] = v;
                    }
                }
            for (int i = 0; i < DotProducts.GetLength(0); i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    NormalVectors[i, j] = new Vector(0, 0, 1);
                    DVectors[i, j] = new Vector(0, 0, 0);
                    NormalPlusDVectors[i, j] = GetVersor(NormalVectors[i, j] + DVectors[i, j]);
                    DotProducts[i, j] = DotProduct(NormalVectors[i, j], isLightRegular ? new Vector(0, 0, 1) : GetVersor(new Point(i, j), LightSource));
                }
            }
        }

        public void DisableHeightMap()
        {
            isHeightMapEnabled = false;
            CalculateDVectors();
        }

        public void UseHeightMap()
        {
            if (HeightMap == null)
                return;

            isHeightMapEnabled = true;
            CalculateDVectors();
        }

        public void CalculateDVectors()
        {
            if (!isHeightMapEnabled)
            {
                Vector vertical = new Vector(0, 0, 0);
                for (int i = 0; i < DVectors.GetLength(0) - 1; i++)
                    for (int j = 0; j < DVectors.GetLength(1) - 1; j++)
                        DVectors[i, j] = vertical;
            }
            else
            {
                for (int i = 0; i < DVectors.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < DVectors.GetLength(1) - 1; j++)
                    {
                        // TODO Update this when Normal map changes
                        double pixel = HeightMap.GetPixel(i, j).R;
                        double dhx = HeightMap.GetPixel(i + 1, j).R - pixel;
                        double dhy = HeightMap.GetPixel(i, j + 1).R - pixel;
                        // TODO ip bubble is enabled, normal vectors should be different
                        Vector T = new Vector(1, 0, -NormalVectors[i, j].X);
                        Vector B = new Vector(0, 1, -NormalVectors[i, j].Y);
                        DVectors[i, j] = T * dhx + B * dhy;
                    }
                }
            }
            CalculateNormalPlusDVectors();
        }

        public void EnableBubble()
        {
            isBubbleEnabled = true;
            CalculateNormalVectors();
        }

        public void UseNormalMap()
        {
            if (NormalMap == null)
                return;

            isBubbleEnabled = false;
            CalculateNormalVectors();
        }

        public void UseStandardNormalVectors()
        {
            Vector v = new Vector(0, 0, 1);
            for (int i = 0; i < NormalVectors.GetLength(0); i++)
                for (int j = 0; j < NormalVectors.GetLength(1); j++)
                    NormalVectors[i, j] = v;

            isBubbleEnabled = false;
            CalculateDVectors();
            CalculateNormalVectors();
            CalculateDots();
        }

        public void SetNormalMap(Bitmap bmp)
        {
            NormalMap = new DirectBitmap(bmp);
        }

        public void SetHeightMap(Bitmap bmp)
        {
            HeightMap = new DirectBitmap(bmp);
        }

        public void SetLightColor(Color col)
        {
            LightColor = ((double)col.R / 255, (double)col.G / 255, (double)col.B / 255);
        }

        public void SetLightSource(Vector location, bool regular = false)
        {
            isLightRegular = regular;
            LightSource = location;
            CalculateDots();
        }

        public void SetLightRegular()
        {
            isLightRegular = true;
            CalculateDots();
        }

        private void CalculateNormalVectors()
        {
            if (isBubbleEnabled)
            {
                Vector vertical = new Vector(0, 0, 1);
                for (int i = 0; i < NormalVectors.GetLength(0); i++)
                    for (int j = 0; j < NormalVectors.GetLength(1); j++)
                        NormalVectors[i, j] = vertical;

                int iMax = NormalPlusDVectors.GetLength(0) - BubbleCentre.X < BUBBLE_R2 ? BUBBLE_R2 + NormalPlusDVectors.GetLength(0) - BubbleCentre.X : 2 * BUBBLE_R2;
                int jMax = NormalPlusDVectors.GetLength(1) - BubbleCentre.Y < BUBBLE_R2 ? BUBBLE_R2 + NormalPlusDVectors.GetLength(1) - BubbleCentre.Y : 2 * BUBBLE_R2;

                // TODO can be better
                for (int i = BubbleCentre.X - BUBBLE_R2 < 0 ? BUBBLE_R2 - BubbleCentre.X : 0; i < iMax; i++)
                    for (int j = BubbleCentre.Y - BUBBLE_R2 < 0 ? BUBBLE_R2 - BubbleCentre.Y : 0; j < jMax; j++)
                        if ((i - BUBBLE_R2) * (i - BUBBLE_R2) + (j - BUBBLE_R2) * (j - BUBBLE_R2) < BUBBLE_R2SQUARE)
                            NormalVectors[BubbleCentre.X - BUBBLE_R2 + i, BubbleCentre.Y - BUBBLE_R2 + j] = BubbleNormalVectors[i, j];
            }
            else
            {
                for (int i = 0; i < NormalVectors.GetLength(0); i++)
                    for (int j = 0; j < NormalVectors.GetLength(1); j++)
                    {
                        Color pixel = NormalMap.GetPixel(i, j);
                        //vector = new Vector((double)pixel.R * 2 / 255 - 1, (double)pixel.G * 2 / 255 - 1, (double)pixel.B * 2 / 255 - 1);
                        //NormalVectors[i, j] = GetVersor(vector);
                        NormalVectors[i, j].X = (double)pixel.R * 2 / 255 - 1;
                        NormalVectors[i, j].Y = (double)pixel.G * 2 / 255 - 1;
                        NormalVectors[i, j].Z = (double)pixel.B * 2 / 255 - 1;
                        if (NormalVectors[i, j].Z != 0)
                            NormalVectors[i, j] /= NormalVectors[i, j].Z;
                    }
            }
            if (isHeightMapEnabled)
                CalculateDVectors();
            else
                CalculateNormalPlusDVectors();
        }

        private void CalculateNormalPlusDVectors()
        {
            //if (isBubbleEnabled)
            //{
            //    Vector vertical = new Vector(0, 0, 1);
            //    for (int i = 0; i < DotProducts.GetLength(0); i++)
            //        for (int j = 0; j < DotProducts.GetLength(1); j++)
            //            NormalPlusDVectors[i, j] = GetVersor(vertical + DVectors[i, j]);

            //    int iMax = NormalPlusDVectors.GetLength(0) - BubbleCentre.X < BUBBLE_R2 ? BUBBLE_R2 + NormalPlusDVectors.GetLength(0) - BubbleCentre.X : 2 * BUBBLE_R2;
            //    int jMax = NormalPlusDVectors.GetLength(1) - BubbleCentre.Y < BUBBLE_R2 ? BUBBLE_R2 + NormalPlusDVectors.GetLength(1) - BubbleCentre.Y : 2 * BUBBLE_R2;

            //    // TODO it should be for each point in circle, not foreach point in square
            //    for (int i = BubbleCentre.X - BUBBLE_R2 < 0 ? BUBBLE_R2 - BubbleCentre.X : 0; i < iMax; i++)
            //        for (int j = BubbleCentre.Y - BUBBLE_R2 < 0 ? BUBBLE_R2 - BubbleCentre.Y : 0; j < jMax; j++)
            //            NormalPlusDVectors[BubbleCentre.X - BUBBLE_R2 + i, BubbleCentre.Y - BUBBLE_R2 + j] = GetVersor(BubbleNormalVectors[i, j] + DVectors[i, j]);
            //}
            //else
            //    for (int i = 0; i < DotProducts.GetLength(0); i++)
            //        for (int j = 0; j < DotProducts.GetLength(1); j++)
            //            NormalPlusDVectors[i, j] = GetVersor(NormalVectors[i, j] + DVectors[i, j]);
            for (int i = 0; i < DotProducts.GetLength(0); i++)
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                    NormalPlusDVectors[i, j] = GetVersor(NormalVectors[i, j] + DVectors[i, j]);

            CalculateDots();
        }

        private void CalculateDots()
        {
            Vector vertical = new Vector(0, 0, 1);
            for (int i = 0; i < DotProducts.GetLength(0); i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    DotProducts[i, j] = DotProduct(NormalPlusDVectors[i, j], isLightRegular ? vertical : GetVersor(new Point(i, j), LightSource));
                    //if (DotProducts[i, j] > 1)
                    //    DotProducts[i, j] = 1;
                    //else if (DotProducts[i, j] < 0)
                    //    DotProducts[i, j] = 0;
                    if (DotProducts[i, j] < 0)
                        DotProducts[i, j] = 0;
                }
            }
        }

        //public void AlterPixels()
        //{
        //    //for (int i = 0; i < Bitmap.Bits.Length; i++)
        //    //    Bitmap.Bits[i] = CalculateColor(Color.FromArgb(Bitmap.Bits[i]), 0, 0);

        //    for (int i = 0; i < Bitmap.Width; i++)
        //    {
        //        for (int j = 0; j < Bitmap.Height; j++)
        //        {
        //            //Bits[k] = fun(Color.FromArgb(Bits[k]), i, j);
        //            Bitmap.Bits[i + j * Bitmap.Width] = CalculateColor(Color.FromArgb(Bitmap.Bits[i + j * Bitmap.Width]), i, j);
        //        }
        //    }
        //}

        public int CalculateColor(Color col, int x, int y)
        {
            int r = (int)(LightColor.R * col.R * DotProducts[x, y]);
            int g = (int)(LightColor.G * col.G * DotProducts[x, y]);
            int b = (int)(LightColor.B * col.B * DotProducts[x, y]);

            return Color.FromArgb(col.A, r, g, b).ToArgb();
        }

        private Vector GetVersor(Vector v)
        {
            double d = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            if (d == 0)
                return v;
            return new Vector(v.X / d, v.Y / d, v.Z / d);
        }

        private Vector GetVersor(Point from, Vector to)
        {
            Vector res = new Vector { X = to.X - from.X, Y = to.Y - from.Y, Z = to.Z };
            double d = Math.Sqrt(res.X * res.X + res.Y * res.Y + res.Z * res.Z);
            if (d == 0)
                return res;
            res.X = res.X / d;
            res.Y = res.Y / d;
            res.Z = res.Z / d;
            return res;
        }

        private double DotProduct(Vector v1, Vector v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }
}
