using Filling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOnBezierCurve
{
    public partial class MainForm : Form
    {
        public DirectBitmap Picture { get; set; }
        public BezierCurve Curve { get; set; }
        public Bitmap Img { get; set; }

        private Node selectedNode = null;
        private bool lmbPressed = false;

        private const int VERTICE_R = 5;
        private const int D = 10;
        private const int BEZIER_CURVE_SEGMENTS_COUNT = 40;

        public MainForm()
        {
            InitializeComponent();
            Picture = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = Picture.Bitmap;
            Img = null;
            Curve = new BezierCurve(5, 340, 200, pictureBox.Width);
            UpdateBitmap();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lmbPressed = true;
                foreach (Node node in Curve.Nodes)
                {
                    if ((e.X - node.X) * (e.X - node.X) + (e.Y - node.Y) * (e.Y - node.Y) < D * D)
                    {
                        selectedNode = node;
                        return;
                    }
                }
            }
            selectedNode = null;
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lmbPressed = false;
                if (selectedNode != null)
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

                    selectedNode.Location = new Point(x, y);
                    selectedNode = null;
                    UpdateBitmap();
                }
            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (lmbPressed && selectedNode != null)
            {
                selectedNode.Location = e.Location;
                UpdateBitmap();
            }
        }


        private void DrawPolyline(Graphics g, IEnumerable<Point> points, Color color)
        {
            Pen pen = new Pen(new SolidBrush(color));
            if (points.Count() < 2)
                return;

            Point prev = Point.Empty;
            foreach (Point p in points)
            {
                if (!prev.IsEmpty)
                {
                    g.DrawLine(pen, prev, p);
                }
                prev = p;
            }
        }

        //private void UpdateBitmap()
        //{
        //    pictureBox.Invalidate();
        //}

        //private void pictureBox_Paint(object sender, PaintEventArgs e)
        //{
        //    Pen pen = new Pen(new SolidBrush(Color.Black));
        //    DrawPolyline(e.Graphics, Curve.ControlPoints, Color.LightBlue);
        //    foreach (Point p in Curve.ControlPoints)
        //        e.Graphics.DrawEllipse(pen, p.X - VERTICE_R, p.Y - VERTICE_R, 2 * VERTICE_R, 2 * VERTICE_R);
        //    DrawPolyline(e.Graphics, Curve.CurvePoints(BEZIER_CURVE_SEGMENTS_COUNT), Color.Black);
        //}

        // Using custom functions and direct bitmap

        private void DrawBitmapRotated(DirectBitmap bmp, Bitmap img, Point location, double angle = 0)
        {
            double[,] R = new double[2, 2];
            double cos = Math.Cos(angle), sin = Math.Sin(angle);
            // TODO
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    (int x, int y) = ((int)(cos * i + sin * j), (int)(cos * j - sin * i));
                    if (x >= 0 && y >= 0 && x < img.Width && y < img.Height)
                        bmp.SetPixel(location.X + i, location.Y + j, img.GetPixel(x, y));
                }
            }
        }

        private void DrawCircle(DirectBitmap bmp, Point p, int radius, Color c)
        {
            for (int y = -radius; y <= radius && y < bmp.Height; y++)
                for (int x = -radius; x <= radius && x < bmp.Width; x++)
                    if (x * x + y * y <= radius * radius && x >= 0 && y >= 0)
                        bmp.SetPixel(p.X + x, p.Y + y, c);
        }
        private void DrawLine(Point p1, Point p2, Color color)
        {
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
                if (x >= 0 && x < Picture.Width && y >= 0 && y < Picture.Height)
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
        private void DrawPolyline(IEnumerable<Point> points, Color color)
        {
            if (points.Count() < 2)
                return;

            Point prev = Point.Empty;
            foreach (Point p in points)
            {
                if (!prev.IsEmpty)
                {
                    DrawLine(prev, p, color);
                }
                prev = p;
            }
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawPolyline(Curve.ControlPoints, Color.LightBlue);
            foreach (Point p in Curve.ControlPoints)
                DrawCircle(Picture, p, VERTICE_R, Color.Blue);
            DrawPolyline(Curve.CurvePoints(100), Color.Black);
        }
        private void UpdateBitmap()
        {
            Picture.Clear();

            DrawPolyline(Curve.ControlPoints, Color.LightBlue);
            foreach (Point p in Curve.ControlPoints)
                DrawCircle(Picture, p, VERTICE_R, Color.Blue);
            DrawPolyline(Curve.CurvePoints(BEZIER_CURVE_SEGMENTS_COUNT), Color.Black);

            if(Img!=null)
                DrawBitmapRotated(Picture, Img, new Point(100, 100), 0.5);

            pictureBox.Refresh();
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                pbImage.Image = img;
                Img = (Bitmap)img;
                UpdateBitmap();
            }
        }
    }
}
