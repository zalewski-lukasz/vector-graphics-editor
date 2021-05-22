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
    public class Capsule : Shape
    {
        public Point FirstVertex {get; set;}
        public Point SecondVertex { get; set; }
        public Point ThirdVertex { get; set; }
        public double Radius { get; set; }

        public override string GetName()
        {
            return "Capsule";
        }

        public Capsule(Point p1, Point p2, Point p3, Color color)
        {
            FirstVertex = p1;
            SecondVertex = p2;
            ThirdVertex = p3;
            BrushColor = color;
            Radius = Math.Sqrt(Math.Pow(ThirdVertex.X - p2.X, 2) + Math.Pow(ThirdVertex.Y - p2.Y, 2));
        }

        public override Bitmap Draw(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);

            double dbax = SecondVertex.X - FirstVertex.X;
            double dbay = SecondVertex.Y - FirstVertex.Y;

            double vx = dbay;
            double vy = (-1) * dbax;

            double length = Math.Sqrt(vx * vx + vy * vy);

            int wx = (int)(vx / length * Radius);
            int wy = (int)(vy / length * Radius);

            Point A1 = new Point(FirstVertex.X + wx, FirstVertex.Y + wy);
            Point A2 = new Point(FirstVertex.X - wx, FirstVertex.Y - wy);
            Point B1 = new Point(SecondVertex.X + wx, SecondVertex.Y + wy);
            Point B2 = new Point(SecondVertex.X - wx, SecondVertex.Y - wy);

            bmp = (new Shapes.Line(A1, B1, BrushColor, 1)).Draw(bmp);
            bmp = (new Shapes.Line(A2, B2, BrushColor, 1)).Draw(bmp);

            int dE = 3;
            int dSE = (int)(5 - 2 * this.Radius);
            int d = (int)(1 - this.Radius);
            int x = 0;
            int y = (int)this.Radius;
            int xc = FirstVertex.X;
            int yc = FirstVertex.Y;


            while (y > x)
            {
                if (d < 0)
                {
                    d += dE;
                    dE += 2;
                    dSE += 2;
                }
                else
                {
                    d += dSE;
                    dE += 2;
                    dSE += 4;
                    --y;
                }
                ++x;
                TryToPutPixel(xc + x, yc - y, BrushColor, bmp);
                TryToPutPixel(xc - x, yc - y, BrushColor, bmp);
                TryToPutPixel(xc + x, yc + y, BrushColor, bmp);
                TryToPutPixel(xc - x, yc + y, BrushColor, bmp);
                TryToPutPixel(xc + y, yc - x, BrushColor, bmp);
                TryToPutPixel(xc - y, yc - x, BrushColor, bmp);
                TryToPutPixel(xc + y, yc + x, BrushColor, bmp);
                TryToPutPixel(xc - y, yc + x, BrushColor, bmp);
            }

            dE = 3;
            dSE = (int)(5 - 2 * this.Radius);
            d = (int)(1 - this.Radius);
            x = 0;
            y = (int)this.Radius;
            xc = SecondVertex.X;
            yc = SecondVertex.Y;

            TryToPutPixel(xc + x, yc - y, BrushColor, bmp);

            while (y > x)
            {
                if (d < 0)
                {
                    d += dE;
                    dE += 2;
                    dSE += 2;
                }
                else
                {
                    d += dSE;
                    dE += 2;
                    dSE += 4;
                    --y;
                }
                ++x;
                TryToPutPixel(xc + x, yc - y, BrushColor, bmp);
                TryToPutPixel(xc - x, yc - y, BrushColor, bmp);
                TryToPutPixel(xc + x, yc + y, BrushColor, bmp);
                TryToPutPixel(xc - x, yc + y, BrushColor, bmp);
                TryToPutPixel(xc + y, yc - x, BrushColor, bmp);
                TryToPutPixel(xc - y, yc - x, BrushColor, bmp);
                TryToPutPixel(xc + y, yc + x, BrushColor, bmp);
                TryToPutPixel(xc - y, yc + x, BrushColor, bmp);
            }

            return bmp;
        }

        public override Bitmap DrawWithAntiAliasing(Bitmap image)
        {
            return this.Draw(image);
        }

        public override string ToString()
        {
            return "Capsule";
        }
    }
}
