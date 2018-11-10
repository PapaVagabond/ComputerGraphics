using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filling
{
    public partial class MainForm : Form
    {
        // TODO Change accesability
        private const int D = 6;
        private bool isVerticeSelected = false;
        private (Vertice v, Polygon p) selectedV = (null, null);
        private List<Polygon> Polygons { get; set; }
        private DirectBitmap Picture { get; set; }
        private Color ObjectColor { get; set; }
        private PixelModyfication SceneModyfication { get; set; }
        private Bitmap ObjectTexture { get; set; }
        private bool HasObjectTexture { get; set; } = false;
        private bool BitmapProcessing { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
            Polygons = new List<Polygon>();
            Picture = new DirectBitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height, Color.White);
            SceneModyfication = new PixelModyfication(Picture);
            SceneModyfication.SetLightColor(Color.White);
            SceneModyfication.SetLightSource(new Vector { X = 0, Y = 0, Z = 200 });
            SceneModyfication.SetLightRegular();

            ObjectColor = Color.GreenYellow;
            ObjectTexture = AdjustToFitRectangle(Properties.Resources.dirt_texture, new Size(Picture.Width, Picture.Height));
            SceneModyfication.SetNormalMap(AdjustToFitRectangle(Properties.Resources.normal_map,SceneModyfication.Bitmap.Bitmap.Size));
            pbObjectColor.BackColor = ObjectColor;
            pbObjectTexture.BackgroundImage = AdjustToFitRectangle(ObjectTexture, pbObjectTexture.Size);
            pbNormalMap.BackgroundImage = AdjustToFitRectangle(Properties.Resources.normal_map, pbNormalMap.Size);

            pictureBox.Image = Picture.Bitmap;
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            VerticesTabInit();
            UpdateBitmap();
        }

        private void DrawLine(Color color, Point p1, Point p2)
        {
            // TODO Checking if coordinates are outside bitmap
            int x = p1.X, y = p1.Y, w = p2.X - p1.X, h = p2.Y - p1.Y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                Picture.SetPixel(x, y, color);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        private void UpdateBitmap()
        {
            Picture.Clear();
            foreach (Polygon p in Polygons)
            {
                Vertice prev = p.Vertices[p.Vertices.Length - 1];
                FillPolygon(p);
                foreach (Vertice v in p.Vertices)
                {
                    DrawLine(Color.Black, prev.Location, v.Location);
                    prev = v;
                }
            }
            //Picture.AlterPixels(SceneModyfication.CalculateColor);
            SceneModyfication.AlterPixels();
            pictureBox.Refresh();
        }

        private void VerticesTabInit()
        {
            Point[] vertices = new Point[3];

            vertices[0] = new Point { X = 100, Y = 300 };
            vertices[1] = new Point { X = 360, Y = 350 };
            vertices[2] = new Point { X = 140, Y = 110 };
            Polygons.Add(new Polygon(vertices));

            vertices[0] = new Point { X = 240, Y = 400 };
            vertices[1] = new Point { X = 500, Y = 300 };
            vertices[2] = new Point { X = 380, Y = 160 };
            Polygons.Add(new Polygon(vertices));
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Pen penLine = new Pen(new SolidBrush(Color.Black), 1);
            //Versor light = new Versor { X = 0, Y = 0, Z = 1 };

            //foreach (Polygon p in Polygons)
            //{
            //    Vertice prev = p.Vertices[p.Vertices.Length - 1];
            //    FillPolygon(e.Graphics, p, Color.Green, light);
            //    foreach (Vertice v in p.Vertices)
            //    {
            //        e.Graphics.DrawLine(penLine, prev.Location, v.Location);
            //        prev = v;
            //    }
            //}

            //Bitmap bitmap = new Bitmap(pictureBox.Image);
            //Color c;
            //for (int i = 0; i < pictureBox.Width; i++)
            //{
            //    for (int j = 0; j < pictureBox.Height; j++)
            //    {
            //        c = bitmap.GetPixel(i, j);
            //        //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(c.A, c.R, c.G / 2, c.B / 2)), i, j, 1, 1);
            //        bitmap.SetPixel(i, j, Color.FromArgb(c.A, c.R, c.G / 2, c.B / 2));
            //    }
            //}
            //pictureBox.Image = bitmap;
            //UpdateBitmap();
        }

        private void FillPolygon(Polygon p)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();
            int i = 0, k, maxY = Math.Min(p.YMax, pictureBox.Height);
            Vertice v, prev, next;
            List<Edge> AET = new List<Edge>();
            for (int y = p.YMin + 1; y <= maxY; y++)
            {
                //Consider next and previous vertice, add/remove edges
                while (p.Vertices[p.VerticesSorted[i]].Y == (y - 1))
                {
                    k = p.VerticesSorted[i];
                    v = p.Vertices[k];
                    Edge edge;

                    prev = k == 0 ? p.Vertices[p.Vertices.Length - 1] : p.Vertices[k - 1];
                    if (prev.Y != v.Y)
                    {
                        edge = new Edge
                        {
                            YMax = Math.Max(prev.Y, v.Y),
                            X = prev.Y < v.Y ? prev.X : v.X,
                            Ctg = (double)(prev.X - v.X) / (prev.Y - v.Y),
                            //Next = AET[y]
                        };
                        if (prev.Y >= v.Y)
                            AET.Add(edge);
                        else
                            AET.Remove(edge);
                    }

                    next = k == p.Vertices.Length - 1 ? p.Vertices[0] : p.Vertices[k + 1];
                    if (next.Y != v.Y)
                    {
                        edge = new Edge
                        {
                            YMax = Math.Max(next.Y, v.Y),
                            X = next.Y < v.Y ? next.X : v.X,
                            Ctg = (double)(next.X - v.X) / (next.Y - v.Y),
                            //Next = AET[y]
                        };
                        if (next.Y >= v.Y)
                            AET.Add(edge);
                        else
                            AET.Remove(edge);
                    }

                    i++;
                }
                //Update X, sort edges
                foreach (Edge edge in AET)
                    edge.X += edge.Ctg;

                if (y >= Picture.Height)
                    return;

                if (y >= 0)
                {
                    AET.Sort();
                    //Color proper pixels
                    bool fill = false;
                    Edge e1 = null;
                    foreach (Edge e2 in AET)
                    {
                        if (fill)
                        {
                            for (int j = Math.Max((int)e1.X, 0); j < Math.Min((int)e2.X,Picture.Width); j++)
                            {
                                //g.FillRectangle(Brushes.Green, j, y, 1, 1);
                                Picture.SetPixel(j, y, HasObjectTexture ? ObjectTexture.GetPixel(j, y) : ObjectColor);
                                //Picture.SetPixel(j, y, SceneModyfication.CalculateColor(col, j, y));
                            }
                            fill = false;
                        }
                        else
                            fill = true;
                        e1 = e2;
                    }
                }
            }
            //stopwatch.Stop();
            //Text = stopwatch.ElapsedMilliseconds.ToString();
        }


        //private void FillPolygon(Graphics g, Polygon p, Color col, Versor light)
        //{
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    Pen penLine = new Pen(new SolidBrush(col), 1);

        //    int i = 0, k;
        //    Vertice v, prev, next;
        //    List<Edge> AET = new List<Edge>();
        //    for (int y = p.YMin + 1; y <= p.YMax; y++)
        //    {
        //        //Consider next and previous vertice, add/remove edges
        //        while (p.Vertices[p.VerticesSorted[i]].Y == (y - 1))
        //        {
        //            k = p.VerticesSorted[i];
        //            v = p.Vertices[k];
        //            Edge edge;

        //            prev = k == 0 ? p.Vertices[p.Vertices.Length - 1] : p.Vertices[k - 1];
        //            if (prev.Y != v.Y)
        //            {
        //                edge = new Edge
        //                {
        //                    YMax = Math.Max(prev.Y, v.Y),
        //                    X = prev.Y < v.Y ? prev.X : v.X,
        //                    Ctg = (double)(prev.X - v.X) / (prev.Y - v.Y),
        //                    //Next = AET[y]
        //                };
        //                if (prev.Y >= v.Y)
        //                    AET.Add(edge);
        //                else
        //                    AET.Remove(edge);
        //            }

        //            next = k == p.Vertices.Length - 1 ? p.Vertices[0] : p.Vertices[k + 1];
        //            if (next.Y != v.Y)
        //            {
        //                edge = new Edge
        //                {
        //                    YMax = Math.Max(next.Y, v.Y),
        //                    X = next.Y < v.Y ? next.X : v.X,
        //                    Ctg = (double)(next.X - v.X) / (next.Y - v.Y),
        //                    //Next = AET[y]
        //                };
        //                if (next.Y >= v.Y)
        //                    AET.Add(edge);
        //                else
        //                    AET.Remove(edge);
        //            }

        //            i++;
        //        }
        //        //Update X, sort edges
        //        foreach (Edge edge in AET)
        //            edge.X += edge.Ctg;

        //        if(y>=0)
        //        {
        //            AET.Sort();
        //            //Color proper pixels
        //            bool fill = false;
        //            Edge e1 = null;
        //            foreach (Edge e2 in AET)
        //            {
        //                if (fill)
        //                {
        //                    g.DrawLine(penLine, (float)e1.X, y, (float)e2.X, y);
        //                    //for (int j = (int)e1.X; j < (int)e2.X; j++)
        //                    //{
        //                    //    //g.FillRectangle(Brushes.Green, j, y, 1, 1);
        //                    //    g.DrawLine(penLine, j, y, j + 1, y);
        //                    //}
        //                    fill = false;
        //                }
        //                else
        //                    fill = true;
        //                e1 = e2;
        //            }
        //        }
        //    }
        //    stopwatch.Stop();
        //    Text = stopwatch.ElapsedMilliseconds.ToString();
        //}

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Polygon p in Polygons)
                {
                    foreach (Vertice v in p.Vertices)
                    {
                        if ((e.X - v.X) * (e.X - v.X) + (e.Y - v.Y) * (e.Y - v.Y) < D * D)
                        {
                            selectedV.v = v;
                            selectedV.p = p;
                            isVerticeSelected = true;
                            return;
                        }
                    }

                }

                // Nothing is selected
                selectedV.v = null;
                isVerticeSelected = false;
                //NothingSelected();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isVerticeSelected)
            {
                if (selectedV.v != null)
                {
                    //(int x, int y) = (e.Location.X, e.Location.Y);

                    //if (x < 0)
                    //    x = VR;
                    //else if (x > pictureBox.Width)
                    //    x = pictureBox.Width - VR;

                    //if (y < 0)
                    //    y = VR;
                    //else if (y > pictureBox.Height)
                    //    y = pictureBox.Height - VR;

                    //if (line.visible)
                    //{
                    //    if (line.isVertical)
                    //        x = line.k;
                    //    else
                    //        y = line.k;

                    //    line.visible = false;
                    //}
                    //selectedV.node.Value.Location = new Point(x, y);
                    //pictureBox.Invalidate();
                    selectedV.v = null;
                    isVerticeSelected = false;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isVerticeSelected)
            {
                if (selectedV.v != null)
                {
                    selectedV.v.Location = e.Location;
                    selectedV.p.UpdateProperties();
                    UpdateBitmap();
                }
            }
        }

        private void btnSetLightColour_Click(object sender, EventArgs e)
        {
            DialogResult result = dialogSetLightColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                SceneModyfication.SetLightColor(dialogSetLightColor.Color);
                pbLightColor.BackColor = dialogSetLightColor.Color;
                UpdateBitmap();
            }
        }

        private void btnSetObjectColor_Click(object sender, EventArgs e)
        {
            DialogResult result = dialogSetLightColor.ShowDialog();
            if (result == DialogResult.OK)
            {
                ObjectColor = dialogSetLightColor.Color;
                pbObjectColor.BackColor = dialogSetLightColor.Color;
                UpdateBitmap();
            }
        }

        private void rbObjectColor2_CheckedChanged(object sender, EventArgs e)
        {
            btnSetObjectColor.Enabled = false;
            btnSetObjectTexture.Enabled = true;
            HasObjectTexture = true;
            UpdateBitmap();
        }

        private void btnSetObjectTexture_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                ObjectTexture = AdjustToFitRectangle(img, ObjectTexture.Size);
                pbObjectTexture.BackgroundImage = AdjustToFitRectangle(img, pbObjectTexture.Size);
                UpdateBitmap();
            }
        }

        private Bitmap AdjustToFitRectangle(Image img, Size size)
        {
            int w, h;
            if (img.Width<size.Width && img.Height<size.Height)
            {
                Bitmap srcBmp = new Bitmap(img); 
                Bitmap destBmp = new Bitmap(size.Width, size.Height);
                for(int x=0;x<destBmp.Width;x+=srcBmp.Width)
                {
                    for(int y=0;y<destBmp.Height;y+=srcBmp.Height)
                    {
                        w = Math.Min(img.Width, size.Width - x);
                        h = Math.Min(img.Height, size.Height - y);
                        for(int i=0;i<w;i++)
                            for (int j = 0; j < h; j++)
                                destBmp.SetPixel(x + i, y + j, srcBmp.GetPixel(i, j));
                    }
                }
                return destBmp;
            }
            // TODO other cases
            w = img.Width * size.Height / img.Height;
            if (w >= size.Width)
                h = size.Height;
            else
            {
                w = size.Width;
                h = img.Height * pbObjectTexture.Width / img.Width;
            }
            return CropImage(ResizeImage(img, w, h), new Rectangle(0, 0, w, h));
        }

        private Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void rbObjectColor1_CheckedChanged(object sender, EventArgs e)
        {
            btnSetObjectColor.Enabled = true;
            btnSetObjectTexture.Enabled = false;
            HasObjectTexture = false;
            UpdateBitmap();
        }

        private void rbNormal2_CheckedChanged(object sender, EventArgs e)
        {
            btnSetNormalMap.Enabled = true;
            SceneModyfication.UseNormalMap();
            UpdateBitmap();
        }
    }
}
