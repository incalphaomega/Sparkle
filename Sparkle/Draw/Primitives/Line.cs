using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Draw.Primitives
{
    struct Line
    {
        public Point P1, P2;
        public Color color;

        public float angle, length;


        public int Angle
        {
            get
            {
                return (int)Math.Round(MathHelper.ToDegrees(angle));
            }
            set
            {
                angle = (int)Math.Round(MathHelper.ToRadians(angle));
            }
        }

        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
            length = Point.Distance(p1, p2);
            angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
            color = Color.White;
        }

        public void Update()
        {
            length = Point.Distance(P1, P2);
            angle = (float)Math.Atan2(P2.Y - P1.Y, P2.X - P1.X);
        }

        public bool Intersects(Point point)
        {
            if (point.X > P1.X && point.X < P2.X && point.Y > P1.Y && point.Y < P2.Y || point.X > P2.X && point.X < P1.X /*&& point.Y == point.X * (float)Math.Atan2(P2.Y - P1.Y, P2.X - P1.X)*/)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
