﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    class PixelModyfication
    {
        public DirectBitmap Bitmap { get; private set; }
        private Vector LightSource;
        private double[,] DotProducts;
        private Vector[,] NormalVectors;
        public DirectBitmap NormalMap { get; private set; }
        private (double R, double G, double B) LightColor;
        private bool isLightRegular;
        private bool isNormalMapUsed;

        public PixelModyfication(DirectBitmap db)
        {
            Bitmap = db;
            SetLightColor(Color.White);
            DotProducts = new double[db.Width, db.Height];
            NormalVectors = new Vector[db.Width, db.Height];
            for (int i = 0; i < DotProducts.GetLength(0); i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    NormalVectors[i, j] = new Vector(0, 0, 1);
                    DotProducts[i, j] = DotProduct(NormalVectors[i, j], isLightRegular ? GetVersor(new Point(0, 0), LightSource) : GetVersor(new Point(i, j), LightSource));
                }
            }
        }

        public void UseNormalMap()
        {
            if (NormalMap == null)
                return;

            Vector vector;
            for (int i = 0; i < NormalVectors.GetLength(0); i++)
                for (int j = 0; j < NormalVectors.GetLength(1); j++)
                {
                    Color pixel = NormalMap.GetPixel(i, j);
                    //vector = new Vector((double)pixel.R * 2 / 255 - 1, (double)pixel.G * 2 / 255 - 1, (double)pixel.B * 2 / 255 - 1);
                    //NormalVectors[i, j] = GetVersor(vector);
                    NormalVectors[i, j].X = (double)pixel.R * 2 / 255 - 1;
                    NormalVectors[i, j].Y = (double)pixel.G * 2 / 255 - 1;
                    NormalVectors[i, j].Z = (double)pixel.B * 2 / 255 - 1;
                }

            CalculateDots();
        }

        public void UseStandardNormalVectors()
        {
            Vector v = new Vector { X = 0, Y = 0, Z = 1 };
            for (int i = 0; i < NormalVectors.GetLength(0); i++)
                for (int j = 0; j < NormalVectors.GetLength(1); j++)
                    NormalVectors[i, j] = v;
            CalculateDots();
        }

        public void SetNormalMap(Bitmap bmp)
        {
            NormalMap = new DirectBitmap(bmp);
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
        //private void CalculateNormalVectors()
        //{
        //    for (int i = 0; i < NormalMap.Width; i++)
        //        for (int j = 0; j < NormalMap.Height; j++)
        //        {
        //            Color pixel = NormalMap.GetPixel(i, j);
        //            NormalVectors[i, j].X = (double)pixel.R * 2 / 255 - 1;
        //            NormalVectors[i, j].Y = (double)pixel.G * 2 / 255 - 1;
        //            NormalVectors[i, j].Z = (double)pixel.B * 2 / 255 - 1;
        //        }
        //    CalculateDots();
        //}

        private void CalculateDots()
        {
            for (int i = 0; i < DotProducts.GetLength(0); i++)
            {
                for (int j = 0; j < DotProducts.GetLength(1); j++)
                {
                    DotProducts[i, j] = DotProduct(NormalVectors[i, j], isLightRegular ? GetVersor(new Point(0, 0), LightSource) : GetVersor(new Point(i, j), LightSource));
                    if (DotProducts[i, j] > 1)
                        DotProducts[i, j] = 1;
                    else if (DotProducts[i, j] < 0)
                        DotProducts[i, j] = 0;
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

        private Vector GetVersor(Vector v)
        {
            double d = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            return new Vector(v.X / d, v.Y / d, v.Z / d);
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
