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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutBezier = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBezierTop = new System.Windows.Forms.TableLayoutPanel();
            this.labelNPoints = new System.Windows.Forms.Label();
            this.textBoxNPoints = new System.Windows.Forms.TextBox();
            this.btnGenerateBezier = new System.Windows.Forms.Button();
            this.checkBoxVisiblePolyline = new System.Windows.Forms.CheckBox();
            this.tableLayoutBezierBot = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutBezier.SuspendLayout();
            this.tableLayoutBezierTop.SuspendLayout();
            this.tableLayoutBezierBot.SuspendLayout();
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
            this.splitContainerMain.Size = new System.Drawing.Size(800, 450);
            this.splitContainerMain.SplitterDistance = 266;
            this.splitContainerMain.TabIndex = 10;
            this.splitContainerMain.TabStop = false;
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
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotating";
            // 
            // groupBox4
            // 
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 310);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 140);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Animation";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutBezier.ResumeLayout(false);
            this.tableLayoutBezier.PerformLayout();
            this.tableLayoutBezierTop.ResumeLayout(false);
            this.tableLayoutBezierTop.PerformLayout();
            this.tableLayoutBezierBot.ResumeLayout(false);
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
    }
}

