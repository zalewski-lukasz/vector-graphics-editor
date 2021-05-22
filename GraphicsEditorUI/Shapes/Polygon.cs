using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorUI.Shapes
{
    public class Polygon : Shape
    {
        public List<Point> Vertices { get; set; }

        public override string GetName()
        {
            return "Polygon";
        }

        public Polygon(List<Point> points, Color color, int thickness)
        {
            BrushThickness = thickness;
            Vertices = new List<Point>();
            foreach(Point vertex in points)
            {
                Vertices.Add(vertex);
            }
            BrushColor = color;
        }

        public Polygon(Color clr, int thickness)
        {
            BrushColor = clr;
            BrushThickness = thickness;
            Vertices = new List<Point>();
        }

        public override Bitmap Draw(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);

            for(int i = 0; i < Vertices.Count - 1; i++)
            {
                newBmp = (new Shapes.Line(Vertices[i], Vertices[i + 1], BrushColor, BrushThickness)).Draw(newBmp);
            }
            newBmp = (new Shapes.Line(Vertices[Vertices.Count - 1], Vertices[0], BrushColor, BrushThickness)).Draw(newBmp);
            return newBmp;
        }

        public override Bitmap DrawWithAntiAliasing(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);

            for (int i = 0; i < Vertices.Count - 1; i++)
            {
                newBmp = (new Shapes.Line(Vertices[i], Vertices[i + 1], BrushColor, BrushThickness)).DrawWithAntiAliasing(newBmp);
            }
            newBmp = (new Shapes.Line(Vertices[Vertices.Count - 1], Vertices[0], BrushColor, BrushThickness)).DrawWithAntiAliasing(newBmp);
            return newBmp;
        }

        public double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        public bool HitTest(Point point)
        {
            Point p1;
            Point p2;
            for (int i = 0; i < Vertices.Count - 1; i++)
            {
                p1 = Vertices[i];
                p2 = Vertices[i + 1];
                if (Math.Abs(GetDistance(p1, p2) - GetDistance(p1, point) - GetDistance(p2, point)) < 0.5) return true;
            }
            p1 = Vertices[Vertices.Count - 1];
            p2 = Vertices[0];
            if (Math.Abs(GetDistance(p1, p2) - GetDistance(p1, point) - GetDistance(p2, point)) < 0.5) return true;
            return false;
        }

        public bool HitTheVertex(Point p1, Point p2)
        {
            if ((p1.X < p2.X + BrushThickness + 2 && p1.X > p2.X - BrushThickness - 2) &&
                (p1.Y < p2.Y + BrushThickness + 2 && p1.Y > p2.Y - BrushThickness - 2))
                return true;

            return false;
        }

        public bool HitBetweenVertices(Point p1, Point p2, Point p3)
        {
            return (Math.Abs(GetDistance(p1, p2) - GetDistance(p1, p3) - GetDistance(p2, p3)) < 0.5);
        }

        public override string ToString()
        {
            string result =  $"Polygon {BrushColor.R} {BrushColor.G} {BrushColor.B} {BrushThickness}";
            foreach(Point pnt in Vertices)
            {
                result += (Environment.NewLine + $"{pnt.X} {pnt.Y}");
            }
            return result;
        }
    }
}
