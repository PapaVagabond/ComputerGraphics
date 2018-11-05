namespace PolyEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBoxPolygons = new System.Windows.Forms.ListBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tsBtnTriangle = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSquare = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPentagon = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHexagon = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCustomPolygon = new System.Windows.Forms.ToolStripButton();
            this.tsBtnAddV = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemoveV = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSetEdgeHorizontal = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSetEdgeVertical = new System.Windows.Forms.ToolStripButton();
            this.tsBtnConstAngle = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(800, 415);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(800, 450);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBoxPolygons);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(800, 415);
            this.splitContainer.SplitterDistance = 200;
            this.splitContainer.SplitterWidth = 10;
            this.splitContainer.TabIndex = 0;
            // 
            // listBoxPolygons
            // 
            this.listBoxPolygons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPolygons.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxPolygons.FormattingEnabled = true;
            this.listBoxPolygons.ItemHeight = 28;
            this.listBoxPolygons.Location = new System.Drawing.Point(0, 0);
            this.listBoxPolygons.Name = "listBoxPolygons";
            this.listBoxPolygons.Size = new System.Drawing.Size(200, 415);
            this.listBoxPolygons.TabIndex = 5;
            this.listBoxPolygons.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxPolygons_DrawItem);
            this.listBoxPolygons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxPolygons_KeyDown);
            this.listBoxPolygons.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxPolygons_KeyUp);
            this.listBoxPolygons.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxPolygons_MouseUp);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnLoad,
            this.toolStripSeparator2,
            this.tsBtnTriangle,
            this.tsBtnSquare,
            this.tsBtnPentagon,
            this.tsBtnHexagon,
            this.tsBtnCustomPolygon,
            this.toolStripSeparator1,
            this.tsBtnAddV,
            this.tsBtnRemoveV,
            this.tsBtnSetEdgeHorizontal,
            this.tsBtnSetEdgeVertical,
            this.tsBtnConstAngle});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.MinimumSize = new System.Drawing.Size(0, 35);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 35);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Polygon Editor project (*.pep)|*.pep";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "Polygon Editor project (*.pep)|*.pep";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(590, 415);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // tsBtnTriangle
            // 
            this.tsBtnTriangle.AutoSize = false;
            this.tsBtnTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnTriangle.Image")));
            this.tsBtnTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTriangle.Name = "tsBtnTriangle";
            this.tsBtnTriangle.Size = new System.Drawing.Size(32, 32);
            this.tsBtnTriangle.Text = "Triangle";
            this.tsBtnTriangle.Click += new System.EventHandler(this.tsBtnTriangle_Click);
            // 
            // tsBtnSquare
            // 
            this.tsBtnSquare.AutoSize = false;
            this.tsBtnSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSquare.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSquare.Image")));
            this.tsBtnSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSquare.Name = "tsBtnSquare";
            this.tsBtnSquare.Size = new System.Drawing.Size(32, 32);
            this.tsBtnSquare.Text = "Square";
            this.tsBtnSquare.Click += new System.EventHandler(this.tsBtnSquare_Click);
            // 
            // tsBtnPentagon
            // 
            this.tsBtnPentagon.AutoSize = false;
            this.tsBtnPentagon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPentagon.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPentagon.Image")));
            this.tsBtnPentagon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPentagon.Name = "tsBtnPentagon";
            this.tsBtnPentagon.Size = new System.Drawing.Size(32, 32);
            this.tsBtnPentagon.Text = "Pentagon";
            this.tsBtnPentagon.Click += new System.EventHandler(this.tsBtnPentagon_Click);
            // 
            // tsBtnHexagon
            // 
            this.tsBtnHexagon.AutoSize = false;
            this.tsBtnHexagon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnHexagon.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHexagon.Image")));
            this.tsBtnHexagon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHexagon.Name = "tsBtnHexagon";
            this.tsBtnHexagon.Size = new System.Drawing.Size(32, 32);
            this.tsBtnHexagon.Text = "Hexagon";
            this.tsBtnHexagon.Click += new System.EventHandler(this.tsBtnHexagon_Click);
            // 
            // tsBtnCustomPolygon
            // 
            this.tsBtnCustomPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCustomPolygon.Image = global::PolyEditor.Properties.Resources.custom_polygon;
            this.tsBtnCustomPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCustomPolygon.Name = "tsBtnCustomPolygon";
            this.tsBtnCustomPolygon.Size = new System.Drawing.Size(23, 32);
            this.tsBtnCustomPolygon.Text = "Draw polygon";
            this.tsBtnCustomPolygon.Click += new System.EventHandler(this.tsBtnCustomPolygon_Click);
            // 
            // tsBtnAddV
            // 
            this.tsBtnAddV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddV.Enabled = false;
            this.tsBtnAddV.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddV.Image")));
            this.tsBtnAddV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddV.Name = "tsBtnAddV";
            this.tsBtnAddV.Size = new System.Drawing.Size(23, 32);
            this.tsBtnAddV.Text = "toolStripButton1";
            this.tsBtnAddV.ToolTipText = "Add vertice";
            this.tsBtnAddV.Click += new System.EventHandler(this.tsBtnAddV_Click);
            // 
            // tsBtnRemoveV
            // 
            this.tsBtnRemoveV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRemoveV.Enabled = false;
            this.tsBtnRemoveV.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRemoveV.Image")));
            this.tsBtnRemoveV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveV.Name = "tsBtnRemoveV";
            this.tsBtnRemoveV.Size = new System.Drawing.Size(23, 32);
            this.tsBtnRemoveV.Text = "toolStripButton1";
            this.tsBtnRemoveV.ToolTipText = "Remove vertice";
            this.tsBtnRemoveV.Click += new System.EventHandler(this.tsBtnRemoveV_Click);
            // 
            // tsBtnSetEdgeHorizontal
            // 
            this.tsBtnSetEdgeHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSetEdgeHorizontal.Enabled = false;
            this.tsBtnSetEdgeHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSetEdgeHorizontal.Image")));
            this.tsBtnSetEdgeHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSetEdgeHorizontal.Name = "tsBtnSetEdgeHorizontal";
            this.tsBtnSetEdgeHorizontal.Size = new System.Drawing.Size(23, 32);
            this.tsBtnSetEdgeHorizontal.Text = "toolStripButton1";
            this.tsBtnSetEdgeHorizontal.ToolTipText = "Set/Unset edge as horizontal";
            this.tsBtnSetEdgeHorizontal.Click += new System.EventHandler(this.tsBtnSetEdgeHorizontal_Click);
            // 
            // tsBtnSetEdgeVertical
            // 
            this.tsBtnSetEdgeVertical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSetEdgeVertical.Enabled = false;
            this.tsBtnSetEdgeVertical.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSetEdgeVertical.Image")));
            this.tsBtnSetEdgeVertical.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSetEdgeVertical.Name = "tsBtnSetEdgeVertical";
            this.tsBtnSetEdgeVertical.Size = new System.Drawing.Size(23, 32);
            this.tsBtnSetEdgeVertical.Text = "toolStripButton2";
            this.tsBtnSetEdgeVertical.ToolTipText = "Set/Unset edge as vertical";
            this.tsBtnSetEdgeVertical.Click += new System.EventHandler(this.tsBtnSetEdgeVertical_Click);
            // 
            // tsBtnConstAngle
            // 
            this.tsBtnConstAngle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnConstAngle.Enabled = false;
            this.tsBtnConstAngle.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnConstAngle.Image")));
            this.tsBtnConstAngle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnConstAngle.Name = "tsBtnConstAngle";
            this.tsBtnConstAngle.Size = new System.Drawing.Size(23, 32);
            this.tsBtnConstAngle.Text = "toolStripButton1";
            this.tsBtnConstAngle.ToolTipText = "Set constant angle";
            this.tsBtnConstAngle.Click += new System.EventHandler(this.tsBtnConstAngle_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = global::PolyEditor.Properties.Resources.save;
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(23, 32);
            this.tsBtnSave.ToolTipText = "Save";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnLoad
            // 
            this.tsBtnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLoad.Image = global::PolyEditor.Properties.Resources.open;
            this.tsBtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLoad.Name = "tsBtnLoad";
            this.tsBtnLoad.Size = new System.Drawing.Size(23, 32);
            this.tsBtnLoad.ToolTipText = "Load project";
            this.tsBtnLoad.Click += new System.EventHandler(this.tsBtnLoad_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Polygon Editor";
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsBtnTriangle;
        private System.Windows.Forms.ToolStripButton tsBtnSquare;
        private System.Windows.Forms.ToolStripButton tsBtnPentagon;
        private System.Windows.Forms.ToolStripButton tsBtnHexagon;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnAddV;
        private System.Windows.Forms.ListBox listBoxPolygons;
        private System.Windows.Forms.ToolStripButton tsBtnSetEdgeHorizontal;
        private System.Windows.Forms.ToolStripButton tsBtnSetEdgeVertical;
        private System.Windows.Forms.ToolStripButton tsBtnRemoveV;
        private System.Windows.Forms.ToolStripButton tsBtnConstAngle;
        private System.Windows.Forms.ToolStripButton tsBtnCustomPolygon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton tsBtnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

