using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GaphEditor
{
    internal class Square: FigureClass
    {
        private Point[] points = new Point[4];
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
                grfx.DrawPolygon(p, points);

            }
            return pic;
        }
        public override void EditPoints()
        {
            Point cord = GetPoints();
            points[0].X = cord.X - GetSize();
            points[0].Y = cord.Y + GetSize();
            points[1].X = cord.X + GetSize();
            points[1].Y = cord.Y + GetSize();
            points[2].X = cord.X + GetSize(); 
            points[2].Y = cord.Y - GetSize();
            points[3].X = cord.X - GetSize();
            points[3].Y = cord.Y - GetSize();
        }
    }
}
