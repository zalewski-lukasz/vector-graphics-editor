using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorUI.Shapes
{
    public class Polygon : Shape
    {
        public List<Point> Vertices { get; set; }
        public Color FillColor { get; set; }
        public Bitmap FillImage { get; set; }
        public string ImageFileName { get; set; }
        public List<AETNode> PolygonTable { get; set; }
        private int TempMinimalY { get; set; }
        Dictionary<int, List<AETNode>> EdgeTable { get; set; }

        public override string GetName()
        {
            return "Polygon";
        }

        public Polygon(List<Point> points, Color color, int thickness)
        {
            FillColor = Color.FromArgb(255, 255, 255);
            FillImage = null;
            BrushThickness = thickness;
            Vertices = new List<Point>();
            PolygonTable = new List<AETNode>();
            EdgeTable = new Dictionary<int, List<AETNode>>();

            foreach(Point vertex in points)
            {
                Vertices.Add(vertex);
            }
            BrushColor = color;
        }

        public void RemoveImageFilling()
        {
            FillImage = null;
        }

        public void RemoveColorFilling()
        {
            FillColor = Color.FromArgb(255, 255, 255);
        }

        private bool HasNoImageFilling()
        {
            return FillImage == null ? true : false;
        }

        private bool HasNoColorFilling()
        {
            return FillColor == Color.FromArgb(255, 255, 255) ? true : false;
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
            try
            {
                newBmp = (new Shapes.Line(Vertices[Vertices.Count - 1], Vertices[0], BrushColor, BrushThickness)).Draw(newBmp);
            }
            catch
            { }

            newBmp = Fill(newBmp);

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
            string result = $"Polygon {BrushColor.R} {BrushColor.G} {BrushColor.B} {BrushThickness}";
            if(FillImage == null)
                result = $"Polygon {BrushColor.R} {BrushColor.G} {BrushColor.B} {BrushThickness} null {FillColor.R} {FillColor.G} {FillColor.B}";
            else
                result = $"Polygon {BrushColor.R} {BrushColor.G} {BrushColor.B} {BrushThickness} {ImageFileName} {FillColor.R} {FillColor.G} {FillColor.B}";
            foreach (Point pnt in Vertices)
            {
                result += (Environment.NewLine + $"{pnt.X} {pnt.Y}");
            }
            return result;
        }

        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            return (BAx * BCy - BAy * BCx);
        }

        public List<Point> PointsToFill()
        {
            ActiveEdgeTable tmpAET = new ActiveEdgeTable(this);
            List<AETNode> tmp = tmpAET.Nodes.OrderBy(x => x.NodeMinY).ToList();
            TempMinimalY = tmp[0].NodeMinY;
            int tempY = TempMinimalY;

            while (tmp.Count != 0)
            {
                if (tmp.Where(x => x.NodeMinY == tempY).Count() != 0)
                {
                    List<AETNode> bucketTable = tmp.Where(x => x.NodeMinY == tempY).ToList();
                    tmp.RemoveAll(x => x.NodeMinY == tempY);
                    if (EdgeTable == null)
                        EdgeTable = new Dictionary<int, List<AETNode>>();
                    EdgeTable.Add(tempY, bucketTable.OrderBy(x => x.ValX).ToList());
                }
                tempY++;
            }

            List<Point> pointsFill = new List<Point>();
            int y = TempMinimalY;
            if (PolygonTable == null)
                PolygonTable = new List<AETNode>();
            PolygonTable.Clear();
            do
            {
                List<AETNode> bucket;
                if (EdgeTable.TryGetValue(y, out bucket))
                {
                    PolygonTable.AddRange(bucket);

                }

                PolygonTable = PolygonTable.OrderBy(x => x.ValX).ToList();

                for (int i = 0; i < PolygonTable.Count - 1; i += 2)
                {
                    int x = (int)PolygonTable[i].ValX;
                    while (x != PolygonTable[i + 1].ValX)
                    {
                        pointsFill.Add(new Point(x, y));
                        x++;
                    }
                }
                y++;
                PolygonTable.RemoveAll(x => x.NodeMaxY == y);
                foreach (AETNode chosenNode in PolygonTable)
                {
                    chosenNode.HelperVariable += chosenNode.dx;
                    if (chosenNode.HelperVariable > chosenNode.dy)
                    {
                        int k;
                        try
                        {
                            k = chosenNode.HelperVariable / chosenNode.dy;
                        }
                        catch (Exception e)
                        {
                            k = int.MaxValue;
                        }
                        chosenNode.ValX += k * chosenNode.CoefficientSign;
                        chosenNode.HelperVariable -= k * chosenNode.dy;
                    }
                }
            }
            while (PolygonTable.Count > 0);
            EdgeTable.Clear();
            return pointsFill;
        }

        public Bitmap Fill(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);
            if (HasNoColorFilling() && HasNoImageFilling())
                return newBmp;

            if(HasNoImageFilling())
            {
                foreach(Point pnt in PointsToFill())
                {
                    newBmp.SetPixel(pnt.X, pnt.Y, FillColor);
                }
                return newBmp;
            }

            if(HasNoColorFilling())
            {
                foreach (Point pnt in PointsToFill())
                {
                    newBmp.SetPixel(pnt.X, pnt.Y, FillImage.GetPixel(pnt.X, pnt.Y));
                }
                return newBmp;
            }

            return newBmp;
        }

        public bool CanTrim(Shapes.Polygon poly)
        {
            List<Point> pointsFirst = Vertices;
            pointsFirst.Add(Vertices[0]);

            List<Point> pointsSecond = poly.Vertices;
            pointsSecond.Add(poly.Vertices[0]);

            for (int i = 0; i < pointsFirst.Count - 1; i++)
            {
                for (int j = 0; j < pointsSecond.Count - 1; j++)
                {
                    if (DoIntersect(pointsFirst[i], pointsFirst[i + 1], pointsSecond[i], pointsSecond[i + 1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool OnSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
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

            if (o1 != o2 && o3 != o4)
                return true;

            if (o1 == 0 && OnSegment(p1, p2, q1)) return true;

            if (o2 == 0 && OnSegment(p1, q2, q1)) return true;

            if (o3 == 0 && OnSegment(p2, p1, q2)) return true;

            if (o4 == 0 && OnSegment(p2, q1, q2)) return true;

            return false; 
        }

        // based on https://rosettacode.org/wiki/Sutherland-Hodgman_polygon_clipping

        public Polygon GetClippedPolygon(List<Point> clipPoly)
        {
            if (Vertices.Count < 3 || clipPoly.Count < 3)
            {
                MessageBox.Show("Clipping cannot be accomplished - number of the vertices for one of the polygons is too low");
                return this;
            }

            List<Point> outputList = Vertices;
            if (!IsClockwise(Vertices))
            {
                outputList.Reverse();
            }

            foreach (Line clipLine in IterateEdgesClockwise(clipPoly))
            {
                List<Point> inputList = outputList.ToList();
                outputList.Clear();

                if (inputList.Count == 0)
                {

                    break;
                }

                Point S = inputList[inputList.Count - 1];

                foreach (Point E in inputList)
                {
                    if (IsInside(clipLine, E))
                    {
                        if (!IsInside(clipLine, S))
                        {
                            Point? point = GetIntersect(S, E, clipLine.FirstVertex, clipLine.SecondVertex);
                            if (point == null)
                            {
                                throw new ApplicationException("Line segments don't intersect");
                            }
                            else
                            {
                                outputList.Add(point.Value);
                            }
                        }

                        outputList.Add(E);
                    }
                    else if (IsInside(clipLine, S))
                    {
                        Point? point = GetIntersect(S, E, clipLine.FirstVertex, clipLine.SecondVertex);
                        if (point == null)
                        {
                            throw new ApplicationException("Line segments don't intersect");
                        }
                        else
                        {
                            outputList.Add(point.Value);
                        }
                    }

                    S = E;
                }
            }

            Polygon poly = new Polygon(outputList, BrushColor, BrushThickness);
            poly.FillImage = FillImage;
            poly.FillColor = FillColor;

            return poly;
        }


        private IEnumerable<Line> IterateEdgesClockwise(List<Point> polygon)
        {
            if (IsClockwise(polygon))
            {

                for (int cntr = 0; cntr < polygon.Count - 1; cntr++)
                {
                    yield return new Line(polygon[cntr], polygon[cntr + 1], BrushColor, BrushThickness);
                }

                yield return new Line(polygon[polygon.Count - 1], polygon[0], BrushColor, BrushThickness);

            }
            else
            {

                for (int cntr = polygon.Count - 1; cntr > 0; cntr--)
                {
                    yield return new Line(polygon[cntr], polygon[cntr - 1], BrushColor, BrushThickness);
                }

                yield return new Line(polygon[0], polygon[polygon.Count - 1], BrushColor, BrushThickness);

            }
        }

        private static Point? GetIntersect(Point line1From, Point line1To, Point line2From, Point line2To)
        {
            Point direction1 = new Point(line1To.X - line1From.X, line1To.Y - line1From.Y);
            Point direction2 = new Point(line2To.X - line2From.X, line2To.Y - line2From.Y);
            double dotPerp = (direction1.X * direction2.Y) - (direction1.Y * direction2.X);

            if (IsNearZero(dotPerp))
            {
                return null;
            }

            Point c = new Point(line2From.X - line1From.X, line2From.Y - line1From.Y);
            double t = (c.X * direction2.Y - c.Y * direction2.X) / dotPerp;

            Point temp = new Point(line1From.X + (int)(t * direction1.X), line1From.Y + (int)(t * direction1.Y));
            return temp;
        }

        private static bool IsInside(Line line, Point test)
        {
            bool? isLeft = IsLeftOf(line, test);
            if (isLeft == null)
            {
                return true;
            }

            return !isLeft.Value;
        }
        private bool IsClockwise(List<Point> poly)
        {
            for (int i = 2; i < poly.Count; i++)
            {
                bool? isLeft = IsLeftOf(new Line(poly[0], poly[1], BrushColor, BrushThickness), poly[i]);
                if (isLeft != null)
                {
                    return !isLeft.Value;
                }
            }

            throw new ArgumentException("All the points in the polygon are colinear");
        }

        private static bool? IsLeftOf(Line edge, Point test)
        {
            Point tmp1 = new Point(edge.SecondVertex.X - edge.FirstVertex.X, edge.SecondVertex.Y - edge.FirstVertex.Y);
            Point tmp2 = new Point(test.X - edge.SecondVertex.X, test.Y - edge.SecondVertex.Y);

            double x = (tmp1.X * tmp2.Y) - (tmp1.Y * tmp2.X);

            if (x < 0)
            {
                return false;
            }
            else if (x > 0)
            {
                return true;
            }
            else
            {
                return null;
            }
        }

        private static bool IsNearZero(double testValue)
        {
            return Math.Abs(testValue) <= .000000001d;
        }

        
    }
}
