using System;
namespace QuadTree
{
    public class QuadTree
    {
        private HashSet<Point> _points;
        private int _capacity;
        private Rectangle _boundary;
        private bool _divided;

        private QuadTree? _northEast;
        private QuadTree? _northWest;
        private QuadTree? _southEast;
        private QuadTree? _southWest;

        private void _divideBoundary()
        {
            _northEast = new QuadTree
            {
                Capacity = _capacity,
                Boundary = new Rectangle
                {
                    Center = new Point
                    {
                        X = _boundary.Center.X + _boundary.Width / 2,
                        Y = _boundary.Center.Y + _boundary.Height / 2
                    },

                    Width = _boundary.Width / 2,
                    Height = _boundary.Height / 2
                },
                Divided = false
            };

            _northWest = new QuadTree
            {
                Capacity = _capacity,
                Boundary = new Rectangle
                {
                    Center = new Point
                    {
                        X = _boundary.Center.X - _boundary.Width / 2,
                        Y = _boundary.Center.Y + _boundary.Height / 2
                    },

                    Width = _boundary.Width / 2,
                    Height = _boundary.Height / 2
                },
                Divided = false
            };

            _southEast = new QuadTree
            {
                Capacity = _capacity,
                Boundary = new Rectangle
                {
                    Center = new Point
                    {
                        X = _boundary.Center.X + _boundary.Width / 2,
                        Y = _boundary.Center.Y - _boundary.Height / 2
                    },

                    Width = _boundary.Width / 2,
                    Height = _boundary.Height / 2
                },
                Divided = false
            };

            _southWest = new QuadTree
            {
                Capacity = _capacity,
                Boundary = new Rectangle
                {
                    Center = new Point
                    {
                        X = _boundary.Center.X - _boundary.Width / 2,
                        Y = _boundary.Center.Y - _boundary.Height / 2
                    },

                    Width = _boundary.Width / 2,
                    Height = _boundary.Height / 2
                },
                Divided = false
            };
        }
        public QuadTree()
        {
        }

        public QuadTree(int capacity, Rectangle boundary)
        {
            _capacity = capacity;
            _boundary = boundary;
            _points = new HashSet<Point>(_capacity);
            _divided = false;
        }

        public HashSet<Point> Points { get => _points; set => _points = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public Rectangle Boundary { get => _boundary; set => _boundary = value; }
        public bool Divided { get => _divided; set => _divided = value; }

        public bool Insert(Point point)
        {
            if (!_boundary.IsValidPoint(point))
            {
                return false;
            }
            else if (_points.Count < _capacity)
            {
                _points.Add(point);
                return true;
            }

            if (!_divided)
            {
                _divideBoundary();
                _divided = true;
            }

            if (_northEast.Insert(point) || _northWest.Insert(point) || _southEast.Insert(point) || _southWest.Insert(point))
                return true;
            return false;
        }

        public IList<Point> Query(Rectangle boundary, IList<Point> result = null)
        {
            if (result is null)
            {
                result = new List<Point>();
            }

            if (!_boundary.Intersects(boundary))
                return result;
            foreach (Point p in _points)
            {
                if (boundary.IsValidPoint(p))
                    result.Add(p);
            }

            if (_divided)
            {
                _northEast.Query(boundary, result);
                _northWest.Query(boundary, result);
                _southEast.Query(boundary, result);
                _southWest.Query(boundary, result);
            }

            return result;
        }
    }
}

