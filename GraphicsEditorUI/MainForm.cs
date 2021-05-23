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

// Łukasz Zalewski
// index number 283655

namespace GraphicsEditorUI
{
    public partial class MainForm : Form
    {
        Color ChosenColor { get; set; }
        int ChosenThickness { get; set; }
        Bitmap DrawnImage { get; set; }
        bool IsDrawingLine { get; set; }
        bool IsDrawingCycle { get; set; }
        bool IsDrawingPolygon { get; set; }
        bool IsDrawingCapsule { get; set; }
        bool IsDrawingRectangle { get; set; }
        List <Point> SelectedVertices { get; set; }
        List <Shapes.Shape> CreatedShapes { get; set; }
        bool IsApplyingAntyAliasing { get; set; }
        bool IsMovingCircle { get; set; }
        bool IsMovingLine { get; set; }
        bool IsMovingPolygon { get; set; }
        bool IsMovingRectangle { get; set;}
        int MouseX { get; set; }
        int MouseY { get; set; }

        public MainForm()
        {
            ChosenColor = Color.Black;
            ChosenThickness = 1;
            InitializeComponent();
            drawablePictureBox.Image = new Bitmap(drawablePictureBox.Width, drawablePictureBox.Height);
            IsDrawingCycle = IsDrawingLine = IsDrawingPolygon = IsApplyingAntyAliasing = IsDrawingCapsule = IsDrawingRectangle = false;
            SelectedVertices = new List<Point>();
            CreatedShapes = new List<Shapes.Shape>();
            MouseX = MouseY = 0;
            IsMovingCircle = false;
            IsMovingLine = false;
        }

        private void RerenderControls()
        {
            int tmp = panelCreatedShapesList.Controls.Count;
            panelCreatedShapesList.Controls.Clear();
            panelCreatedShapesList.Height -= 30 * tmp;
            int i = 0;
            foreach(Shapes.Shape shape in CreatedShapes)
            {
                AddNewButton(shape, i);
                i++;
            }
        }

        private void RedrawAllShapes()
        {
            drawablePictureBox.Image = new Bitmap(drawablePictureBox.Width, drawablePictureBox.Height);
            foreach (Shapes.Shape shape in CreatedShapes)
            {
                if(IsApplyingAntyAliasing)
                    drawablePictureBox.Image = shape.DrawWithAntiAliasing((Bitmap)drawablePictureBox.Image);
                else
                    drawablePictureBox.Image = shape.Draw((Bitmap)drawablePictureBox.Image);
            }
        }

        private void AddNewButton(Shapes.Shape shape, int i)
        {
            Panel ParentPanel = panelCreatedShapesList;
            ParentPanel.Height = ParentPanel.Height + 30;

            Panel panel = new Panel();
            panel.Width = ParentPanel.Width;
            panel.Height = 30;
            panel.Name = i.ToString();

            if(shape is Shapes.Line || shape is Shapes.Polygon)
            {
                NumericUpDown editor = new NumericUpDown();
                editor.Width = 35;
                editor.Height = 23;
                editor.Minimum = 1;
                if (shape is Shapes.Line)
                    editor.Value = (shape as Shapes.Line).BrushThickness;
                else
                    editor.Value = (shape as Shapes.Polygon).BrushThickness;
                editor.Maximum = 100;
                editor.Increment = 2;
                editor.Location = new Point(120, 3);
                editor.ValueChanged += new EventHandler(ChangeElementsThickness);
                panel.Controls.Add(editor);
            }
            

            PictureBox img = new PictureBox();
            img.Width = 20;
            img.Height = 20;
            img.BorderStyle = BorderStyle.FixedSingle;
            img.BackColor = shape.BrushColor;
            img.Location = new Point(160, 5);
            img.Margin = new Padding(5, 5, 5, 5);
            img.Click += new EventHandler(ChangeElementsColor);
            panel.Controls.Add(img);


            Button deleteBtn = new Button();
            deleteBtn.Dock = DockStyle.Left;
            deleteBtn.Text = "Delete";
            deleteBtn.Width = 50;
            deleteBtn.Margin = new Padding(3, 3, 3, 3);
            deleteBtn.TextAlign = ContentAlignment.MiddleLeft;
            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.Parent = panel;
            deleteBtn.Click += new EventHandler(DeleteElement);
            panel.Controls.Add(deleteBtn);

            Label name = new Label();
            name.Dock = DockStyle.Left;
            name.Text =  shape.GetName();
            name.Width = 60;
            name.Margin = new Padding(3, 3, 3, 3);
            name.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(name);

            ParentPanel.Controls.Add(panel);
            panel.Dock = DockStyle.Top;
        }

        private void DeleteElement(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            for(int i = 0; i < panelCreatedShapesList.Controls.Count; i++)
            {
                if (i.ToString() == btn.Parent.Name)
                {
                    CreatedShapes.RemoveAt(i);
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                    return;
                }

            }
        }

        private void ChangeElementsThickness(object sender, EventArgs e)
        {
            NumericUpDown btn = (NumericUpDown)sender;
            for (int i = 0; i < panelCreatedShapesList.Controls.Count; i++)
            {
                if (i.ToString() == btn.Parent.Name)
                {
                    if (CreatedShapes[i] is Shapes.Line)
                        (CreatedShapes[i] as Shapes.Line).BrushThickness = (int)btn.Value;
                    else
                        (CreatedShapes[i] as Shapes.Polygon).BrushThickness = (int)btn.Value;
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                    return;
                }

            }
        }

        private void ChangeElementsColor(object sender, EventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            for (int i = 0; i < panelCreatedShapesList.Controls.Count; i++)
            {
                if (i.ToString() == btn.Parent.Name)
                {
                    ColorDialog dialog = new ColorDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        CreatedShapes[i].BrushColor = dialog.Color;
                        SelectedVertices.Clear();
                        RedrawAllShapes();
                        RerenderControls();
                        CheckOffAnyDrawing();
                    }
                    return;
                }

            }
        }

        private void CheckOffAnyDrawing()
        {
            IsDrawingCycle = false;
            IsDrawingLine = false;
            IsDrawingPolygon = false;
            IsDrawingCapsule = false;
            IsDrawingRectangle = false;
        }

        private bool CheckProximity(Point first, Point second, double value)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2)) < value ? true : false;
        }

        private void togglePanelVisibility(Panel panel)
        {
            if (panel == null)
                return;

            if (panel.Visible == true)
                panel.Visible = false;
            else panel.Visible = true;
        }

        private void btnGeneralSettings_Click(object sender, EventArgs e)
        {
            togglePanelVisibility(panelGeneralSettings);
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                ChosenColor = dialog.Color;
                pictureBoxChosenColor.BackColor = dialog.Color;
            }
        }

        private void editorChangeLineThickness_ValueChanged(object sender, EventArgs e)
        {
            ChosenThickness = (int)(sender as NumericUpDown).Value;
        }

        private void btnDrawShape_Click(object sender, EventArgs e)
        {
            togglePanelVisibility(panelDrawShape);
        }

        private void btnAntiAliasing_Click(object sender, EventArgs e)
        {
            togglePanelVisibility(panelAntiAliasing);
        }

        private void btnFileOptions_Click(object sender, EventArgs e)
        {
            togglePanelVisibility(panelFileOptions);
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            SelectedVertices.Clear();
            CheckOffAnyDrawing();
            IsDrawingLine = true;
        }

        private void btnShapesList_Click(object sender, EventArgs e)
        {
            togglePanelVisibility(panelCreatedShapesList);
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            SelectedVertices.Clear();
            CheckOffAnyDrawing();
            IsDrawingCycle = true;
        }

        private void btnDrawPolygon_Click(object sender, EventArgs e)
        {
            SelectedVertices.Clear();
            CheckOffAnyDrawing();
            IsDrawingPolygon = true;
        }

       
        private void drawablePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point recordedPosition = new Point(e.Location.X, e.Location.Y);
            if(IsDrawingLine)
            {
                SelectedVertices.Add(recordedPosition);
                if (SelectedVertices.Count == 2)
                {
                    CreatedShapes.Add(new Shapes.Line(SelectedVertices[0], SelectedVertices[1], ChosenColor, ChosenThickness));
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                }
            }

            if(IsDrawingPolygon)
            {
                SelectedVertices.Add(recordedPosition);
                if (SelectedVertices.Count < 2)
                    return;
                if(CheckProximity(recordedPosition, SelectedVertices[0], 10))
                {
                    CreatedShapes.Add(new Shapes.Polygon(SelectedVertices, ChosenColor, ChosenThickness));
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                    return;
                }
                Shapes.Line line = new Shapes.Line(SelectedVertices[SelectedVertices.Count - 2], SelectedVertices[SelectedVertices.Count - 1], ChosenColor, ChosenThickness);
                drawablePictureBox.Image = (Bitmap)line.Draw((Bitmap)drawablePictureBox.Image);
            }

            if(IsDrawingCycle)
            {
                SelectedVertices.Add(recordedPosition);
                if (SelectedVertices.Count == 2)
                {
                    CreatedShapes.Add(new Shapes.Circle(SelectedVertices[0], SelectedVertices[1], ChosenColor));
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                }
            }

            if(IsDrawingCapsule)
            {
                SelectedVertices.Add(recordedPosition);
                if (SelectedVertices.Count == 3)
                {
                    CreatedShapes.Add(new Shapes.Capsule(SelectedVertices[0], SelectedVertices[1], SelectedVertices[2], ChosenColor));
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                }
            }

            if(IsDrawingRectangle)
            {
                SelectedVertices.Add(recordedPosition);
                if (SelectedVertices.Count == 2)
                {
                    SelectedVertices.Add(new Point(SelectedVertices[1].X, SelectedVertices[0].Y));
                    SelectedVertices.Add(new Point(SelectedVertices[0].X, SelectedVertices[1].Y));

                    List<Point> verticesInOrder = new List<Point>();
                    verticesInOrder.Add(SelectedVertices[0]);
                    verticesInOrder.Add(SelectedVertices[2]);
                    verticesInOrder.Add(SelectedVertices[1]);
                    verticesInOrder.Add(SelectedVertices[3]);

                    CreatedShapes.Add(new Shapes.Rectangle(verticesInOrder,  ChosenColor, ChosenThickness));
                    SelectedVertices.Clear();
                    RedrawAllShapes();
                    RerenderControls();
                    CheckOffAnyDrawing();
                }
            }
            
        }

        private void brnXiaolinWu_Click(object sender, EventArgs e)
        {
            IsApplyingAntyAliasing = true;
            RedrawAllShapes();
        }

        private void btnXiaolinWuOff_Click(object sender, EventArgs e)
        {
            IsApplyingAntyAliasing = false;
            RedrawAllShapes();
        }

        private void drawablePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            foreach(Shapes.Shape shape in CreatedShapes)
            {
                if(shape is Shapes.Circle)
                {
                    Shapes.Circle circle = (Shapes.Circle)shape;
                    if (circle.HitTest(e.Location))
                    {
                        IsMovingCircle = true;
                        circle.IsSelected = true;
                        MouseX = e.Location.X;
                        MouseY = e.Location.Y;
                        return;
                    }
                }
                if(shape is Shapes.Line)
                {
                    Shapes.Line line = (Shapes.Line)shape;
                    if(line.HitTest(e.Location))
                    {
                        IsMovingLine = true;
                        line.IsSelected = true;
                        MouseX = e.Location.X;
                        MouseY = e.Location.Y;
                        return;
                    }
                }
                if (shape is Shapes.Rectangle)
                {
                    Shapes.Rectangle rec = (Shapes.Rectangle)shape;
                    if (rec.HitTest(e.Location))
                    {
                        IsMovingRectangle = true;
                        rec.IsSelected = true;
                        MouseX = e.Location.X;
                        MouseY = e.Location.Y;
                        return;
                    }
                }
                if (shape is Shapes.Polygon)
                {
                    Shapes.Polygon plg = (Shapes.Polygon)shape;
                    if (plg.HitTest(e.Location))
                    {
                        IsMovingPolygon = true;
                        plg.IsSelected = true;
                        MouseX = e.Location.X;
                        MouseY = e.Location.Y;
                        return;
                    }
                }
            }    
        }

        private void drawablePictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMovingCircle)
            {
                IsMovingCircle = false;
                SelectedVertices.Clear();
                RedrawAllShapes();
                RerenderControls();
                CheckOffAnyDrawing();
                return;
            }

            if (IsMovingLine)
            {
                IsMovingLine = false;
                SelectedVertices.Clear();
                RedrawAllShapes();
                RerenderControls();
                CheckOffAnyDrawing();
                return;
            }

            if (IsMovingRectangle)
            {
                IsMovingRectangle = false;
                SelectedVertices.Clear();
                RedrawAllShapes();
                RerenderControls();
                CheckOffAnyDrawing();
                return;
            }

            if (IsMovingPolygon)
            {
                IsMovingPolygon = false;
                SelectedVertices.Clear();
                RedrawAllShapes();
                RerenderControls();
                CheckOffAnyDrawing();
                return;
            }
        }

        private void drawablePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsMovingCircle)
            {
                foreach (Shapes.Shape shape in CreatedShapes)
                {
                    if (shape is Shapes.Circle)
                    {
                        Shapes.Circle circle = (Shapes.Circle)shape;
                        if (circle.IsSelected)
                        {
                            if(e.Button == MouseButtons.Left)
                            {
                                
                                Point ctr = new Point(circle.Center.X + e.Location.X - MouseX, circle.Center.Y + e.Location.Y - MouseY);
                                circle.Center = ctr;
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                            else if(e.Button == MouseButtons.Right)
                            {
                                circle.Radius = (int)Math.Sqrt(Math.Pow(MouseX - circle.Center.X, 2) + Math.Pow(MouseY - circle.Center.Y, 2));
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                        }
                    }

                }
            }

            else if(IsMovingLine)
            {
                foreach(Shapes.Shape shape in CreatedShapes)
                {
                    if(shape is Shapes.Line)
                    {
                        Shapes.Line line = (Shapes.Line)shape;
                        if(line.IsSelected)
                        {
                            if(line.HitFirst(e.Location))
                            {
                                Point ctr = new Point(line.FirstVertex.X + e.Location.X - MouseX, line.FirstVertex.Y + e.Location.Y - MouseY);
                                line.FirstVertex = ctr;
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                            else
                            {
                                Point ctr = new Point(line.SecondVertex.X + e.Location.X - MouseX, line.SecondVertex.Y + e.Location.Y - MouseY);
                                line.SecondVertex = ctr;
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                        }
                    }
                }
            }

            else if(IsMovingRectangle)
            {
                foreach(Shapes.Shape shape in CreatedShapes)
                {
                    if(shape is Shapes.Rectangle)
                    {
                        Shapes.Rectangle rectangle = (Shapes.Rectangle)shape;
                        if(rectangle.IsSelected)
                        {
                            if (e.Button == MouseButtons.Right)
                            {
                                List<Point> points = new List<Point>();
                                foreach (Point pt in rectangle.Vertices)
                                {
                                    points.Add(new Point(pt.X + e.Location.X - MouseX, pt.Y + e.Location.Y - MouseY));
                                }
                                rectangle.Vertices = points;
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                            else if (e.Button == MouseButtons.Left)
                            {
                                List<Point> points = new List<Point>();
                                foreach (Point pt in rectangle.Vertices)
                                {
                                    if (rectangle.HitTheVertex(e.Location, pt))
                                    {
                                        if (pt == rectangle.Vertices[0])
                                        {

                                            int x1 = pt.X + e.Location.X - MouseX;
                                            int x2 = rectangle.Vertices[1].X;
                                            int y1 = pt.Y + e.Location.Y - MouseY;
                                            int y2 = rectangle.Vertices[2].Y;

                                            points.Add(new Point(x1, y1));
                                            points.Add(new Point(x2, y1));
                                            points.Add(new Point(x2, y2));
                                            points.Add(new Point(x1, y2));
                                        }
                                        else if (pt == rectangle.Vertices[1])
                                        {
                                            int x2 = pt.X + e.Location.X - MouseX;
                                            int x1 = rectangle.Vertices[0].X;
                                            int y1 = pt.Y + e.Location.Y - MouseY;
                                            int y2 = rectangle.Vertices[2].Y;

                                            points.Add(new Point(x1, y1));
                                            points.Add(new Point(x2, y1));
                                            points.Add(new Point(x2, y2));
                                            points.Add(new Point(x1, y2));
                                        }
                                        else if (pt == rectangle.Vertices[2])
                                        {
                                            int x2 = pt.X + e.Location.X - MouseX;
                                            int x1 = rectangle.Vertices[0].X;
                                            int y2 = pt.Y + e.Location.Y - MouseY;
                                            int y1 = rectangle.Vertices[1].Y;

                                            points.Add(new Point(x1, y1));
                                            points.Add(new Point(x2, y1));
                                            points.Add(new Point(x2, y2));
                                            points.Add(new Point(x1, y2));
                                        }
                                        else
                                        {
                                            int x1 = pt.X + e.Location.X - MouseX;
                                            int x2 = rectangle.Vertices[1].X;
                                            int y2 = pt.Y + e.Location.Y - MouseY;
                                            int y1 = rectangle.Vertices[1].Y;

                                            points.Add(new Point(x1, y1));
                                            points.Add(new Point(x2, y1));
                                            points.Add(new Point(x2, y2));
                                            points.Add(new Point(x1, y2));
                                        }
                                        MouseX = e.Location.X;
                                        MouseY = e.Location.Y;
                                        rectangle.Vertices = points;
                                        return;
                                    }
                                }

                                Point p1;
                                Point p2;
                                Point p3 = e.Location;
                                for (int i = 0; i < rectangle.Vertices.Count - 1; i++)
                                {
                                    p1 = rectangle.Vertices[i];
                                    p2 = rectangle.Vertices[i + 1];
                                    if (rectangle.HitBetweenVertices(p1, p2, p3))
                                    {
                                        if(p1 == rectangle.Vertices[0] || p1 == rectangle.Vertices[2])
                                        {
                                            rectangle.Vertices[i] = new Point(p1.X, p2.Y + e.Location.Y - MouseY);
                                            rectangle.Vertices[i + 1] = new Point(p2.X, p2.Y + e.Location.Y - MouseY);
                                        }
                                        else
                                        {
                                            rectangle.Vertices[i] = new Point(p1.X + e.Location.X - MouseX, p1.Y);
                                            rectangle.Vertices[i + 1] = new Point(p2.X + e.Location.X - MouseX, p2.Y);
                                        }
                                        return;
                                    }
                                    p1 = rectangle.Vertices[3];
                                    p2 = rectangle.Vertices[0];
                                    if (rectangle.HitBetweenVertices(p1, p2, p3))
                                    {
                                        rectangle.Vertices[3] = new Point(p1.X + e.Location.X - MouseX, p1.Y);
                                        rectangle.Vertices[0] = new Point(p2.X + e.Location.X - MouseX, p2.Y);
                                        return;
                                    }
                                }
                            }
                            return;
                        }
                    }
                }
            }

            else if(IsMovingPolygon)
            {
                foreach(Shapes.Shape shape in CreatedShapes)
                {
                    if(shape is Shapes.Polygon)
                    {
                        Shapes.Polygon polygon = (Shapes.Polygon)shape;
                        if(polygon.IsSelected)
                        {
                            if(e.Button == MouseButtons.Right)
                            {
                                List<Point> points = new List<Point>();
                                foreach(Point pt in polygon.Vertices)
                                {
                                    points.Add(new Point(pt.X + e.Location.X - MouseX, pt.Y + e.Location.Y - MouseY));
                                }
                                polygon.Vertices = points;
                                MouseX = e.Location.X;
                                MouseY = e.Location.Y;
                            }
                            else if(e.Button == MouseButtons.Left)
                            {
                                bool vertexFlag = false;
                                List<Point> points = new List<Point>();
                                foreach (Point pt in polygon.Vertices)
                                {
                                    if(polygon.HitTheVertex(e.Location, pt))
                                    {
                                        points.Add(new Point(pt.X + e.Location.X - MouseX, pt.Y + e.Location.Y - MouseY));
                                        vertexFlag = true;
                                        MouseX = e.Location.X;
                                        MouseY = e.Location.Y;
                                    }
                                    else
                                    {
                                        points.Add(pt);
                                    }
                                }
                                polygon.Vertices = points;
                                if (vertexFlag) return;

                                Point p1;
                                Point p2;
                                Point p3 = e.Location;
                                for (int i = 0; i < polygon.Vertices.Count - 1; i++)
                                {
                                    p1 = polygon.Vertices[i];
                                    p2 = polygon.Vertices[i + 1];
                                    if(polygon.HitBetweenVertices(p1, p2, p3))
                                    {
                                        polygon.Vertices[i] = new Point(p1.X + e.Location.X - MouseX, p1.Y + e.Location.Y - MouseY);
                                        polygon.Vertices[i + 1] = new Point(p2.X + e.Location.X - MouseX, p2.Y + e.Location.Y - MouseY);
                                        return;
                                    }
                                }
                                p1 = polygon.Vertices[polygon.Vertices.Count - 1];
                                p2 = polygon.Vertices[0];
                                if (polygon.HitBetweenVertices(p1, p2, p3))
                                {
                                    polygon.Vertices[polygon.Vertices.Count - 1] = new Point(p1.X + e.Location.X - MouseX, p1.Y + e.Location.Y - MouseY);
                                    polygon.Vertices[0] = new Point(p2.X + e.Location.X - MouseX, p2.Y + e.Location.Y - MouseY);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnCapsule_Click(object sender, EventArgs e)
        {
            IsDrawingCapsule = false;
            MessageBox.Show("Laboratory task\nSwitched off for homework part");
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Shape files (*.shapes)|*.shapes";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file = new StreamWriter(dialog.FileName))
                {
                    foreach(Shapes.Shape shape in CreatedShapes)
                    {
                        file.WriteLine(shape);
                    }
                    file.Close();
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Shape files (*.shapes)|*.shapes";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamReader file = new StreamReader(dialog.FileName))
                {
                    try
                    {
                        CreatedShapes.Clear();
                        RedrawAllShapes();
                        RerenderControls();

                        List<string> lines = new List<string>();
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }

                        Shapes.Polygon plg = null;
                        foreach(string newLine in lines)
                        {
                            char[] delimiter = { ' ' };
                            string[] words = newLine.Split(delimiter);
                            if(words[0] == "Line")
                            {
                                if(plg != null)
                                {
                                    CreatedShapes.Add(plg);
                                    plg = null;
                                }
                                Point p1 = new Point(int.Parse(words[1]), int.Parse(words[2]));
                                Point p2 = new Point(int.Parse(words[3]), int.Parse(words[4]));
                                Color clr = Color.FromArgb(int.Parse(words[6]), int.Parse(words[7]), int.Parse(words[8]));
                                int thickness = int.Parse(words[5]);
                                Shapes.Line ln = new Shapes.Line(p1, p2, clr, thickness);
                                CreatedShapes.Add(ln);
                            }
                            else if(words[0] == "Circle")
                            {
                                if (plg != null)
                                {
                                    CreatedShapes.Add(plg);
                                    plg = null;
                                }
                                Point pt = new Point(int.Parse(words[1]), int.Parse(words[2]));
                                Color clr = Color.FromArgb(int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]));
                                int r = int.Parse(words[6]);
                                Shapes.Circle cir = new Shapes.Circle(pt, r, clr);
                                CreatedShapes.Add(cir);
                            }
                            else if(words[0] == "Polygon")
                            {
                                if (plg != null)
                                {
                                    CreatedShapes.Add(plg);
                                    plg = null;
                                }
                                Color clr = Color.FromArgb(int.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]));
                                int thickness = int.Parse(words[4]);
                                plg = new Shapes.Polygon(clr, thickness);
                            }
                            else
                            {
                                if(plg != null)
                                {
                                    Point pt = new Point(int.Parse(words[0]), int.Parse(words[1]));
                                    plg.Vertices.Add(pt);
                                }
                            }
                        }
                        if(plg != null)
                        {
                            CreatedShapes.Add(plg);
                        }


                    }
                    catch
                    {
                        MessageBox.Show("Error when trying to read data from the file!");
                    }
                    file.Close();
                    RedrawAllShapes();
                    RerenderControls();
                }
            }
        }

        private void btnDeleteAllShapes_Click(object sender, EventArgs e)
        {
            CreatedShapes.Clear();
            RedrawAllShapes();
            RerenderControls();
            CheckOffAnyDrawing();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            SelectedVertices.Clear();
            CheckOffAnyDrawing();
            IsDrawingRectangle = true;
        }
    }
}
