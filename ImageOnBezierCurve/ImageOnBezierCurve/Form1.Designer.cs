namespace ImageOnBezierCurve
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutAnimation = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rbCurve = new System.Windows.Forms.RadioButton();
            this.rbRotation = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbRotatingFilter = new System.Windows.Forms.RadioButton();
            this.rbRotatingNaive = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutImage = new System.Windows.Forms.TableLayoutPanel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutImageRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.checkBoxGrayColors = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutBezier = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBezierTop = new System.Windows.Forms.TableLayoutPanel();
            this.labelNPoints = new System.Windows.Forms.Label();
            this.textBoxNPoints = new System.Windows.Forms.TextBox();
            this.btnGenerateBezier = new System.Windows.Forms.Button();
            this.checkBoxVisiblePolyline = new System.Windows.Forms.CheckBox();
            this.tableLayoutBezierBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutAnimation.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.tableLayoutImageRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutBezier.SuspendLayout();
            this.tableLayoutBezierTop.SuspendLayout();
            this.tableLayoutBezierBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.groupBox4);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBox2);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pictureBox);
            this.splitContainerMain.Size = new System.Drawing.Size(800, 450);
            this.splitContainerMain.SplitterDistance = 266;
            this.splitContainerMain.TabIndex = 10;
            this.splitContainerMain.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutAnimation);
            this.groupBox4.Controls.Add(this.rbCurve);
            this.groupBox4.Controls.Add(this.rbRotation);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 288);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 162);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Animation";
            // 
            // tableLayoutAnimation
            // 
            this.tableLayoutAnimation.ColumnCount = 2;
            this.tableLayoutAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutAnimation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutAnimation.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutAnimation.Controls.Add(this.btnStop, 1, 0);
            this.tableLayoutAnimation.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutAnimation.Name = "tableLayoutAnimation";
            this.tableLayoutAnimation.RowCount = 1;
            this.tableLayoutAnimation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutAnimation.Size = new System.Drawing.Size(266, 100);
            this.tableLayoutAnimation.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(127, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStop.Location = new System.Drawing.Point(136, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(127, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // rbCurve
            // 
            this.rbCurve.AutoSize = true;
            this.rbCurve.Location = new System.Drawing.Point(13, 44);
            this.rbCurve.Name = "rbCurve";
            this.rbCurve.Size = new System.Drawing.Size(123, 17);
            this.rbCurve.TabIndex = 1;
            this.rbCurve.TabStop = true;
            this.rbCurve.Text = "Moving on the curve";
            this.rbCurve.UseVisualStyleBackColor = true;
            // 
            // rbRotation
            // 
            this.rbRotation.AutoSize = true;
            this.rbRotation.Location = new System.Drawing.Point(13, 20);
            this.rbRotation.Name = "rbRotation";
            this.rbRotation.Size = new System.Drawing.Size(65, 17);
            this.rbRotation.TabIndex = 0;
            this.rbRotation.TabStop = true;
            this.rbRotation.Text = "Rotation";
            this.rbRotation.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.rbRotatingFilter);
            this.groupBox3.Controls.Add(this.rbRotatingNaive);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 78);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotating";
            // 
            // rbRotatingFilter
            // 
            this.rbRotatingFilter.AutoSize = true;
            this.rbRotatingFilter.Location = new System.Drawing.Point(12, 42);
            this.rbRotatingFilter.Name = "rbRotatingFilter";
            this.rbRotatingFilter.Size = new System.Drawing.Size(83, 17);
            this.rbRotatingFilter.TabIndex = 1;
            this.rbRotatingFilter.TabStop = true;
            this.rbRotatingFilter.Text = "With filtering";
            this.rbRotatingFilter.UseVisualStyleBackColor = true;
            // 
            // rbRotatingNaive
            // 
            this.rbRotatingNaive.AutoSize = true;
            this.rbRotatingNaive.Location = new System.Drawing.Point(12, 19);
            this.rbRotatingNaive.Name = "rbRotatingNaive";
            this.rbRotatingNaive.Size = new System.Drawing.Size(53, 17);
            this.rbRotatingNaive.TabIndex = 0;
            this.rbRotatingNaive.TabStop = true;
            this.rbRotatingNaive.Text = "Naive";
            this.rbRotatingNaive.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // tableLayoutImage
            // 
            this.tableLayoutImage.ColumnCount = 2;
            this.tableLayoutImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutImage.Controls.Add(this.pbImage, 0, 0);
            this.tableLayoutImage.Controls.Add(this.tableLayoutImageRight, 1, 0);
            this.tableLayoutImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutImage.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutImage.Name = "tableLayoutImage";
            this.tableLayoutImage.RowCount = 1;
            this.tableLayoutImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutImage.Size = new System.Drawing.Size(260, 81);
            this.tableLayoutImage.TabIndex = 0;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(74, 75);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tableLayoutImageRight
            // 
            this.tableLayoutImageRight.ColumnCount = 1;
            this.tableLayoutImageRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutImageRight.Controls.Add(this.btnLoadImg, 0, 0);
            this.tableLayoutImageRight.Controls.Add(this.checkBoxGrayColors, 0, 1);
            this.tableLayoutImageRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutImageRight.Location = new System.Drawing.Point(83, 3);
            this.tableLayoutImageRight.Name = "tableLayoutImageRight";
            this.tableLayoutImageRight.RowCount = 2;
            this.tableLayoutImageRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutImageRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutImageRight.Size = new System.Drawing.Size(174, 75);
            this.tableLayoutImageRight.TabIndex = 1;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadImg.Location = new System.Drawing.Point(3, 3);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(168, 31);
            this.btnLoadImg.TabIndex = 0;
            this.btnLoadImg.Text = "Load";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // checkBoxGrayColors
            // 
            this.checkBoxGrayColors.AutoSize = true;
            this.checkBoxGrayColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxGrayColors.Location = new System.Drawing.Point(3, 40);
            this.checkBoxGrayColors.Name = "checkBoxGrayColors";
            this.checkBoxGrayColors.Size = new System.Drawing.Size(168, 32);
            this.checkBoxGrayColors.TabIndex = 1;
            this.checkBoxGrayColors.Text = "Gray colors";
            this.checkBoxGrayColors.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutBezier);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bezier\'s curve";
            // 
            // tableLayoutBezier
            // 
            this.tableLayoutBezier.ColumnCount = 1;
            this.tableLayoutBezier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBezier.Controls.Add(this.tableLayoutBezierTop, 0, 0);
            this.tableLayoutBezier.Controls.Add(this.checkBoxVisiblePolyline, 0, 1);
            this.tableLayoutBezier.Controls.Add(this.tableLayoutBezierBot, 0, 2);
            this.tableLayoutBezier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBezier.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutBezier.Name = "tableLayoutBezier";
            this.tableLayoutBezier.RowCount = 3;
            this.tableLayoutBezier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBezier.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBezier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBezier.Size = new System.Drawing.Size(260, 91);
            this.tableLayoutBezier.TabIndex = 0;
            // 
            // tableLayoutBezierTop
            // 
            this.tableLayoutBezierTop.ColumnCount = 3;
            this.tableLayoutBezierTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBezierTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutBezierTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutBezierTop.Controls.Add(this.labelNPoints, 0, 0);
            this.tableLayoutBezierTop.Controls.Add(this.textBoxNPoints, 1, 0);
            this.tableLayoutBezierTop.Controls.Add(this.btnGenerateBezier, 2, 0);
            this.tableLayoutBezierTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBezierTop.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutBezierTop.Name = "tableLayoutBezierTop";
            this.tableLayoutBezierTop.RowCount = 1;
            this.tableLayoutBezierTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBezierTop.Size = new System.Drawing.Size(254, 28);
            this.tableLayoutBezierTop.TabIndex = 0;
            // 
            // labelNPoints
            // 
            this.labelNPoints.AutoSize = true;
            this.labelNPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNPoints.Location = new System.Drawing.Point(3, 0);
            this.labelNPoints.Name = "labelNPoints";
            this.labelNPoints.Size = new System.Drawing.Size(111, 28);
            this.labelNPoints.TabIndex = 0;
            this.labelNPoints.Text = "Number of points:";
            this.labelNPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNPoints
            // 
            this.textBoxNPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNPoints.Location = new System.Drawing.Point(120, 3);
            this.textBoxNPoints.Name = "textBoxNPoints";
            this.textBoxNPoints.Size = new System.Drawing.Size(50, 20);
            this.textBoxNPoints.TabIndex = 1;
            // 
            // btnGenerateBezier
            // 
            this.btnGenerateBezier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateBezier.Location = new System.Drawing.Point(176, 3);
            this.btnGenerateBezier.Name = "btnGenerateBezier";
            this.btnGenerateBezier.Size = new System.Drawing.Size(75, 22);
            this.btnGenerateBezier.TabIndex = 2;
            this.btnGenerateBezier.Text = "Generate";
            this.btnGenerateBezier.UseVisualStyleBackColor = true;
            // 
            // checkBoxVisiblePolyline
            // 
            this.checkBoxVisiblePolyline.AutoSize = true;
            this.checkBoxVisiblePolyline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxVisiblePolyline.Location = new System.Drawing.Point(12, 37);
            this.checkBoxVisiblePolyline.Margin = new System.Windows.Forms.Padding(12, 3, 3, 3);
            this.checkBoxVisiblePolyline.Name = "checkBoxVisiblePolyline";
            this.checkBoxVisiblePolyline.Size = new System.Drawing.Size(245, 17);
            this.checkBoxVisiblePolyline.TabIndex = 1;
            this.checkBoxVisiblePolyline.Text = "Visible polyline";
            this.checkBoxVisiblePolyline.UseVisualStyleBackColor = true;
            // 
            // tableLayoutBezierBot
            // 
            this.tableLayoutBezierBot.ColumnCount = 2;
            this.tableLayoutBezierBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBezierBot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBezierBot.Controls.Add(this.btnLoad, 0, 0);
            this.tableLayoutBezierBot.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutBezierBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBezierBot.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutBezierBot.Name = "tableLayoutBezierBot";
            this.tableLayoutBezierBot.RowCount = 1;
            this.tableLayoutBezierBot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBezierBot.Size = new System.Drawing.Size(254, 28);
            this.tableLayoutBezierBot.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(121, 22);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(130, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 22);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(530, 450);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerMain);
            this.MinimumSize = new System.Drawing.Size(800, 460);
            this.Name = "MainForm";
            this.Text = "Image on Bezier\'s curve";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutAnimation.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.tableLayoutImageRight.ResumeLayout(false);
            this.tableLayoutImageRight.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutBezier.ResumeLayout(false);
            this.tableLayoutBezier.PerformLayout();
            this.tableLayoutBezierTop.ResumeLayout(false);
            this.tableLayoutBezierTop.PerformLayout();
            this.tableLayoutBezierBot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBezier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBezierTop;
        private System.Windows.Forms.Label labelNPoints;
        private System.Windows.Forms.TextBox textBoxNPoints;
        private System.Windows.Forms.Button btnGenerateBezier;
        private System.Windows.Forms.CheckBox checkBoxVisiblePolyline;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBezierBot;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutImageRight;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.CheckBox checkBoxGrayColors;
        private System.Windows.Forms.RadioButton rbRotatingFilter;
        private System.Windows.Forms.RadioButton rbRotatingNaive;
        private System.Windows.Forms.RadioButton rbCurve;
        private System.Windows.Forms.RadioButton rbRotation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutAnimation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

