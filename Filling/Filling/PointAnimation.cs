using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filling
{
    public class PointAnimation
    {
        private bool isMovingStraight;
        private bool isMovingRight;
        private bool isMovingUp;
        private (int lower, int upper, int minH, int maxH) bounds;
        private int rSquare;
        private int step;
        private int hStep;
        private Vector location;
        public PointAnimation(Point center, int r, int s, int minH=10, int maxH=200, int hs=10)
        {
            bounds = (center.Y - r, center.Y + r, minH, maxH);
            rSquare = r * r;
            step = s;
            hStep = hs;
            location = new Vector(center.X - r, center.Y - r, minH);
            isMovingStraight = true;
            isMovingRight = true;
            isMovingUp = true;
        }
        public Vector GetNext()
        {
            if(isMovingStraight)
            {
                if(isMovingRight)
                {
                    location.X += step;
                    location.Y += step;
                    if(location.Y>bounds.upper)
                    {
                        location.X -= location.Y - bounds.upper;
                        location.Y = bounds.upper;
                        isMovingStraight = false;
                        isMovingRight = false;
                    }
                }
                else
                {
                    location.X -= step;
                    location.Y += step;
                    if (location.Y > bounds.upper)
                    {
                        location.X += location.Y - bounds.upper;
                        location.Y = bounds.upper;
                        isMovingStraight = false;
                        isMovingRight = true;
                    }
                }

            }
            else
            {
                // TODO Change so as to animate it on a circle
                location.Y -= step;
                if(location.Y<bounds.lower)
                {
                    location.Y = bounds.lower;
                    isMovingStraight = true;
                }
            }
            if(isMovingUp)
            {
                location.Z += hStep;
                if(location.Z>bounds.maxH)
                {
                    location.Z = bounds.maxH;
                    isMovingUp = false;
                }
            }
            else
            {
                location.Z -= hStep;
                if (location.Z < bounds.minH)
                {
                    location.Z = bounds.minH;
                    isMovingUp = true;
                }
            }
            return location;
        }
    }
}
