namespace Filling
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dialogSetLightColor = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerAnimateLight = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbNormal1 = new System.Windows.Forms.RadioButton();
            this.pbNormalMap = new System.Windows.Forms.PictureBox();
            this.btnSetNormalMap = new System.Windows.Forms.Button();
            this.rbNormal2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetLightColour = new System.Windows.Forms.Button();
            this.pbLightColor = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbLightSource2 = new System.Windows.Forms.RadioButton();
            this.rbLightSource1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbObjectTexture = new System.Windows.Forms.PictureBox();
            this.btnSetObjectTexture = new System.Windows.Forms.Button();
            this.rbObjectColor2 = new System.Windows.Forms.RadioButton();
            this.rbObjectColor1 = new System.Windows.Forms.RadioButton();
            this.pbObjectColor = new System.Windows.Forms.PictureBox();
            this.btnSetObjectColor = new System.Windows.Forms.Button();
            this.rbD2 = new System.Windows.Forms.RadioButton();
            this.btnSetHeightMap = new System.Windows.Forms.Button();
            this.pbHeightMap = new System.Windows.Forms.PictureBox();
            this.rbD1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNormalMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLightColor)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbObjectTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbObjectColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeightMap)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(884, 461);
            this.splitContainer.SplitterDistance = 230;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(650, 461);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            // 
            // timerAnimateLight
            // 
            this.timerAnimateLight.Tick += new System.EventHandler(this.timerAnimateLight_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.rbNormal1);
            this.groupBox3.Controls.Add(this.pbNormalMap);
            this.groupBox3.Controls.Add(this.btnSetNormalMap);
            this.groupBox3.Controls.Add(this.rbNormal2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 254);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Normal vectors";
            // 
            // rbNormal1
            // 
            this.rbNormal1.AutoSize = true;
            this.rbNormal1.Checked = true;
            this.rbNormal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rbNormal1.Location = new System.Drawing.Point(8, 20);
            this.rbNormal1.Name = "rbNormal1";
            this.rbNormal1.Size = new System.Drawing.Size(78, 36);
            this.rbNormal1.TabIndex = 9;
            this.rbNormal1.TabStop = true;
            this.rbNormal1.Text = "Constant\r\n[0,0,1]";
            this.rbNormal1.UseVisualStyleBackColor = true;
            this.rbNormal1.CheckedChanged += new System.EventHandler(this.rbNormal1_CheckedChanged);
            // 
            // pbNormalMap
            // 
            this.pbNormalMap.BackColor = System.Drawing.Color.White;
            this.pbNormalMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbNormalMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNormalMap.Enabled = false;
            this.pbNormalMap.Location = new System.Drawing.Point(8, 150);
            this.pbNormalMap.Name = "pbNormalMap";
            this.pbNormalMap.Size = new System.Drawing.Size(96, 96);
            this.pbNormalMap.TabIndex = 8;
            this.pbNormalMap.TabStop = false;
            // 
            // btnSetNormalMap
            // 
            this.btnSetNormalMap.Enabled = false;
            this.btnSetNormalMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSetNormalMap.Location = new System.Drawing.Point(8, 119);
            this.btnSetNormalMap.Name = "btnSetNormalMap";
            this.btnSetNormalMap.Size = new System.Drawing.Size(96, 25);
            this.btnSetNormalMap.TabIndex = 7;
            this.btnSetNormalMap.Text = "Load texture";
            this.btnSetNormalMap.UseVisualStyleBackColor = true;
            this.btnSetNormalMap.Click += new System.EventHandler(this.btnSetNormalMap_Click);
            // 
            // rbNormal2
            // 
            this.rbNormal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbNormal2.Location = new System.Drawing.Point(8, 88);
            this.rbNormal2.Name = "rbNormal2";
            this.rbNormal2.Size = new System.Drawing.Size(100, 25);
            this.rbNormal2.TabIndex = 1;
            this.rbNormal2.Text = "From texture";
            this.rbNormal2.UseVisualStyleBackColor = true;
            this.rbNormal2.CheckedChanged += new System.EventHandler(this.rbNormal2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnSetLightColour);
            this.groupBox1.Controls.Add(this.pbLightColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light color";
            // 
            // btnSetLightColour
            // 
            this.btnSetLightColour.Location = new System.Drawing.Point(8, 21);
            this.btnSetLightColour.Name = "btnSetLightColour";
            this.btnSetLightColour.Size = new System.Drawing.Size(96, 25);
            this.btnSetLightColour.TabIndex = 1;
            this.btnSetLightColour.Text = "Change";
            this.btnSetLightColour.UseVisualStyleBackColor = true;
            this.btnSetLightColour.Click += new System.EventHandler(this.btnSetLightColour_Click);
            // 
            // pbLightColor
            // 
            this.pbLightColor.BackColor = System.Drawing.Color.White;
            this.pbLightColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLightColor.Location = new System.Drawing.Point(8, 52);
            this.pbLightColor.Name = "pbLightColor";
            this.pbLightColor.Size = new System.Drawing.Size(96, 25);
            this.pbLightColor.TabIndex = 0;
            this.pbLightColor.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.rbLightSource2);
            this.groupBox5.Controls.Add(this.rbLightSource1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox5.Location = new System.Drawing.Point(0, 352);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(109, 120);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vector to light source";
            // 
            // rbLightSource2
            // 
            this.rbLightSource2.AutoSize = true;
            this.rbLightSource2.Location = new System.Drawing.Point(8, 63);
            this.rbLightSource2.Name = "rbLightSource2";
            this.rbLightSource2.Size = new System.Drawing.Size(86, 36);
            this.rbLightSource2.TabIndex = 1;
            this.rbLightSource2.TabStop = true;
            this.rbLightSource2.Text = "Animate\r\non sphere";
            this.rbLightSource2.UseVisualStyleBackColor = true;
            this.rbLightSource2.CheckedChanged += new System.EventHandler(this.rbLightSource2_CheckedChanged);
            // 
            // rbLightSource1
            // 
            this.rbLightSource1.AutoSize = true;
            this.rbLightSource1.Checked = true;
            this.rbLightSource1.Location = new System.Drawing.Point(8, 21);
            this.rbLightSource1.Name = "rbLightSource1";
            this.rbLightSource1.Size = new System.Drawing.Size(78, 36);
            this.rbLightSource1.TabIndex = 0;
            this.rbLightSource1.TabStop = true;
            this.rbLightSource1.Text = "Constant\r\n[0,0,1]";
            this.rbLightSource1.UseVisualStyleBackColor = true;
            this.rbLightSource1.CheckedChanged += new System.EventHandler(this.rbLightSource1_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbObjectTexture);
            this.groupBox2.Controls.Add(this.btnSetObjectTexture);
            this.groupBox2.Controls.Add(this.rbObjectColor2);
            this.groupBox2.Controls.Add(this.rbObjectColor1);
            this.groupBox2.Controls.Add(this.pbObjectColor);
            this.groupBox2.Controls.Add(this.btnSetObjectColor);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(0, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 217);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object color";
            // 
            // pbObjectTexture
            // 
            this.pbObjectTexture.BackColor = System.Drawing.Color.White;
            this.pbObjectTexture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbObjectTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbObjectTexture.Enabled = false;
            this.pbObjectTexture.Location = new System.Drawing.Point(8, 164);
            this.pbObjectTexture.Name = "pbObjectTexture";
            this.pbObjectTexture.Size = new System.Drawing.Size(96, 25);
            this.pbObjectTexture.TabIndex = 7;
            this.pbObjectTexture.TabStop = false;
            // 
            // btnSetObjectTexture
            // 
            this.btnSetObjectTexture.Enabled = false;
            this.btnSetObjectTexture.Location = new System.Drawing.Point(8, 133);
            this.btnSetObjectTexture.Name = "btnSetObjectTexture";
            this.btnSetObjectTexture.Size = new System.Drawing.Size(96, 25);
            this.btnSetObjectTexture.TabIndex = 6;
            this.btnSetObjectTexture.Text = "Load texture";
            this.btnSetObjectTexture.UseVisualStyleBackColor = true;
            this.btnSetObjectTexture.Click += new System.EventHandler(this.btnSetObjectTexture_Click);
            // 
            // rbObjectColor2
            // 
            this.rbObjectColor2.Location = new System.Drawing.Point(8, 109);
            this.rbObjectColor2.Name = "rbObjectColor2";
            this.rbObjectColor2.Size = new System.Drawing.Size(100, 25);
            this.rbObjectColor2.TabIndex = 5;
            this.rbObjectColor2.Text = "From texture";
            this.rbObjectColor2.UseVisualStyleBackColor = true;
            this.rbObjectColor2.CheckedChanged += new System.EventHandler(this.rbObjectColor2_CheckedChanged);
            // 
            // rbObjectColor1
            // 
            this.rbObjectColor1.Checked = true;
            this.rbObjectColor1.Location = new System.Drawing.Point(8, 21);
            this.rbObjectColor1.Name = "rbObjectColor1";
            this.rbObjectColor1.Size = new System.Drawing.Size(100, 25);
            this.rbObjectColor1.TabIndex = 4;
            this.rbObjectColor1.TabStop = true;
            this.rbObjectColor1.Text = "Constant";
            this.rbObjectColor1.UseVisualStyleBackColor = true;
            this.rbObjectColor1.CheckedChanged += new System.EventHandler(this.rbObjectColor1_CheckedChanged);
            // 
            // pbObjectColor
            // 
            this.pbObjectColor.BackColor = System.Drawing.Color.White;
            this.pbObjectColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbObjectColor.Location = new System.Drawing.Point(8, 78);
            this.pbObjectColor.Name = "pbObjectColor";
            this.pbObjectColor.Size = new System.Drawing.Size(96, 25);
            this.pbObjectColor.TabIndex = 3;
            this.pbObjectColor.TabStop = false;
            // 
            // btnSetObjectColor
            // 
            this.btnSetObjectColor.Location = new System.Drawing.Point(8, 47);
            this.btnSetObjectColor.Name = "btnSetObjectColor";
            this.btnSetObjectColor.Size = new System.Drawing.Size(96, 25);
            this.btnSetObjectColor.TabIndex = 2;
            this.btnSetObjectColor.Text = "Change";
            this.btnSetObjectColor.UseVisualStyleBackColor = true;
            this.btnSetObjectColor.Click += new System.EventHandler(this.btnSetObjectColor_Click);
            // 
            // rbD2
            // 
            this.rbD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbD2.Location = new System.Drawing.Point(8, 62);
            this.rbD2.Name = "rbD2";
            this.rbD2.Size = new System.Drawing.Size(100, 25);
            this.rbD2.TabIndex = 4;
            this.rbD2.Text = "From texture";
            this.rbD2.UseVisualStyleBackColor = true;
            this.rbD2.CheckedChanged += new System.EventHandler(this.rbD2_CheckedChanged);
            // 
            // btnSetHeightMap
            // 
            this.btnSetHeightMap.Enabled = false;
            this.btnSetHeightMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSetHeightMap.Location = new System.Drawing.Point(8, 93);
            this.btnSetHeightMap.Name = "btnSetHeightMap";
            this.btnSetHeightMap.Size = new System.Drawing.Size(96, 25);
            this.btnSetHeightMap.TabIndex = 8;
            this.btnSetHeightMap.Text = "Load texture";
            this.btnSetHeightMap.UseVisualStyleBackColor = true;
            this.btnSetHeightMap.Click += new System.EventHandler(this.btnSetHeightMap_Click);
            // 
            // pbHeightMap
            // 
            this.pbHeightMap.BackColor = System.Drawing.Color.White;
            this.pbHeightMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbHeightMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbHeightMap.Enabled = false;
            this.pbHeightMap.Location = new System.Drawing.Point(8, 124);
            this.pbHeightMap.Name = "pbHeightMap";
            this.pbHeightMap.Size = new System.Drawing.Size(96, 96);
            this.pbHeightMap.TabIndex = 9;
            this.pbHeightMap.TabStop = false;
            // 
            // rbD1
            // 
            this.rbD1.AutoSize = true;
            this.rbD1.Checked = true;
            this.rbD1.Location = new System.Drawing.Point(8, 21);
            this.rbD1.Name = "rbD1";
            this.rbD1.Size = new System.Drawing.Size(78, 36);
            this.rbD1.TabIndex = 10;
            this.rbD1.TabStop = true;
            this.rbD1.Text = "Constant\r\n[0,0,0]";
            this.rbD1.UseVisualStyleBackColor = true;
            this.rbD1.CheckedChanged += new System.EventHandler(this.rbD1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.rbD1);
            this.groupBox4.Controls.Add(this.pbHeightMap);
            this.groupBox4.Controls.Add(this.btnSetHeightMap);
            this.groupBox4.Controls.Add(this.rbD2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(109, 241);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Depth";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.groupBox5);
            this.panelLeft.Controls.Add(this.groupBox1);
            this.panelLeft.Controls.Add(this.groupBox3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(109, 455);
            this.panelLeft.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.groupBox2);
            this.panelRight.Controls.Add(this.groupBox4);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(118, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(109, 455);
            this.panelRight.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButton1.Location = new System.Drawing.Point(8, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 20);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Bubble";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Filling";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNormalMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLightColor)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbObjectTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbObjectColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeightMap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ColorDialog dialogSetLightColor;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timerAnimateLight;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbLightSource2;
        private System.Windows.Forms.RadioButton rbLightSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetLightColour;
        private System.Windows.Forms.PictureBox pbLightColor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbNormal1;
        private System.Windows.Forms.PictureBox pbNormalMap;
        private System.Windows.Forms.Button btnSetNormalMap;
        private System.Windows.Forms.RadioButton rbNormal2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbObjectTexture;
        private System.Windows.Forms.Button btnSetObjectTexture;
        private System.Windows.Forms.RadioButton rbObjectColor2;
        private System.Windows.Forms.RadioButton rbObjectColor1;
        private System.Windows.Forms.PictureBox pbObjectColor;
        private System.Windows.Forms.Button btnSetObjectColor;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbD1;
        private System.Windows.Forms.PictureBox pbHeightMap;
        private System.Windows.Forms.Button btnSetHeightMap;
        private System.Windows.Forms.RadioButton rbD2;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

