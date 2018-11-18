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
        private bool hasObjectTexture = false;
        private bool shiftPressed = false;
        private bool lmbPressed = false;
        private bool isBubbleEnabled = false;
        private Point lastMousePosition = MousePosition;
        private (Vertice v, Polygon p) selectedV = (null, null);
        private Polygon selectedPolygon = null;
        public List<Polygon> Polygons { get; set; }
        public DirectBitmap Picture { get; set; }
        public Color ObjectColor { get; set; }
        public Bitmap ObjectTexture { get; set; }
        public PixelModyfication SceneModyfication { get; set; }
        public PointAnimation LightAnimation { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Polygons = new List<Polygon>();
            Picture = new DirectBitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            LightAnimation = new PointAnimation(new Point(Picture.Width / 2, Picture.Height / 2), 200, 10);

            SceneModyfication = new PixelModyfication(Picture);
            SceneModyfication.SetLightColor(Color.White);
            SceneModyfication.SetLightSource(new Vector(0, 0, 400));
            SceneModyfication.SetLightRegular();

            ObjectColor = Color.GreenYellow;
            ObjectTexture = AdjustToFitRectangle(Properties.Resources.dirt_texture, new Size(Picture.Width, Picture.Height), true);
            SceneModyfication.SetNormalMap(AdjustToFitRectangle(Properties.Resources.normal_map, SceneModyfication.Bitmap.Size));
            SceneModyfication.SetHeightMap(AdjustToFitRectangle(Properties.Resources.brick_heightmap, SceneModyfication.Bitmap.Size));

            pbObjectColor.BackColor = ObjectColor;
            pbObjectTexture.BackgroundImage = AdjustToFitRectangle(ObjectTexture, pbObjectTexture.Size);
            pbNormalMap.BackgroundImage = AdjustToFitRectangle(Properties.Resources.normal_map, pbNormalMap.Size);
            pbHeightMap.BackgroundImage = AdjustToFitRectangle(Properties.Resources.brick_heightmap, pbHeightMap.Size);

            pictureBox.Image = Picture.Bitmap;
            VerticesTabInit();
            UpdateBitmap();
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
            //SceneModyfication.AlterPixels();
            pictureBox.Refresh();
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
        private void FillPolygon(Polygon p)
        {
            int i = 0, k, maxY = Math.Min(p.YMax, pictureBox.Height);
            Vertice v, prev, next;
            List<Edge> AET = new List<Edge>();
            for (int y = p.YMin + 1; y <= maxY; y++)
            {
                //Consider next and previous vertice, add/remove edges
                while (i < p.Vertices.Count() && p.Vertices[p.VerticesSorted[i]].Y == (y - 1))
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
                            for (int j = Math.Max((int)e1.X, 0); j < Math.Min((int)e2.X, Picture.Width); j++)
                            {
                                Picture.SetPixel(j, y, SceneModyfication.CalculateColor(hasObjectTexture ? ObjectTexture.GetPixel(j, y) : ObjectColor, j, y));
                            }
                            fill = false;
                        }
                        else
                            fill = true;
                        e1 = e2;
                    }
                }
            }
        }
        private bool IsPointInsidePolygon(Polygon p, Point point)
        {
            Vertice[] vertices = p.Vertices;
            int i, j;
            bool c = false;
            for (i = 0, j = vertices.Length - 1; i < vertices.Length; j = i++)
            {
                if (((vertices[i].Y > point.Y) != (vertices[j].Y > point.Y)) &&
                    (point.X < (vertices[j].X - vertices[i].X) * (point.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))
                    c = !c;
            }
            return c;
        }

        private Bitmap AdjustToFitRectangle(Image img, Size size, bool tiles = false)
        {
            int w, h;
            if (img.Width < size.Width || img.Height < size.Height)
            {
                Bitmap srcBmp;
                if (img.Width < size.Width && img.Height < size.Height && tiles)
                    srcBmp = new Bitmap(img);
                else if (img.Width < size.Width)
                    srcBmp = ResizeImage(img, img.Width * size.Height / img.Height, size.Height);
                else
                    srcBmp = ResizeImage(img, size.Width, img.Height * pbObjectTexture.Width / img.Width);

                Bitmap destBmp = new Bitmap(size.Width, size.Height);
                for (int x = 0; x < destBmp.Width; x += srcBmp.Width)
                {
                    for (int y = 0; y < destBmp.Height; y += srcBmp.Height)
                    {
                        w = Math.Min(srcBmp.Width, size.Width - x);
                        h = Math.Min(srcBmp.Height, size.Height - y);
                        for (int i = 0; i < w; i++)
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
        private Point GetPointOnBitmap(Point p)
        {
            int x = p.X, y = p.Y;
            if (x < 0)
                x = 0;
            else if (x >= Picture.Width)
                x = Picture.Width - 1;
            if (y < 0)
                y = 0;
            else if (y >= Picture.Height)
                y = Picture.Height - 1;
            return new Point(x, y);
        }

        #region Mouse & Keyboard events handlers

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lmbPressed = true;
                bool mouseOnPoly = false;
                foreach (Polygon p in Polygons)
                {
                    if (shiftPressed && !mouseOnPoly && IsPointInsidePolygon(p, e.Location))
                    {
                        selectedPolygon = p;
                        mouseOnPoly = true;
                    }
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
                if (!mouseOnPoly)
                    selectedPolygon = null;
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lmbPressed = false;
                if (isVerticeSelected && selectedV.v != null)
                {
                    (int x, int y) = (e.Location.X, e.Location.Y);

                    if (x < 0)
                        x = 0;
                    else if (x > pictureBox.Width)
                        x = pictureBox.Width - 1;

                    if (y < 0)
                        y = 0;
                    else if (y > pictureBox.Height)
                        y = pictureBox.Height - 1;

                    selectedV.v.Location = new Point(x, y);
                    selectedV.v = null;
                    isVerticeSelected = false;
                    UpdateBitmap();
                }
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (shiftPressed && lmbPressed && selectedPolygon != null)
            {
                Point delta = new Point(e.X - lastMousePosition.X, e.Y - lastMousePosition.Y);
                foreach (Vertice v in selectedPolygon.Vertices)
                    v.Location = new Point(v.X + delta.X, v.Y + delta.Y);

                selectedPolygon.YMin = selectedPolygon.Vertices[selectedPolygon.VerticesSorted[0]].Y;
                selectedPolygon.YMax = selectedPolygon.Vertices[selectedPolygon.VerticesSorted[selectedPolygon.VerticesSorted.Length - 1]].Y;
                UpdateBitmap();
            }
            else if (isVerticeSelected)
            {
                if (selectedV.v != null)
                {
                    selectedV.v.Location = e.Location;
                    selectedV.p.UpdateProperties();
                    UpdateBitmap();
                }
            }
            lastMousePosition = e.Location;
            if(isBubbleEnabled)
            {
                SceneModyfication.BubbleCentre = GetPointOnBitmap(lastMousePosition);
                SceneModyfication.EnableBubble();
                UpdateBitmap();
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                shiftPressed = true;
        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                shiftPressed = false;
        }

        #endregion

        #region Button/Radiobutton click handlers

        private void rbObjectColor1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            btnSetObjectColor.Enabled = true;
            btnSetObjectTexture.Enabled = false;
            hasObjectTexture = false;
            UpdateBitmap();
        }
        private void rbObjectColor2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            btnSetObjectColor.Enabled = false;
            btnSetObjectTexture.Enabled = true;
            hasObjectTexture = true;
            UpdateBitmap();
        }
        private void rbD1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            btnSetHeightMap.Enabled = false;
            SceneModyfication.DisableHeightMap();
            UpdateBitmap();
        }
        private void rbD2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            btnSetHeightMap.Enabled = true;
            SceneModyfication.UseHeightMap();
            UpdateBitmap();
        }
        private void rbNormal1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            isBubbleEnabled = false;
            btnSetNormalMap.Enabled = false;
            SceneModyfication.UseStandardNormalVectors();
            UpdateBitmap();
        }
        private void rbNormal2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            btnSetNormalMap.Enabled = false;
            isBubbleEnabled = true;
            SceneModyfication.BubbleCentre = GetPointOnBitmap(lastMousePosition);
            SceneModyfication.EnableBubble();
            UpdateBitmap();
        }
        private void rbNormal3_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            isBubbleEnabled = false;
            btnSetNormalMap.Enabled = true;
            SceneModyfication.UseNormalMap();
            UpdateBitmap();
        }
        private void rbLightSource1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            timerAnimateLight.Enabled = false;
            SceneModyfication.SetLightSource(new Vector(0, 0, 100), true);
            UpdateBitmap();
        }
        private void rbLightSource2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;

            SceneModyfication.SetLightSource(new Vector(0, 0, 100));
            UpdateBitmap();
            timerAnimateLight.Enabled = true;
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
        private void btnSetObjectTexture_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                ObjectTexture = AdjustToFitRectangle(img, ObjectTexture.Size, true);
                pbObjectTexture.BackgroundImage = AdjustToFitRectangle(img, pbObjectTexture.Size);
                UpdateBitmap();
            }
        }
        private void btnSetNormalMap_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                SceneModyfication.SetNormalMap(AdjustToFitRectangle(img, Picture.Bitmap.Size));
                pbNormalMap.BackgroundImage = AdjustToFitRectangle(img, pbNormalMap.Size);
                SceneModyfication.UseNormalMap();
                UpdateBitmap();
            }
        }
        private void btnSetHeightMap_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                SceneModyfication.SetHeightMap(AdjustToFitRectangle(img, Picture.Bitmap.Size));
                pbHeightMap.BackgroundImage = AdjustToFitRectangle(img, pbNormalMap.Size);
                SceneModyfication.UseHeightMap();
                UpdateBitmap();
            }
        }

        #endregion

        private void timerAnimateLight_Tick(object sender, EventArgs e)
        {
            SceneModyfication.SetLightSource(LightAnimation.GetNext());
            UpdateBitmap();
        }
    }
}
