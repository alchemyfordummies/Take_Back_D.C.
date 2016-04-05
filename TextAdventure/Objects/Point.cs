using System;

namespace TextAdventure.Objects
{
	public class Point
	{
		private int _x;
		private int _y;
		private bool _accessible;

		public Point()
		{
			_accessible = true;
			_x = 0;
			_y = 0;
		}

		public Point(int a, int b)
		{
			_accessible = true;
			_x = a;
			_y = b;
		}

		public bool IsAccessible()
		{
			return _accessible;
		}

		public void SetAccessible(bool b)
		{
			_accessible = b;
		}

		public int GetX()
		{
			return _x;
		}

		public void SetX(int a)
		{
			_x = a;
		}

		public int GetY()
		{
			return _y;
		}

		public void SetY(int a)
		{
			_y = a;
		}

		public void Forward()
		{
			_y++;
		}

		public void Back()
		{
			_y--;
		}

		public void Left()
		{
			_x--;
		}

		public void Right()
		{
			_x++;
		}

		public bool MatchPoint(Point p)
		{
			return (p._x == _x && p._y == _y);
		}

		public double PointDistance(Point one, Point two)
		{
			var firstHalf = Math.Pow((two._x - one._x), 2);
			var secondHalf = Math.Pow((two._y - one._y), 2);
			return Math.Sqrt(firstHalf + secondHalf);
		}
	}
}