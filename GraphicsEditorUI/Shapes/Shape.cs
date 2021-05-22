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
    public abstract class Shape
    {
        public Color BrushColor { get; set; }
        public int BrushThickness { get; set; }
        public bool IsSelected { get; set; }

        public abstract string GetName();
        public abstract Bitmap Draw(Bitmap image);
        public abstract Bitmap DrawWithAntiAliasing(Bitmap image);
        
        protected void TryToPutPixel(int x, int y, Color color, Bitmap image)
        {
            try
            {
                image.SetPixel(x, y, color);
            }
            catch
            {
                return;
            }
        }

        public abstract override string ToString();
    }
}
