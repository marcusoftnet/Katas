using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleKata
{
    public class Triangle
    {
        private readonly int[] sides;
        public Triangle(int side1, int side2, int side3)
        {
            sides = new List<int> { side1, side2, side3 }.ToArray();
        }

        public int SidesCount { get { return sides.Count(); } }

        public int Circumference { get { return sides.Sum(); } }

        public bool IsValid
        {
            get
            {
                return !sides.Any(x => x < 1) &&
                    sides[0] + sides[1] == sides[2];
            }
        }
    }
}