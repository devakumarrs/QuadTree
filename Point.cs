using System;
namespace QuadTree
{
    public class Point
    {
        int _x;
        int _y;
        public Point() { }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
    }
}

