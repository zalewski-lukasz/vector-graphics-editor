﻿using System;
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

        private bool OnSegment(Point p, Point q, Point r)
        {
            if (q.x <= Math.Max(p.x, r.x) && q.x >= Math.Min(p.x, r.x) &&
                q.y <= Math.Max(p.y, r.y) && q.y >= Math.Min(p.y, r.y))
                return true;

            return false;
        }

        private int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) -
                    (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0; 

            return (val > 0) ? 1 : 2;
        }

        private bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are colinear and p2 lies on segment p1q1
            if (o1 == 0 && OnSegment(p1, p2, q1)) return true;

            // p1, q1 and q2 are colinear and q2 lies on segment p1q1
            if (o2 == 0 && OnSegment(p1, q2, q1)) return true;

            // p2, q2 and p1 are colinear and p1 lies on segment p2q2
            if (o3 == 0 && OnSegment(p2, p1, q2)) return true;

            // p2, q2 and q1 are colinear and q1 lies on segment p2q2
            if (o4 == 0 && OnSegment(p2, q1, q2)) return true;

            return false; // Doesn't fall in any of the above cases
        }

        public bool CanTrim(Shapes.Polygon poly)
        {
            List<Point> pointsFirst = Vertices;
            pointsFirst.Add(Vertices[0]);

            List<Point> pointsSecond = poly.Vertices;
            pointsSecond.Add(poly.Vertices[0]);

            for(int i = 0; i < pointsFirst.Count - 1; i++)
            {
                for(int j = 0; j < pointsSecond.Count - 1; j++)
                {
                    if (DoIntersect(pointsFirst[i], pointsFirst[i + 1], pointsSecond[i], pointsSecond[i + 1]))
                    {
                        MessageBox.Show("yes");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
