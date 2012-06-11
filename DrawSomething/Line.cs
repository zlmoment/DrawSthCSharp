using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DrawSomething
{
    class Line
    {
        public Color penColor = Color.Black;
        public float penWidth;
        public List<Point> Points { get; set; }
        public int PointCount
        {
            get
            {
                return Points.Count;
            }
        }

        public Line()
        {
            Points = new List<Point>();
        }

        public Line(Point startPoint)
            : this()
        {
            Points.Add(startPoint);
        }

        public void Add(Point point)
        {
            Points.Add(point);
        }

        public void Draw(Graphics g)
        {
            if (PointCount <= 1)
                return;
            

            Point[] pointArray = Points.ToArray();
            Pen mypen = new Pen(penColor, penWidth);
            g.DrawLines(mypen, pointArray);
        }
    }
}
