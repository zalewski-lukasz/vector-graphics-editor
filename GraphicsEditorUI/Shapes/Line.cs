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
    public class Line : Shape
    {
        public Point FirstVertex { get; set; }
        public Point SecondVertex { get; set; }

        public int[, ] GetBrush(int thickness)
        {
            int[,] brush = new int[thickness, thickness];
            int X = 0;
            int Y = 0;
            int R = thickness / 2;
            for(int i = 0; i < thickness; i++)
            {
                for(int j = 0; j < thickness; j++)
                {
                    int offset = thickness / 2;
                    int tmp_x = i - offset;
                    int tmp_y = j - offset;
                    double distanceFromtheMiddle = Math.Sqrt(Math.Pow((double)(X - tmp_x), 2) + Math.Pow((double)(Y - tmp_y), 2));
                    if(distanceFromtheMiddle <= R)
                    {
                        brush[i, j] = 1;
                    }
                    else
                    {
                        brush[i, j] = 0;
                    }
                }
            }
            return brush;
        }

        public Line(Point first, Point second, Color color, int thickness)
        {
            BrushThickness = thickness;
            BrushColor = color;
            FirstVertex = first;
            SecondVertex = second;
        }

        public override Bitmap Draw(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image);

            int x1, y1, x2, y2;
            int d, dx, dy, ai, bi, xi, yi;

            int[,] brush = GetBrush(BrushThickness);

            if(SecondVertex.X >= FirstVertex.X)
            {
                x1 = FirstVertex.X;
                x2 = SecondVertex.X;
                y1 = FirstVertex.Y;
                y2 = SecondVertex.Y;
            }
            else
            {
                x1 = SecondVertex.X;
                x2 = FirstVertex.X;
                y1 = SecondVertex.Y;
                y2 = FirstVertex.Y;
            }
            

            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }

            if(y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }
            int xf = x1, yf = y1;
            int xb = x2, yb = y2;

            for(int i = 0; i < BrushThickness; i++)
            {
                for(int j = 0; j < BrushThickness; j++)
                {
                    if(brush[i, j] == 1)
                    {
                        int tmp_x = i - BrushThickness / 2;
                        int tmp_y = j - BrushThickness / 2;
                        TryToPutPixel(xf + tmp_x, yf + tmp_y, BrushColor, bmp);
                        TryToPutPixel(xb + tmp_x, yb + tmp_y, BrushColor, bmp);
                    }
                }
            }


            if(dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                while(xf < xb)
                {
                    xf += xi;
                    xb -= xi;
                    if(d < 0)
                    {
                        d += bi;
                    }
                    else
                    {
                        d += ai;
                        yf += yi;
                        yb -= yi;
                    }
                    for (int i = 0; i < BrushThickness; i++)
                    {
                        for (int j = 0; j < BrushThickness; j++)
                        {
                            if (brush[i, j] == 1)
                            {
                                int tmp_x = i - BrushThickness / 2;
                                int tmp_y = j - BrushThickness / 2;
                                TryToPutPixel(xf + tmp_x, yf + tmp_y, BrushColor, bmp);
                                TryToPutPixel(xb + tmp_x, yb + tmp_y, BrushColor, bmp);
                            }
                        }
                    }
                }
            }
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                while (yf < yb)
                {
                    yf += yi;
                    yb -= yi;
                    if (d < 0)
                    {
                        d += bi;
                    }
                    else
                    {
                        d += ai;
                        xf += xi;
                        xb -= xi;
                    }
                    for (int i = 0; i < BrushThickness; i++)
                    {
                        for (int j = 0; j < BrushThickness; j++)
                        {
                            if (brush[i, j] == 1)
                            {
                                int tmp_x = i - BrushThickness / 2;
                                int tmp_y = j - BrushThickness / 2;
                                TryToPutPixel(xf + tmp_x, yf + tmp_y, BrushColor, bmp);
                                TryToPutPixel(xb + tmp_x, yb + tmp_y, BrushColor, bmp);
                            }
                        }
                    }
                }
            }

            return bmp;
        }

        public override string GetName()
        {
            return "Line";
        }

        private double GetIPart(double x)
        {
            return Math.Floor(x);
        }

        private double GetRound(double x)
        {
            return GetIPart(x + 0.5);
        }

        private double GetFPart(double x)
        {
            return x - Math.Floor(x);
        }

        private double GetRFPart(double x)
        {
            return 1 - GetFPart(x);
        }

        public override Bitmap DrawWithAntiAliasing(Bitmap image)
        {
            // Algorithm was prepared with help from the given source:
            // https://pl.other.wiki/wiki/Xiaolin_Wu's_line_algorithm

            Bitmap bmp = new Bitmap(image);

            int x0 = FirstVertex.X;
            int x1 = SecondVertex.X;
            int y0 = FirstVertex.Y;
            int y1 = SecondVertex.Y;

            bool isSteep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if(isSteep)
            {
                int tmp = x0;
                x0 = y0;
                y0 = tmp;

                tmp = x1;
                x1 = y1;
                y1 = tmp;
            }

            if(x0 > x1)
            {
                int tmp = x0; 
                x0 = x1; 
                x1 = tmp;
                
                tmp = y0; 
                y0 = y1; 
                y1 = tmp;
            }

            int dx = x1 - x0;
            int dy = y1 - y0;
            double ayx = 1.0 * (double)dy / (double)dx;
            if(dx == 0)
            {
                ayx = 1.0;
            }

            double xend = GetRound((double)x0);
            double yend = (double)y0 + (double)ayx * (xend - x0);
            double xgap = GetRFPart(x0 + 0.5);
            double xpixel1 = xend;
            double ypixel1 = GetIPart(yend);

            if(isSteep)
            {
                TryToPutPixel((int)ypixel1, (int)xpixel1, Color.FromArgb((int)(BrushColor.R * GetRFPart(yend) * xgap),
                    (int)(BrushColor.G * GetRFPart(yend) * xgap), (int)(BrushColor.B * GetRFPart(yend) * xgap)), bmp);
                TryToPutPixel((int)ypixel1 + 1, (int)xpixel1, Color.FromArgb((int)(BrushColor.R * GetFPart(yend) * xgap),
                    (int)(BrushColor.G * GetFPart(yend) * xgap), (int)(BrushColor.B * GetFPart(yend) * xgap)), bmp);
            }
            else
            {
                TryToPutPixel((int)xpixel1, (int)ypixel1, Color.FromArgb((int)(BrushColor.R * GetRFPart(yend) * xgap),
                    (int)(BrushColor.G * GetRFPart(yend) * xgap), (int)(BrushColor.B * GetRFPart(yend) * xgap)), bmp);
                TryToPutPixel((int)xpixel1, (int)ypixel1 + 1, Color.FromArgb((int)(BrushColor.R * GetFPart(yend) * xgap),
                    (int)(BrushColor.G * GetFPart(yend) * xgap), (int)(BrushColor.B * GetFPart(yend) * xgap)), bmp);
            }

            double ya = yend + ayx;

            xend = GetRound((double)x1);
            yend = (double)y1 + ayx * (xend - x1);
            xgap = GetFPart(x1 + 0.5);
            double xpixel2 = xend;
            double ypixel2 = GetIPart(yend);

            if (isSteep)
            {
                TryToPutPixel((int)ypixel1, (int)xpixel1, Color.FromArgb((int)(BrushColor.R * GetRFPart(yend) * xgap),
                    (int)(BrushColor.G * GetRFPart(yend) * xgap), (int)(BrushColor.B * GetRFPart(yend) * xgap)), bmp);
                TryToPutPixel((int)ypixel1 + 1, (int)xpixel1, Color.FromArgb((int)(BrushColor.R * GetFPart(yend) * xgap),
                    (int)(BrushColor.G * GetFPart(yend) * xgap), (int)(BrushColor.B * GetFPart(yend) * xgap)), bmp);
            }
            else
            {
                TryToPutPixel((int)xpixel1, (int)ypixel1, Color.FromArgb((int)(BrushColor.R * GetRFPart(yend) * xgap),
                    (int)(BrushColor.G * GetRFPart(yend) * xgap), (int)(BrushColor.B * GetRFPart(yend) * xgap)), bmp);
                TryToPutPixel((int)xpixel1, (int)ypixel1 + 1, Color.FromArgb((int)(BrushColor.R * GetFPart(yend) * xgap),
                    (int)(BrushColor.G * GetFPart(yend) * xgap), (int)(BrushColor.B * GetFPart(yend) * xgap)), bmp);
            }

            if(isSteep)
            {
                for(int x = (int)(xpixel1 + 1); x <= (int)(xpixel2 - 1); x++)
                {
                    TryToPutPixel((int)GetIPart(ya), x, Color.FromArgb((int)(BrushColor.R * GetRFPart(ya)),
                        (int)(BrushColor.G * GetRFPart(ya)), (int)(BrushColor.B * GetRFPart(ya))), bmp);
                    TryToPutPixel((int)GetIPart(ya) + 1, x, Color.FromArgb((int)(BrushColor.R * GetRFPart(ya)),
                        (int)(BrushColor.G * GetRFPart(ya)), (int)(BrushColor.B * GetFPart(ya))), bmp);
                    ya = ya + ayx;
                }
            }
            else
            {
                for (int x = (int)(xpixel1 + 1); x <= (int)(xpixel2 - 1); x++)
                {
                    TryToPutPixel(x, (int)GetIPart(ya), Color.FromArgb((int)(BrushColor.R * GetRFPart(ya)),
                        (int)(BrushColor.G * GetRFPart(ya)), (int)(BrushColor.B * GetRFPart(ya))), bmp);
                    TryToPutPixel(x, (int)GetIPart(ya) + 1, Color.FromArgb((int)(BrushColor.R * GetRFPart(ya)),
                        (int)(BrushColor.G * GetRFPart(ya)), (int)(BrushColor.B * GetFPart(ya))), bmp);
                    ya = ya + ayx;
                }
            }

            return bmp;
        }

        public bool HitTest(Point point)
        {
            if (HitFirst(point))
                return true;
            if (HitSecond(point))
                return true;
            return false;
        }

        public bool HitFirst(Point point)
        {
            if ((point.X < FirstVertex.X + BrushThickness + 2 && point.X > FirstVertex.X - BrushThickness - 2) &&
                (point.Y < FirstVertex.Y + BrushThickness + 2 && point.Y > FirstVertex.Y - BrushThickness - 2))
                return true;

            return false;
        }

        public bool HitSecond(Point point)
        {
            if ((point.X < SecondVertex.X + BrushThickness + 2 && point.X > SecondVertex.X - BrushThickness - 2) &&
                (point.Y < SecondVertex.Y + BrushThickness + 2 && point.Y > SecondVertex.Y - BrushThickness - 2))
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"Line {FirstVertex.X} {FirstVertex.Y} {SecondVertex.X} {SecondVertex.Y} {BrushThickness} {BrushColor.R} {BrushColor.G} {BrushColor.B}";
        }

        public double GetSlope()
        {
            return (FirstVertex.Y - SecondVertex.Y) / (FirstVertex.X - SecondVertex.X);
        }

        public double GetIntercept()
        {
            return FirstVertex.Y - GetSlope() * FirstVertex.X;
        }
    }
}
