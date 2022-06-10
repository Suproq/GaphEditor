using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GaphEditor
{
    abstract class FigureClass
    {
        private Point cords;
        private Color color = Color.Black;
        private int size = 50;
        private int width = 3;
        public Point GetPoints()
        {
            return cords;
        }
        public void SetPoints(Point p)
        {
            cords = p;
        }
        public int GetWidth()
        {
            return width;
        }
        public void SetWidth(int w)
        {
            width = w;
        }
        public int GetSize()
        {
            return size;
        }
        public void SetSize(int s)
        {
            size = s;
        }
        public Color GetColor()
        {
            return color;
        }
        public void SetColor(Color c)
        {
            color = c;
        }
        
        public abstract Bitmap Draw(Bitmap pic);
        public abstract void EditPoints();
    }
}
