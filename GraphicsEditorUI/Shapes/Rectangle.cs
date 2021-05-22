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
    }
}
