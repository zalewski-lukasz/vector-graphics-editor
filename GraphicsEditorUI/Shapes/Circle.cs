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
    public class Circle : Shape
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public override string GetName()
        {
            return "Circle";
        }

        public Circle(Point first, Point second, Color color)
        {
            Center = first;
            Radius = (int)Math.Sqrt(Math.Pow(second.X - first.X, 2) + Math.Pow(second.Y - first.Y, 2));
            BrushColor = color;
            IsSelected = true;
        }

        public Circle(Point pt, int radius, Color clr)
        {
            Center = pt;
            Radius = radius;
            BrushColor = clr;
        }

        public override Bitmap Draw(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);

            int dE = 3;
            int dSE = 5 - 2 * this.Radius;
            int d = 1 - this.Radius;
            int x = 0;
            int y = this.Radius;
            int xc = Center.X;
            int yc = Center.Y;

            TryToPutPixel(xc + x, yc - y, BrushColor, newBmp);

            while(y > x)
            {
                if(d < 0)
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
                TryToPutPixel(xc + x, yc - y, BrushColor, newBmp);
                TryToPutPixel(xc - x, yc - y, BrushColor, newBmp);
                TryToPutPixel(xc + x, yc + y, BrushColor, newBmp);
                TryToPutPixel(xc - x, yc + y, BrushColor, newBmp);
                TryToPutPixel(xc + y, yc - x, BrushColor, newBmp);
                TryToPutPixel(xc - y, yc - x, BrushColor, newBmp);
                TryToPutPixel(xc + y, yc + x, BrushColor, newBmp);
                TryToPutPixel(xc - y, yc + x, BrushColor, newBmp);
            }

            return newBmp;
        }

        public override Bitmap DrawWithAntiAliasing(Bitmap image)
        {
            Bitmap newBmp = new Bitmap(image);

            int dE = 3;
            int dSE = 5 - 2 * this.Radius;
            int d = 1 - this.Radius;
            int x = 0;
            int y = this.Radius;
            int xc = Center.X;
            int yc = Center.Y;

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

                double intensity = (double)Math.Ceiling((decimal)Math.Sqrt((Radius * Radius) - (y * y))) - Math.Sqrt(Radius * Radius - y * y);
                int c2_alpha = (int)(127 * intensity);
                int c3_alpha2 = 127 - (int)(127 * intensity);

                Color c1 = Color.FromArgb(255, BrushColor.R, BrushColor.G, BrushColor.B);
                Color c2 = Color.FromArgb(c2_alpha, BrushColor.R, BrushColor.G, BrushColor.B);
                Color c3 = Color.FromArgb(c3_alpha2, BrushColor.R, BrushColor.G, BrushColor.B);

                TryToPutPixel(xc + x, yc - y, c1, newBmp);
                TryToPutPixel(xc + x - 1, yc - y, c2, newBmp);
                TryToPutPixel(xc + x + 1, yc - y, c3, newBmp);

                TryToPutPixel(xc - x, yc - y, c1, newBmp);
                TryToPutPixel(xc - x - 1, yc - y, c2, newBmp);
                TryToPutPixel(xc - x + 1, yc - y, c3, newBmp);

                TryToPutPixel(xc + x, yc + y, c1, newBmp);
                TryToPutPixel(xc + x - 1, yc + y, c2, newBmp);
                TryToPutPixel(xc + x + 1, yc + y, c3, newBmp);

                TryToPutPixel(xc - x, yc + y, c1, newBmp);
                TryToPutPixel(xc - x - 1, yc + y, c2, newBmp);
                TryToPutPixel(xc - x + 1, yc + y, c3, newBmp);

                TryToPutPixel(xc + y, yc - x, c1, newBmp);
                TryToPutPixel(xc + y, yc - x - 1, c2, newBmp);
                TryToPutPixel(xc + y, yc - x + 1, c3, newBmp);

                TryToPutPixel(xc - y, yc - x, c1, newBmp);
                TryToPutPixel(xc - y, yc - x - 1, c2, newBmp);
                TryToPutPixel(xc - y, yc - x + 1, c3, newBmp);

                TryToPutPixel(xc + y, yc + x, c1, newBmp);
                TryToPutPixel(xc + y, yc + x - 1, c2, newBmp);
                TryToPutPixel(xc + y, yc + x + 1, c3, newBmp);

                TryToPutPixel(xc - y, yc + x, c1, newBmp);
                TryToPutPixel(xc - y, yc + x - 1, c2, newBmp);
                TryToPutPixel(xc - y, yc + x + 1, c3, newBmp);
            }

            return newBmp;
        }

        public bool HitTest(Point point)
        {
            double dist = Math.Sqrt(Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2));
            return dist - 5 <= Radius && dist + 5 >= Radius;
        }

        public override string ToString()
        {
            return $"Circle {Center.X} {Center.Y} {BrushColor.R} {BrushColor.G} {BrushColor.B} {Radius}";
        }
    }
}
