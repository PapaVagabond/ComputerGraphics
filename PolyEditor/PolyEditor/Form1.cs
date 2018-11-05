using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyEditor
{
    public partial class MainForm : Form
    {
        private List<Polygon> Polygons;
        private const int VR = 3, FR = 100;
        private const int D = 2 * VR;
        private const int ICON_DIST = 10;
        private const int ICON_HALFSIZE = 6;
        private Image iconEdgeHorizontal;
        private Image iconEdgeVertical;
        private Image iconConstantAngle;
        private bool lmbPressed = false;
        private bool shiftPressed = false;
        private bool drawingPoly = false;
        private List<Vertice> newPoly = null;
        private Point mouseLocation;
        private Point mouseDelta;
        private (bool visible, bool isVertical, int k) line = (false, false, 0);
        private (Polygon p, LinkedListNode<Vertice> node) selectedV = (null, null);
        private (Polygon p, Point middle, LinkedListNode<Vertice> node) selectedE = (null, new Point(), null); // the edge connects node and node.Next

        private Point lastPos;

        public MainForm()
        {
            Polygons = new List<Polygon>();
            InitializeComponent();
            Size size = new Size(2 * ICON_HALFSIZE, 2 * ICON_HALFSIZE);
            iconEdgeHorizontal = (Image)(new Bitmap(Properties.Resources.edge_horizontal, size));
            iconEdgeVertical = (Image)(new Bitmap(Properties.Resources.edge_vertical, size));
            iconConstantAngle = (Image)(new Bitmap(Properties.Resources.angle, size));
            AddPredefinedPolygon();
        }

        private Point pbCentre => new Point(pictureBox.Width / 2, pictureBox.Height / 2);

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Brush vBrush = new SolidBrush(Color.LightSeaGreen);
            Pen penLine = new Pen(new SolidBrush(Color.Black), 1);

            Font font = new Font("Arial", 10);
            Brush black = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            foreach (Polygon p in Polygons)
            {
                if (p.Visible)
                {
                    Vertice lastV = null;
                    foreach (Vertice v in p.Vertices)
                    {
                        if (lastV != null)
                        {
                            //e.Graphics.DrawLine(penLine, lastV.Location, v.Location);
                            DrawLine(black, e.Graphics, lastV.Location, v.Location);
                            if (lastV.IsHorizontal == 1)
                                e.Graphics.DrawImage(iconEdgeHorizontal, GetEdgeIconLocation(lastV, v));
                            else if (lastV.IsVertical == 1)
                                e.Graphics.DrawImage(iconEdgeVertical, GetEdgeIconLocation(lastV, v));
                        }
                        lastV = v;
                    }

                    //e.Graphics.DrawLine(penLine, lastV.Location, p.Vertices.First().Location);
                    DrawLine(black, e.Graphics, lastV.Location, p.Vertices.First().Location);

                    if (lastV.IsHorizontal == 1)
                        e.Graphics.DrawImage(iconEdgeHorizontal, GetEdgeIconLocation(lastV, p.Vertices.First()));
                    else if (lastV.IsVertical == 1)
                        e.Graphics.DrawImage(iconEdgeVertical, GetEdgeIconLocation(lastV, p.Vertices.First()));

                    foreach (Vertice v in p.Vertices)
                    {
                        e.Graphics.FillEllipse(vBrush, v.Location.X - VR, v.Location.Y - VR, D, D);
                        if (v.IsAngleSet)
                        {
                            Point pos = GetVerticeIconLocation(v, 1);
                            e.Graphics.DrawImage(iconConstantAngle, pos);
                            e.Graphics.DrawString(v.ConstantAngle.ToString() + '°', font, black, pos.X + 2 * ICON_HALFSIZE, pos.Y);
                        }
                    }
                }
            }
            if(drawingPoly && newPoly != null)
            {
                Vertice lastV = null;
                foreach (Vertice v in newPoly)
                {
                    if (lastV != null)
                    {
                        //e.Graphics.DrawLine(penLine, lastV.Location, v.Location);
                        DrawLine(black, e.Graphics, lastV.Location, v.Location);
                    }
                    lastV = v;
                }
                if(lastV!=null)
                    DrawLine(black, e.Graphics, lastV.Location, mouseLocation);

                foreach(Vertice v in newPoly)
                {
                    e.Graphics.FillEllipse(vBrush, v.Location.X - VR, v.Location.Y - VR, D, D);
                }
            }
            if(line.visible)
            {
                penLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                if (line.isVertical)
                    e.Graphics.DrawLine(penLine, line.k, 0, line.k, pictureBox.Height);
                else
                    e.Graphics.DrawLine(penLine, 0, line.k, pictureBox.Width, line.k);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // TODO - Firstly we should chceck all vertices, then edges
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                lmbPressed = true;
                if (drawingPoly && e.X >= VR && e.Y >= VR && e.X <= pictureBox.Width - VR && e.Y <= pictureBox.Height - VR)
                {
                    if (newPoly == null)
                    {
                        newPoly = new List<Vertice>();
                        newPoly.Add(new Vertice(e.Location));
                        mouseLocation = e.Location;
                    }
                    else if ((e.X - newPoly.First().Location.X) * (e.X - newPoly.First().Location.X) + (e.Y - newPoly.First().Location.Y) * (e.Y - newPoly.First().Location.Y) < D * D)
                    {
                        AddPolygon(new Polygon(newPoly));
                        newPoly = null;
                        drawingPoly = false;
                        line.visible = false;
                    }
                    else
                    {
                        (int x, int y) = (e.X, e.Y);
                        if (line.visible)
                        {
                            if (line.isVertical)
                                x = line.k;
                            else
                                y = line.k;

                            line.visible = false;
                        }
                        newPoly.Add(new Vertice(x, y));
                    }
                    pictureBox.Invalidate();
                    return;
                }

                lastPos = e.Location;
                foreach (Polygon p in Polygons)
                {
                    if(p.Visible)
                    {
                        if (p.Vertices.Count < 2)
                            continue;

                        LinkedListNode<Vertice> node = p.Vertices.First, lastNode = p.Vertices.Last;
                        Vertice v, lastV = lastNode.Value;

                        if ((e.X - lastV.Location.X) * (e.X - lastV.Location.X) + (e.Y - lastV.Location.Y) * (e.Y - lastV.Location.Y) < D * D)
                        {
                            selectedV = (p, lastNode);
                            VerticeSelected();
                            lmbPressed = true;
                            return;
                        }
                        while (node != null)
                        {
                            v = node.Value;
                            if ((e.X - v.Location.X) * (e.X - v.Location.X) + (e.Y - v.Location.Y) * (e.Y - v.Location.Y) < D * D)
                            {
                                selectedV = (p, node);
                                VerticeSelected();
                                lmbPressed = true;
                                return;
                            }
                            else if (lastV != null && IsPointOnEdge(e.Location, lastV.Location, v.Location))
                            {
                                selectedE = (p, new Point((lastV.Location.X + v.Location.X) / 2, (lastV.Location.Y + v.Location.Y) / 2), lastNode);
                                if (e.Button == MouseButtons.Left)
                                    EdgeSelected();
                                else if (e.Button == MouseButtons.Right)
                                    AddVerticeOnSelectedEdge();
                                return;
                            }
                            lastNode = node;
                            lastV = lastNode.Value;
                            node = node.Next;
                        }
                    }
                }
                // Nothing is selected
                NothingSelected();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lmbPressed && !drawingPoly)
            {
                lmbPressed = false;
                if (selectedV.node != null)
                {
                    (int x, int y) = (e.Location.X, e.Location.Y);

                    if (x < 0)
                        x = VR;
                    else if (x > pictureBox.Width)
                        x = pictureBox.Width - VR;

                    if (y < 0)
                        y = VR;
                    else if (y > pictureBox.Height)
                        y = pictureBox.Height - VR;

                    if(line.visible)
                    {
                        if (line.isVertical)
                            x = line.k;
                        else
                            y = line.k;

                        line.visible = false;
                    }
                    selectedV.node.Value.Location = new Point(x, y);
                    selectedV.p.UpdateVertices(selectedV.node);
                    pictureBox.Invalidate();
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingPoly)
            {
                mouseLocation = e.Location;
                if (newPoly != null)
                    FindLine(e.Location, newPoly);
                pictureBox.Invalidate();
            }
            else if (lmbPressed)
            {
                if(shiftPressed && Polygons.Count > 0 && listBoxPolygons.Items.Count > 0)
                {
                    mouseDelta = new Point(e.X - lastPos.X, e.Y - lastPos.Y);
                    lastPos = e.Location;
                    Polygon p = listBoxPolygons.SelectedItem as Polygon;
                    foreach (Vertice v in p.Vertices)
                        v.Location = new Point(v.Location.X + mouseDelta.X, v.Location.Y + mouseDelta.Y);
                    pictureBox.Invalidate();
                    return;
                }
                if(listBoxPolygons.Items.Count > 0)
                    FindLine(e.Location, (listBoxPolygons.SelectedItem as Polygon).Vertices);

                if (selectedV.node != null)
                {
                    selectedV.node.Value.Location = e.Location;
                    selectedV.p.UpdateVertices(selectedV.node);
                }
                lastPos = e.Location;

                pictureBox.Invalidate();
            }
        }

        private void listBoxPolygons_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.FromArgb(255, 245, 204));

            e.DrawBackground();

            Font font = new Font("Arial", 18, FontStyle.Regular);
            RectangleF rectF = new RectangleF(e.Bounds.X + 30, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.Index >= 0)
            {
                Polygon p = (sender as ListBox).Items[e.Index] as Polygon;
                Image img = p.Visible ? global::PolyEditor.Properties.Resources.eye_green : global::PolyEditor.Properties.Resources.eye_black;
                e.Graphics.DrawString(p.Name.ToString(),
                font, Brushes.Black, rectF, StringFormat.GenericDefault);
                e.Graphics.DrawImage(img, new Point(e.Bounds.X + 4, e.Bounds.Y + 2));
            }
        }

        private void listBoxPolygons_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                shiftPressed = true;
                pictureBox.Cursor = Cursors.Cross;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                int k = listBoxPolygons.SelectedIndex;
                if (k >= 0)
                {
                    Polygons.RemoveAt(k);
                    listBoxPolygons.Items.RemoveAt(k);
                    listBoxPolygons.SelectedIndex = k < listBoxPolygons.Items.Count ? k : k - 1;
                    pictureBox.Invalidate();
                }
            }
        }

        private void listBoxPolygons_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Polygon p = (sender as ListBox).SelectedItem as Polygon;
                if (p != null)
                {
                    p.Visible = !p.Visible;
                    pictureBox.Invalidate();
                    listBoxPolygons.Invalidate();
                }
            }
        }

        #region Button click handlers

        private void tsBtnTriangle_Click(object sender, EventArgs e)
        {
            Point centre = pbCentre;
            int r = FR;
            int xd = (int)(r * Math.Sqrt(3) / 2);
            int yd = r / 2;

            List<Vertice> vertices = new List<Vertice>();
            vertices.Add(new Vertice(centre.X - xd, centre.Y + yd));
            vertices.Add(new Vertice(centre.X + xd, centre.Y + yd));
            vertices.Add(new Vertice(centre.X, centre.Y - r));

            AddPolygon(new Polygon(vertices));
        }

        private void tsBtnSquare_Click(object sender, EventArgs e)
        {
            Point centre = pbCentre;
            int r = FR;
            int a = (int)(r * Math.Sqrt(2) / 2);

            List<Vertice> vertices = new List<Vertice>();

            vertices.Add(new Vertice(centre.X - a, centre.Y + a));
            vertices.Add(new Vertice(centre.X + a, centre.Y + a));
            vertices.Add(new Vertice(centre.X + a, centre.Y - a));
            vertices.Add(new Vertice(centre.X - a, centre.Y - a));

            AddPolygon(new Polygon(vertices));
        }

        private void tsBtnPentagon_Click(object sender, EventArgs e)
        {
            Point centre = pbCentre;
            int r = FR;
            int a = (int)((r / 4) * Math.Sqrt(10 - 2 * Math.Sqrt(5)));
            double h = Math.Sqrt(r * r - a * a);
            double h2 = 2 * a * h / r;
            int dy = (int)Math.Sqrt(r * r - h2 * h2);

            List<Vertice> vertices = new List<Vertice>();
            vertices.Add(new Vertice(centre.X - a, centre.Y + (int)h));
            vertices.Add(new Vertice(centre.X + a, centre.Y + (int)h));
            vertices.Add(new Vertice(centre.X + (int)h2, centre.Y - dy));
            vertices.Add(new Vertice(centre.X, centre.Y - r));
            vertices.Add(new Vertice(centre.X - (int)h2, centre.Y - dy));

            AddPolygon(new Polygon(vertices));
        }

        private void tsBtnHexagon_Click(object sender, EventArgs e)
        {
            Point centre = pbCentre;
            int r = FR;
            int h = (int)(r * Math.Sqrt(3) / 2);

            List<Vertice> vertices = new List<Vertice>();
            vertices.Add(new Vertice(centre.X, centre.Y + r));
            vertices.Add(new Vertice(centre.X + h, centre.Y + r / 2));
            vertices.Add(new Vertice(centre.X + h, centre.Y - r / 2));
            vertices.Add(new Vertice(centre.X, centre.Y - r));
            vertices.Add(new Vertice(centre.X - h, centre.Y - r / 2));
            vertices.Add(new Vertice(centre.X - h, centre.Y + r / 2));

            AddPolygon(new Polygon(vertices));
        }

        private void tsBtnSetEdgeHorizontal_Click(object sender, EventArgs e)
        {
            var nextNode = selectedE.node.Next != null ? selectedE.node.Next : selectedE.p.Vertices.First;
            // Set
            if (selectedE.node.Value.IsHorizontal == 0)
            {
                selectedE.node.Value.IsHorizontal = 1;
                nextNode.Value.IsHorizontal = 2;
                if (selectedE.node.Value.IsVertical == 1)
                {
                    selectedE.node.Value.IsVertical = 0;
                    nextNode.Value.IsVertical = 0;
                }
                selectedE.p.UpdateVertices(selectedE.node);
                pictureBox.Invalidate();
            }
            // Unset
            else if (selectedE.node.Value.IsHorizontal == 1)
            {
                selectedE.node.Value.IsHorizontal = 0;
                nextNode.Value.IsHorizontal = 0;
                pictureBox.Invalidate();
            }
        }

        private void tsBtnSetEdgeVertical_Click(object sender, EventArgs e)
        {
            var nextNode = selectedE.node.Next != null ? selectedE.node.Next : selectedE.p.Vertices.First;
            // Set
            if (selectedE.node.Value.IsVertical == 0)
            {
                selectedE.node.Value.IsVertical = 1;
                nextNode.Value.IsVertical = 2;
                if (selectedE.node.Value.IsHorizontal == 1)
                {
                    selectedE.node.Value.IsHorizontal = 0;
                    nextNode.Value.IsHorizontal = 0;
                }
                selectedE.p.UpdateVertices(selectedE.node);
                pictureBox.Invalidate();
            }
            // Unset
            else if (selectedE.node.Value.IsVertical == 1)
            {
                selectedE.node.Value.IsVertical = 0;
                nextNode.Value.IsVertical = 0;
                pictureBox.Invalidate();
            }
        }

        private void tsBtnConstAngle_Click(object sender, EventArgs e)
        {
            // Calculate angle
            if (!selectedV.node.Value.IsAngleSet)
            {
                Point p1 = selectedV.node.Previous != null ? selectedV.node.Previous.Value.Location : selectedV.p.Vertices.Last().Location,
                        p2 = selectedV.node.Value.Location,
                        p3 = selectedV.node.Next != null ? selectedV.node.Next.Value.Location : selectedV.p.Vertices.First().Location;

                if (p1.X == p2.X)
                    selectedV.node.Value.aPrev = double.PositiveInfinity;
                else
                    selectedV.node.Value.aPrev = (double)(p2.Y - p1.Y) / (p2.X - p1.X);

                if (p2.X == p3.X)
                    selectedV.node.Value.aNext = double.PositiveInfinity;
                else
                    selectedV.node.Value.aNext = (double)(p3.Y - p2.Y) / (p3.X - p2.X);

                double angle;
                if (double.IsPositiveInfinity(selectedV.node.Value.aPrev) && double.IsPositiveInfinity(selectedV.node.Value.aNext))
                {
                    angle = 180;
                }
                else if (double.IsPositiveInfinity(selectedV.node.Value.aPrev))
                {
                    angle = Math.Atan(selectedV.node.Value.aNext) * 180 / Math.PI + 90;
                }
                else if (double.IsPositiveInfinity(selectedV.node.Value.aNext))
                {
                    angle = Math.Atan(selectedV.node.Value.aPrev) * 180 / Math.PI + 90;
                }
                else
                {
                    angle = Math.Atan(Math.Abs((selectedV.node.Value.aNext - selectedV.node.Value.aPrev) / (1 + selectedV.node.Value.aNext * selectedV.node.Value.aPrev))) * 180 / Math.PI;
                }
                // Check if angle should be acute or not
                Point mid13 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);
                double r = (p1.X - mid13.X) * (p1.X - mid13.X) + (p1.Y - mid13.Y) * (p1.Y - mid13.Y);
                bool isAcute = r < ((p2.X - mid13.X) * (p2.X - mid13.X) + (p2.Y - mid13.Y) * (p2.Y - mid13.Y));
                if (!isAcute)
                    angle = 180 - angle;

                SetAngleForm saf = new SetAngleForm(angle);
                saf.ShowDialog();
                selectedV.node.Value.ConstantAngle = saf.Angle;
                if ((int)angle != saf.Angle)
                {
                    angle = saf.Angle;
                    double cross = (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y);
                    double a;
                    if (cross >= 0) // Przeciwnie do ruchu wskazówek zegara
                    {
                        a = Math.Tan(Math.Atan(selectedV.node.Value.aPrev) + angle);
                    }
                    else
                    {
                        a = Math.Tan(Math.Atan(selectedV.node.Value.aPrev) - angle);
                    }
                    Vertice nextV = selectedV.node.Next != null ? selectedV.node.Next.Value : selectedV.p.Vertices.First();
                    nextV.Location = new Point(nextV.Location.X, (int)(a * (nextV.Location.X - p2.X) + p2.Y));
                    selectedV.node.Value.aNext = a;
                }
                saf.Dispose();

            }
            selectedV.node.Value.IsAngleSet = !selectedV.node.Value.IsAngleSet;
            pictureBox.Invalidate();
        }

        private void tsBtnAddV_Click(object sender, EventArgs e) => AddVerticeOnSelectedEdge();

        private void tsBtnRemoveV_Click(object sender, EventArgs e)
        {
            var previousV = selectedV.node.Previous != null ? selectedV.node.Previous.Value : selectedV.node.List.Last.Value;
            var nextV = selectedV.node.Next != null ? selectedV.node.Next.Value : selectedV.node.List.First.Value;

            if (previousV.IsHorizontal == 1)
                previousV.IsHorizontal = 0;
            else if (previousV.IsVertical == 1)
                previousV.IsVertical = 0;
            if (nextV.IsHorizontal == 2)
                nextV.IsHorizontal = 0;
            else if (nextV.IsVertical == 2)
                nextV.IsVertical = 0;

            previousV.IsAngleSet = false;
            nextV.IsAngleSet = false;

            selectedV.p.Vertices.Remove(selectedV.node.Value);
            tsBtnRemoveV.Enabled = false;

            pictureBox.Invalidate();
        }

        #endregion

        #region Other functions 

        private void FindLine(Point mouse, IEnumerable<Vertice> vertices)
        {
            bool lineFound = false;
            foreach (Vertice v in vertices)
            {
                if (selectedV.node == null || v != selectedV.node.Value)
                {
                    if (Math.Abs(mouse.X - v.Location.X) < D)
                    {
                        line = (true, true, v.Location.X);
                        lineFound = true;
                        break;
                    }
                    else if (Math.Abs(mouse.Y - v.Location.Y) < D)
                    {
                        line = (true, false, v.Location.Y);
                        lineFound = true;
                        break;
                    }
                }
            }
            if (!lineFound)
                line.visible = false;
        }
        private void AddVerticeOnSelectedEdge()
        {
            if (selectedE.node.Value.IsHorizontal == 1)
                selectedE.node.Value.IsHorizontal = 0;
            if (selectedE.node.Value.IsVertical == 1)
                selectedE.node.Value.IsVertical = 0;

            var nextV = selectedE.node.Next != null ? selectedE.node.Next.Value : selectedE.node.List.First();
            if (nextV.IsHorizontal == 2)
                nextV.IsHorizontal = 0;
            if (nextV.IsVertical == 2)
                nextV.IsVertical = 0;

            selectedE.p.Vertices.AddAfter(selectedE.node, new Vertice(selectedE.middle));
            selectedE.p = null;



            tsBtnAddV.Enabled = false;
            tsBtnSetEdgeHorizontal.Enabled = false;
            tsBtnSetEdgeVertical.Enabled = false;

            pictureBox.Invalidate();
        }

        private Point GetVerticeIconLocation(Vertice v, double a)
        {
            if (double.IsPositiveInfinity(a) || a == 0)
                return new Point(v.Location.X + ICON_DIST - ICON_HALFSIZE, v.Location.Y + ICON_DIST - ICON_HALFSIZE);
            else
            {
                double a2 = -1 / a;
                int x = (int)((ICON_DIST - ICON_HALFSIZE) / Math.Sqrt(1 + a2 * a2) + v.Location.X);
                return new Point(x, (int)(a2 * (x - v.Location.X) + v.Location.Y));
            }
        }

        private Point GetEdgeIconLocation(Vertice v1, Vertice v2)
        {
            if (v1.IsVertical == 1)
                return new Point(v1.Location.X - ICON_DIST - ICON_HALFSIZE, (v1.Location.Y + v2.Location.Y) / 2 - ICON_HALFSIZE);
            else
                return new Point((v1.Location.X + v2.Location.X) / 2 - ICON_HALFSIZE, v1.Location.Y + ICON_DIST - ICON_HALFSIZE);
        }

        private bool IsPointOnEdge(Point p0, Point p1, Point p2)
        {
            (int first, int second) ordX = p1.X < p2.X ? (p1.X, p2.X) : (p2.X, p1.X);
            (int first, int second) ordY = p1.Y < p2.Y ? (p1.Y, p2.Y) : (p2.Y, p1.Y);
            int eps = 5;

            if (p0.X < ordX.first - eps || p0.X > ordX.second + eps || p0.Y < ordY.first - eps || p0.Y > ordY.second + eps)
                return false;

            bool isOnLine = Math.Abs((p2.Y - p1.Y) * p0.X - (p2.X - p1.X) * p0.Y + p2.X * p1.Y - p2.Y * p1.X) /
                   Math.Sqrt(Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.X - p1.X, 2)) < 15;
            return isOnLine;

        }

        private void AddPolygon(Polygon p)
        {
            int k = Polygons.Count + 1;
            p.Name += k.ToString();
            Polygons.Add(p);
            listBoxPolygons.Items.Add(p);
            listBoxPolygons.SelectedIndex = listBoxPolygons.Items.Count - 1;
            pictureBox.Invalidate();
        }

        private void AddPredefinedPolygon()
        {
            Vertice v;
            List<Vertice> vertices = new List<Vertice>();

            v = new Vertice(120, 240);
            v.IsVertical = 2;
            v.IsHorizontal = 1;
            vertices.Add(v);

            v = new Vertice(210, 240);
            v.IsVertical = 1;
            v.IsHorizontal = 2;
            vertices.Add(v);

            v = new Vertice(210, 150);
            v.IsVertical = 2;
            vertices.Add(v);

            v = new Vertice(420, 150);
            Point p1 = v.Location;
            vertices.Add(v);

            v = new Vertice(240, 60);
            Point p2 = v.Location, p3 = new Point(120, 120);
            v.IsAngleSet = true;
            v.aPrev = (double)(p2.Y - p1.Y) / (p2.X - p1.X);
            v.aNext = (double)(p3.Y - p2.Y) / (p3.X - p2.X);
            v.ConstantAngle = (int)(180 - Math.Atan(Math.Abs((v.aNext - v.aPrev) / (1 + v.aNext * v.aPrev))) * 180 / Math.PI);
            vertices.Add(v);

            v = new Vertice(p3);
            v.IsVertical = 1;
            vertices.Add(v);

            AddPolygon(new Polygon(vertices));
        }

        private void EdgeSelected()
        {
            selectedV.node = null;
            tsBtnAddV.Enabled = true;
            tsBtnRemoveV.Enabled = false;

            var nextNode = selectedE.node.Next != null ? selectedE.node.Next : selectedE.p.Vertices.First;

            if (selectedE.node.Value.IsHorizontal == 2 || nextNode.Value.IsHorizontal == 1)
                tsBtnSetEdgeHorizontal.Enabled = false;
            else
                tsBtnSetEdgeHorizontal.Enabled = true;

            if (selectedE.node.Value.IsVertical == 2 || nextNode.Value.IsVertical == 1)
                tsBtnSetEdgeVertical.Enabled = false;
            else
                tsBtnSetEdgeVertical.Enabled = true;

            if (selectedE.node.Value.IsAngleSet || nextNode.Value.IsAngleSet)
            {
                tsBtnSetEdgeVertical.Enabled = false;
                tsBtnSetEdgeHorizontal.Enabled = false;
            }
        }

        private void VerticeSelected()
        {
            selectedE.node = null;
            tsBtnSetEdgeVertical.Enabled = false;
            tsBtnSetEdgeHorizontal.Enabled = false;
            tsBtnAddV.Enabled = false;
            tsBtnConstAngle.Enabled = true;
            if (selectedV.p.Vertices.Count > 2)
                tsBtnRemoveV.Enabled = true;
            else
                tsBtnRemoveV.Enabled = false;
        }

        private void NothingSelected()
        {
            selectedV.node = null;
            selectedE.node = null;
            tsBtnAddV.Enabled = false;
            tsBtnRemoveV.Enabled = false;
            tsBtnSetEdgeHorizontal.Enabled = false;
            tsBtnSetEdgeVertical.Enabled = false;
        }
        private void tsBtnCustomPolygon_Click(object sender, EventArgs e)
        {
            tsBtnAddV.Enabled = false;
            tsBtnRemoveV.Enabled = false;
            tsBtnSetEdgeHorizontal.Enabled = false;
            tsBtnSetEdgeVertical.Enabled = false;
            tsBtnConstAngle.Enabled = false;

            drawingPoly = true;
        }

        private void listBoxPolygons_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.ShiftKey)
            {
                shiftPressed = false;
                pictureBox.Cursor = Cursors.Arrow;
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    try
                    {
                        sw.WriteLine(Polygons.Count);
                        foreach(Polygon p in Polygons)
                        {
                            sw.WriteLine(p.Vertices.Count.ToString() + " " + p.Name.Substring(0,6));
                            foreach(Vertice v in p.Vertices)
                            {
                                sw.WriteLine(v.Location.X.ToString() + " " + v.Location.Y.ToString() + " " + v.IsHorizontal.ToString() + " " + v.IsVertical.ToString() + " " + (v.IsAngleSet ? "1" : "0"));
                                if (v.IsAngleSet)
                                    sw.WriteLine(v.ConstantAngle.ToString() + " " + v.aPrev.ToString() + " " + v.aNext.ToString());
                            }
                        }
                        sw.Close();
                        MessageBox.Show("File saved!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error occured");
                    }
                }
            }
        }

        private void tsBtnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    List<Polygon> polyList = new List<Polygon>();
                    try
                    {
                        int pCount = int.Parse(sr.ReadLine());
                        string[] buf;
                        for (int i = 0; i < pCount; i++)
                        {
                            buf = sr.ReadLine().Split(' ');
                            int vCount = int.Parse(buf[0]);
                            string pName = buf[1];
                            List<Vertice> vList = new List<Vertice>(); 
                            for(int j=0;j<vCount;j++)
                            {
                                buf = sr.ReadLine().Split(' ');
                                Vertice v = new Vertice(new Point(int.Parse(buf[0]), int.Parse(buf[1])));
                                v.IsHorizontal = int.Parse(buf[2]);
                                v.IsVertical = int.Parse(buf[3]);
                                v.IsAngleSet = (buf[4] == "1");
                                if(v.IsAngleSet)
                                {
                                    buf = sr.ReadLine().Split(' ');
                                    v.ConstantAngle = double.Parse(buf[0]);
                                    v.aPrev = double.Parse(buf[1]);
                                    v.aNext = double.Parse(buf[2]);
                                }
                                vList.Add(v);
                            }
                            polyList.Add(new Polygon(vList, pName));
                        }
                        Polygons.Clear();
                        listBoxPolygons.Items.Clear();
                        foreach (Polygon p in polyList)
                            AddPolygon(p);
                        selectedE = (null,new Point(),null);
                        selectedV = (null, null);

                        pictureBox.Invalidate();
                        MessageBox.Show("File loaded!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error occured!");
                    }
                }
            }
        }

        private void DrawLine(Brush brush, Graphics graphics, Point p1, Point p2)
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
                graphics.FillRectangle(brush, x, y, 1, 1);
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

        #endregion
    }
}
