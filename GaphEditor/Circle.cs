using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GaphEditor
{
    internal class Circle : FigureClass
    {
        public override Bitmap Draw(Bitmap pic)
        {
            EditPoints();
            Pen p = new Pen(GetColor());
            p.Width = GetWidth();
            //Pens p = new Pens(Color.Black);
            using (Graphics grfx = Graphics.FromImage(pic))
            {
                // Рисуем.
                //grfx.Clear(Color.White);
                int size = GetSize();
                int x = GetPoints().X - size, y = GetPoints().Y - size;
                grfx.DrawEllipse(p, x, y, size*2, size*2);

            }
            return pic;
        }
        public override void EditPoints()
        {
        }
    }
}
