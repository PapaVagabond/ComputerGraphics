using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int BackgroundArgb { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height, Color background)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            BackgroundArgb = background.ToArgb();
        }

        //Not used
        public void AlterPixels(Func<Color, int, int, int> fun)
        {
            for (int i = 0; i < Bits.Length; i++)
                Bits[i] = fun(Color.FromArgb(Bits[i]), 0, 0);

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    //Bits[k] = fun(Color.FromArgb(Bits[k]), i, j);
                    Bits[i + j * Width] = fun(Color.FromArgb(Bits[i + j * Width]), i, j);
                }
            }
        }
        //We assume coordinates are correct
        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            if (index < 0 || index >= Bits.Length)
                return;
            int col = colour.ToArgb();

            Bits[index] = col;
        }
        public void SetPixel(int x, int y, int argb)
        {
            int index = x + (y * Width);
            if (index < 0 || index >= Bits.Length)
                return;
            Bits[index] = argb;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public int GetPixelArgb(int x, int y)
        {
            int index = x + (y * Width);
            return Bits[index];
        }

        public void Clear()
        {
            //Bits = new Int32[Width * Height];
            //Bitmap.Dispose();
            //BitsHandle.Free();
            //BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            //Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            for (int i = 0; i < Bits.Length; i++)
            {
                Bits[i] = BackgroundArgb;
            }
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
