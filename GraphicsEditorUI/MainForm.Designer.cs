
namespace GraphicsEditorUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.btnDeleteAllShapes = new System.Windows.Forms.Button();
            this.panelCreatedShapesList = new System.Windows.Forms.Panel();
            this.btnShapesList = new System.Windows.Forms.Button();
            this.panelFileOptions = new System.Windows.Forms.Panel();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnFileOptions = new System.Windows.Forms.Button();
            this.panelAntiAliasing = new System.Windows.Forms.Panel();
            this.btnXiaolinWuOff = new System.Windows.Forms.Button();
            this.brnXiaolinWu = new System.Windows.Forms.Button();
            this.btnAntiAliasing = new System.Windows.Forms.Button();
            this.panelDrawShape = new System.Windows.Forms.Panel();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnCapsule = new System.Windows.Forms.Button();
            this.btnDrawPolygon = new System.Windows.Forms.Button();
            this.btnDrawCircle = new System.Windows.Forms.Button();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawShape = new System.Windows.Forms.Button();
            this.panelGeneralSettings = new System.Windows.Forms.Panel();
            this.btnChangeLineThickness = new System.Windows.Forms.Panel();
            this.editorChangeLineThickness = new System.Windows.Forms.NumericUpDown();
            this.labelChangeThickness = new System.Windows.Forms.Label();
            this.btnChangeColor = new System.Windows.Forms.Panel();
            this.labelChangeColor = new System.Windows.Forms.Label();
            this.pictureBoxChosenColor = new System.Windows.Forms.PictureBox();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.panelDrawablePictureBox = new System.Windows.Forms.Panel();
            this.drawablePictureBox = new System.Windows.Forms.PictureBox();
            this.btnClip = new System.Windows.Forms.Button();
            this.sideMenuPanel.SuspendLayout();
            this.panelFileOptions.SuspendLayout();
            this.panelAntiAliasing.SuspendLayout();
            this.panelDrawShape.SuspendLayout();
            this.panelGeneralSettings.SuspendLayout();
            this.btnChangeLineThickness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorChangeLineThickness)).BeginInit();
            this.btnChangeColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosenColor)).BeginInit();
            this.panelDrawablePictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawablePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.AutoScroll = true;
            this.sideMenuPanel.BackColor = System.Drawing.Color.BurlyWood;
            this.sideMenuPanel.Controls.Add(this.btnClip);
            this.sideMenuPanel.Controls.Add(this.btnDeleteAllShapes);
            this.sideMenuPanel.Controls.Add(this.panelCreatedShapesList);
            this.sideMenuPanel.Controls.Add(this.btnShapesList);
            this.sideMenuPanel.Controls.Add(this.panelFileOptions);
            this.sideMenuPanel.Controls.Add(this.btnFileOptions);
            this.sideMenuPanel.Controls.Add(this.panelAntiAliasing);
            this.sideMenuPanel.Controls.Add(this.btnAntiAliasing);
            this.sideMenuPanel.Controls.Add(this.panelDrawShape);
            this.sideMenuPanel.Controls.Add(this.btnDrawShape);
            this.sideMenuPanel.Controls.Add(this.panelGeneralSettings);
            this.sideMenuPanel.Controls.Add(this.btnGeneralSettings);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(200, 861);
            this.sideMenuPanel.TabIndex = 0;
            // 
            // btnDeleteAllShapes
            // 
            this.btnDeleteAllShapes.BackColor = System.Drawing.Color.Tan;
            this.btnDeleteAllShapes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteAllShapes.FlatAppearance.BorderSize = 0;
            this.btnDeleteAllShapes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllShapes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteAllShapes.Location = new System.Drawing.Point(0, 483);
            this.btnDeleteAllShapes.Name = "btnDeleteAllShapes";
            this.btnDeleteAllShapes.Size = new System.Drawing.Size(200, 30);
            this.btnDeleteAllShapes.TabIndex = 18;
            this.btnDeleteAllShapes.Text = "Delete All Shapes";
            this.btnDeleteAllShapes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteAllShapes.UseVisualStyleBackColor = false;
            this.btnDeleteAllShapes.Click += new System.EventHandler(this.btnDeleteAllShapes_Click);
            // 
            // panelCreatedShapesList
            // 
            this.panelCreatedShapesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreatedShapesList.Location = new System.Drawing.Point(0, 483);
            this.panelCreatedShapesList.Name = "panelCreatedShapesList";
            this.panelCreatedShapesList.Size = new System.Drawing.Size(200, 0);
            this.panelCreatedShapesList.TabIndex = 17;
            this.panelCreatedShapesList.Visible = false;
            // 
            // btnShapesList
            // 
            this.btnShapesList.BackColor = System.Drawing.Color.Tan;
            this.btnShapesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShapesList.FlatAppearance.BorderSize = 0;
            this.btnShapesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShapesList.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShapesList.Location = new System.Drawing.Point(0, 453);
            this.btnShapesList.Name = "btnShapesList";
            this.btnShapesList.Size = new System.Drawing.Size(200, 30);
            this.btnShapesList.TabIndex = 16;
            this.btnShapesList.Text = "Created Shapes List";
            this.btnShapesList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShapesList.UseVisualStyleBackColor = false;
            this.btnShapesList.Click += new System.EventHandler(this.btnShapesList_Click);
            // 
            // panelFileOptions
            // 
            this.panelFileOptions.Controls.Add(this.btnSaveFile);
            this.panelFileOptions.Controls.Add(this.btnOpenFile);
            this.panelFileOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileOptions.Location = new System.Drawing.Point(0, 393);
            this.panelFileOptions.Name = "panelFileOptions";
            this.panelFileOptions.Size = new System.Drawing.Size(200, 60);
            this.panelFileOptions.TabIndex = 15;
            this.panelFileOptions.Visible = false;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.BurlyWood;
            this.btnSaveFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveFile.Location = new System.Drawing.Point(0, 30);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(200, 30);
            this.btnSaveFile.TabIndex = 6;
            this.btnSaveFile.Text = "Save to file...";
            this.btnSaveFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.BurlyWood;
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenFile.FlatAppearance.BorderSize = 0;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOpenFile.Location = new System.Drawing.Point(0, 0);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(200, 30);
            this.btnOpenFile.TabIndex = 5;
            this.btnOpenFile.Text = "Open from file...";
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnFileOptions
            // 
            this.btnFileOptions.BackColor = System.Drawing.Color.Tan;
            this.btnFileOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFileOptions.FlatAppearance.BorderSize = 0;
            this.btnFileOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileOptions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFileOptions.Location = new System.Drawing.Point(0, 363);
            this.btnFileOptions.Name = "btnFileOptions";
            this.btnFileOptions.Size = new System.Drawing.Size(200, 30);
            this.btnFileOptions.TabIndex = 14;
            this.btnFileOptions.Text = "File Options";
            this.btnFileOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileOptions.UseVisualStyleBackColor = false;
            this.btnFileOptions.Click += new System.EventHandler(this.btnFileOptions_Click);
            // 
            // panelAntiAliasing
            // 
            this.panelAntiAliasing.Controls.Add(this.btnXiaolinWuOff);
            this.panelAntiAliasing.Controls.Add(this.brnXiaolinWu);
            this.panelAntiAliasing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAntiAliasing.Location = new System.Drawing.Point(0, 303);
            this.panelAntiAliasing.Name = "panelAntiAliasing";
            this.panelAntiAliasing.Size = new System.Drawing.Size(200, 60);
            this.panelAntiAliasing.TabIndex = 11;
            this.panelAntiAliasing.Visible = false;
            // 
            // btnXiaolinWuOff
            // 
            this.btnXiaolinWuOff.BackColor = System.Drawing.Color.BurlyWood;
            this.btnXiaolinWuOff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXiaolinWuOff.FlatAppearance.BorderSize = 0;
            this.btnXiaolinWuOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXiaolinWuOff.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnXiaolinWuOff.Location = new System.Drawing.Point(0, 30);
            this.btnXiaolinWuOff.Name = "btnXiaolinWuOff";
            this.btnXiaolinWuOff.Size = new System.Drawing.Size(200, 30);
            this.btnXiaolinWuOff.TabIndex = 6;
            this.btnXiaolinWuOff.Text = "Turn Off Xiaolin Wu";
            this.btnXiaolinWuOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXiaolinWuOff.UseVisualStyleBackColor = false;
            this.btnXiaolinWuOff.Click += new System.EventHandler(this.btnXiaolinWuOff_Click);
            // 
            // brnXiaolinWu
            // 
            this.brnXiaolinWu.BackColor = System.Drawing.Color.BurlyWood;
            this.brnXiaolinWu.Dock = System.Windows.Forms.DockStyle.Top;
            this.brnXiaolinWu.FlatAppearance.BorderSize = 0;
            this.brnXiaolinWu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnXiaolinWu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.brnXiaolinWu.Location = new System.Drawing.Point(0, 0);
            this.brnXiaolinWu.Name = "brnXiaolinWu";
            this.brnXiaolinWu.Size = new System.Drawing.Size(200, 30);
            this.brnXiaolinWu.TabIndex = 5;
            this.brnXiaolinWu.Text = "Turn On Xiaolin Wu";
            this.brnXiaolinWu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnXiaolinWu.UseVisualStyleBackColor = false;
            this.brnXiaolinWu.Click += new System.EventHandler(this.brnXiaolinWu_Click);
            // 
            // btnAntiAliasing
            // 
            this.btnAntiAliasing.BackColor = System.Drawing.Color.Tan;
            this.btnAntiAliasing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAntiAliasing.FlatAppearance.BorderSize = 0;
            this.btnAntiAliasing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAntiAliasing.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAntiAliasing.Location = new System.Drawing.Point(0, 273);
            this.btnAntiAliasing.Name = "btnAntiAliasing";
            this.btnAntiAliasing.Size = new System.Drawing.Size(200, 30);
            this.btnAntiAliasing.TabIndex = 10;
            this.btnAntiAliasing.Text = "Apply Anti-Aliasing";
            this.btnAntiAliasing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAntiAliasing.UseVisualStyleBackColor = false;
            this.btnAntiAliasing.Click += new System.EventHandler(this.btnAntiAliasing_Click);
            // 
            // panelDrawShape
            // 
            this.panelDrawShape.Controls.Add(this.btnRectangle);
            this.panelDrawShape.Controls.Add(this.btnCapsule);
            this.panelDrawShape.Controls.Add(this.btnDrawPolygon);
            this.panelDrawShape.Controls.Add(this.btnDrawCircle);
            this.panelDrawShape.Controls.Add(this.btnDrawLine);
            this.panelDrawShape.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDrawShape.Location = new System.Drawing.Point(0, 123);
            this.panelDrawShape.Name = "panelDrawShape";
            this.panelDrawShape.Size = new System.Drawing.Size(200, 150);
            this.panelDrawShape.TabIndex = 9;
            this.panelDrawShape.Visible = false;
            // 
            // btnRectangle
            // 
            this.btnRectangle.BackColor = System.Drawing.Color.BurlyWood;
            this.btnRectangle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRectangle.FlatAppearance.BorderSize = 0;
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectangle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRectangle.Location = new System.Drawing.Point(0, 120);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(200, 30);
            this.btnRectangle.TabIndex = 6;
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnCapsule
            // 
            this.btnCapsule.BackColor = System.Drawing.Color.BurlyWood;
            this.btnCapsule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCapsule.FlatAppearance.BorderSize = 0;
            this.btnCapsule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapsule.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCapsule.Location = new System.Drawing.Point(0, 90);
            this.btnCapsule.Name = "btnCapsule";
            this.btnCapsule.Size = new System.Drawing.Size(200, 30);
            this.btnCapsule.TabIndex = 5;
            this.btnCapsule.Text = "Capsule";
            this.btnCapsule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapsule.UseVisualStyleBackColor = false;
            this.btnCapsule.Click += new System.EventHandler(this.btnCapsule_Click);
            // 
            // btnDrawPolygon
            // 
            this.btnDrawPolygon.BackColor = System.Drawing.Color.BurlyWood;
            this.btnDrawPolygon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDrawPolygon.FlatAppearance.BorderSize = 0;
            this.btnDrawPolygon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawPolygon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDrawPolygon.Location = new System.Drawing.Point(0, 60);
            this.btnDrawPolygon.Name = "btnDrawPolygon";
            this.btnDrawPolygon.Size = new System.Drawing.Size(200, 30);
            this.btnDrawPolygon.TabIndex = 4;
            this.btnDrawPolygon.Text = "Polygon";
            this.btnDrawPolygon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawPolygon.UseVisualStyleBackColor = false;
            this.btnDrawPolygon.Click += new System.EventHandler(this.btnDrawPolygon_Click);
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.BackColor = System.Drawing.Color.BurlyWood;
            this.btnDrawCircle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDrawCircle.FlatAppearance.BorderSize = 0;
            this.btnDrawCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawCircle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDrawCircle.Location = new System.Drawing.Point(0, 30);
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(200, 30);
            this.btnDrawCircle.TabIndex = 3;
            this.btnDrawCircle.Text = "Circle";
            this.btnDrawCircle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawCircle.UseVisualStyleBackColor = false;
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.BackColor = System.Drawing.Color.BurlyWood;
            this.btnDrawLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDrawLine.FlatAppearance.BorderSize = 0;
            this.btnDrawLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawLine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDrawLine.Location = new System.Drawing.Point(0, 0);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(200, 30);
            this.btnDrawLine.TabIndex = 2;
            this.btnDrawLine.Text = "Line";
            this.btnDrawLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawLine.UseVisualStyleBackColor = false;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // btnDrawShape
            // 
            this.btnDrawShape.BackColor = System.Drawing.Color.Tan;
            this.btnDrawShape.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDrawShape.FlatAppearance.BorderSize = 0;
            this.btnDrawShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawShape.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDrawShape.Location = new System.Drawing.Point(0, 93);
            this.btnDrawShape.Name = "btnDrawShape";
            this.btnDrawShape.Size = new System.Drawing.Size(200, 30);
            this.btnDrawShape.TabIndex = 8;
            this.btnDrawShape.Text = "Draw Shape";
            this.btnDrawShape.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrawShape.UseVisualStyleBackColor = false;
            this.btnDrawShape.Click += new System.EventHandler(this.btnDrawShape_Click);
            // 
            // panelGeneralSettings
            // 
            this.panelGeneralSettings.Controls.Add(this.btnChangeLineThickness);
            this.panelGeneralSettings.Controls.Add(this.btnChangeColor);
            this.panelGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGeneralSettings.Location = new System.Drawing.Point(0, 30);
            this.panelGeneralSettings.Name = "panelGeneralSettings";
            this.panelGeneralSettings.Size = new System.Drawing.Size(200, 63);
            this.panelGeneralSettings.TabIndex = 1;
            this.panelGeneralSettings.Visible = false;
            // 
            // btnChangeLineThickness
            // 
            this.btnChangeLineThickness.Controls.Add(this.editorChangeLineThickness);
            this.btnChangeLineThickness.Controls.Add(this.labelChangeThickness);
            this.btnChangeLineThickness.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeLineThickness.Location = new System.Drawing.Point(0, 30);
            this.btnChangeLineThickness.Name = "btnChangeLineThickness";
            this.btnChangeLineThickness.Size = new System.Drawing.Size(200, 32);
            this.btnChangeLineThickness.TabIndex = 1;
            // 
            // editorChangeLineThickness
            // 
            this.editorChangeLineThickness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorChangeLineThickness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editorChangeLineThickness.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.editorChangeLineThickness.Location = new System.Drawing.Point(161, 4);
            this.editorChangeLineThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.editorChangeLineThickness.Name = "editorChangeLineThickness";
            this.editorChangeLineThickness.Size = new System.Drawing.Size(35, 23);
            this.editorChangeLineThickness.TabIndex = 2;
            this.editorChangeLineThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.editorChangeLineThickness.ValueChanged += new System.EventHandler(this.editorChangeLineThickness_ValueChanged);
            // 
            // labelChangeThickness
            // 
            this.labelChangeThickness.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelChangeThickness.Location = new System.Drawing.Point(0, 0);
            this.labelChangeThickness.Name = "labelChangeThickness";
            this.labelChangeThickness.Size = new System.Drawing.Size(137, 32);
            this.labelChangeThickness.TabIndex = 1;
            this.labelChangeThickness.Text = "Change Line Thickness";
            this.labelChangeThickness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Controls.Add(this.labelChangeColor);
            this.btnChangeColor.Controls.Add(this.pictureBoxChosenColor);
            this.btnChangeColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChangeColor.Location = new System.Drawing.Point(0, 0);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(200, 30);
            this.btnChangeColor.TabIndex = 0;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // labelChangeColor
            // 
            this.labelChangeColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelChangeColor.Location = new System.Drawing.Point(0, 0);
            this.labelChangeColor.Name = "labelChangeColor";
            this.labelChangeColor.Size = new System.Drawing.Size(88, 30);
            this.labelChangeColor.TabIndex = 1;
            this.labelChangeColor.Text = "Change Color";
            this.labelChangeColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // pictureBoxChosenColor
            // 
            this.pictureBoxChosenColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxChosenColor.BackColor = System.Drawing.Color.Black;
            this.pictureBoxChosenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxChosenColor.Location = new System.Drawing.Point(175, 5);
            this.pictureBoxChosenColor.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBoxChosenColor.Name = "pictureBoxChosenColor";
            this.pictureBoxChosenColor.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxChosenColor.TabIndex = 0;
            this.pictureBoxChosenColor.TabStop = false;
            this.pictureBoxChosenColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.BackColor = System.Drawing.Color.Tan;
            this.btnGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGeneralSettings.FlatAppearance.BorderSize = 0;
            this.btnGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGeneralSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Size = new System.Drawing.Size(200, 30);
            this.btnGeneralSettings.TabIndex = 0;
            this.btnGeneralSettings.Text = "General Settings";
            this.btnGeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralSettings.UseVisualStyleBackColor = false;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnGeneralSettings_Click);
            // 
            // panelDrawablePictureBox
            // 
            this.panelDrawablePictureBox.Controls.Add(this.drawablePictureBox);
            this.panelDrawablePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDrawablePictureBox.Location = new System.Drawing.Point(200, 0);
            this.panelDrawablePictureBox.Name = "panelDrawablePictureBox";
            this.panelDrawablePictureBox.Size = new System.Drawing.Size(984, 861);
            this.panelDrawablePictureBox.TabIndex = 1;
            // 
            // drawablePictureBox
            // 
            this.drawablePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawablePictureBox.Location = new System.Drawing.Point(0, 0);
            this.drawablePictureBox.Name = "drawablePictureBox";
            this.drawablePictureBox.Size = new System.Drawing.Size(984, 861);
            this.drawablePictureBox.TabIndex = 0;
            this.drawablePictureBox.TabStop = false;
            this.drawablePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawablePictureBox_MouseClick);
            this.drawablePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawablePictureBox_MouseDown);
            this.drawablePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawablePictureBox_MouseMove);
            this.drawablePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawablePictureBox_MouseUp);
            // 
            // btnClip
            // 
            this.btnClip.BackColor = System.Drawing.Color.Tan;
            this.btnClip.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClip.FlatAppearance.BorderSize = 0;
            this.btnClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClip.Location = new System.Drawing.Point(0, 513);
            this.btnClip.Name = "btnClip";
            this.btnClip.Size = new System.Drawing.Size(200, 30);
            this.btnClip.TabIndex = 19;
            this.btnClip.Text = "Clip";
            this.btnClip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClip.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.panelDrawablePictureBox);
            this.Controls.Add(this.sideMenuPanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vector Graphics Editor";
            this.sideMenuPanel.ResumeLayout(false);
            this.panelFileOptions.ResumeLayout(false);
            this.panelAntiAliasing.ResumeLayout(false);
            this.panelDrawShape.ResumeLayout(false);
            this.panelGeneralSettings.ResumeLayout(false);
            this.btnChangeLineThickness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorChangeLineThickness)).EndInit();
            this.btnChangeColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosenColor)).EndInit();
            this.panelDrawablePictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawablePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Panel panelAntiAliasing;
        private System.Windows.Forms.Button brnXiaolinWu;
        private System.Windows.Forms.Button btnAntiAliasing;
        private System.Windows.Forms.Panel panelDrawShape;
        private System.Windows.Forms.Button btnDrawPolygon;
        private System.Windows.Forms.Button btnDrawCircle;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawShape;
        private System.Windows.Forms.Panel panelGeneralSettings;
        private System.Windows.Forms.Panel btnChangeLineThickness;
        private System.Windows.Forms.NumericUpDown editorChangeLineThickness;
        private System.Windows.Forms.Label labelChangeThickness;
        private System.Windows.Forms.Panel btnChangeColor;
        private System.Windows.Forms.Label labelChangeColor;
        private System.Windows.Forms.PictureBox pictureBoxChosenColor;
        private System.Windows.Forms.Button btnGeneralSettings;
        private System.Windows.Forms.Panel panelFileOptions;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnFileOptions;
        private System.Windows.Forms.Panel panelCreatedShapesList;
        private System.Windows.Forms.Button btnShapesList;
        private System.Windows.Forms.Panel panelDrawablePictureBox;
        private System.Windows.Forms.PictureBox drawablePictureBox;
        private System.Windows.Forms.Button btnXiaolinWuOff;
        private System.Windows.Forms.Button btnCapsule;
        private System.Windows.Forms.Button btnDeleteAllShapes;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnClip;
    }
}

