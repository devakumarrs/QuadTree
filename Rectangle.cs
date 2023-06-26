using System;
namespace QuadTree
{
    public class Rectangle
    {
        private Point _center;
        private int _width;
        private int _height;

        public Rectangle()
        {
        }
        public Rectangle(int width, int height, Point center)
        {
            _center = center;
            _width = width;
            _height = height;
        }

        public Point Center { get => _center; set => _center = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public bool IsValidPoint(Point point)
        {
            return !(point.X > _center.X + _width ||
                point.Y > _center.Y + _height ||
                point.X < _center.X - _width ||
                point.Y < _center.Y - _height);
        }

        public bool Intersects(Rectangle boundary)
        {
            return !(Center.X + Width < boundary.Center.X - boundary.Width ||
                        Center.Y + Height < boundary.Center.Y - boundary.Height ||
                        Center.X - Width > boundary.Center.X + boundary.Width ||
                        Center.Y - Height > boundary.Center.Y + boundary.Width);
        }
    }
}

