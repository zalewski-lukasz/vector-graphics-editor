using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditorUI.Shapes
{
    public class Rectangle : Polygon
    {
        public Rectangle(List<Point> points, Color color, int thickness) : base(points, color, thickness) { }

        public Rectangle(Color color, int thickness) : base(color, thickness) { }

        public override string GetName()
        {
            return "Rectangle";
        }

        public override string ToString()
        {
            string result = $"Rectangle {BrushColor.R} {BrushColor.G} {BrushColor.B} {BrushThickness}";
            foreach (Point pnt in Vertices)
            {
                result += (Environment.NewLine + $"{pnt.X} {pnt.Y}");
            }
            return result;
        }

        public override Bitmap Draw(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);

            newBmp = (new Shapes.Line(Vertices[0], Vertices[1], BrushColor, BrushThickness)).Draw(newBmp);
            newBmp = (new Shapes.Line(Vertices[2], Vertices[3], BrushColor, BrushThickness)).Draw(newBmp);

            if(Vertices[0].Y < Vertices[2].Y)
            {
                newBmp = (new Shapes.Line(Vertices[0], Vertices[3], BrushColor, BrushThickness)).Draw(newBmp);
                newBmp = (new Shapes.Line(Vertices[1], Vertices[2], BrushColor, BrushThickness)).Draw(newBmp);
            }
            else
            {
                newBmp = (new Shapes.Line(Vertices[3], Vertices[0], BrushColor, BrushThickness)).Draw(newBmp);
                newBmp = (new Shapes.Line(Vertices[2], Vertices[1], BrushColor, BrushThickness)).Draw(newBmp);
            }

            return newBmp;
        }
    }
}
