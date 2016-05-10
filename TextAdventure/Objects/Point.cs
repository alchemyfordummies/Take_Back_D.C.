using System;

namespace TextAdventure.Objects
{
    /// <summary>Defines a location with an x-coordinate, a y-coordinate, 
    /// a character to represent the point on the map, and accessibility</summary>
	public class Point
	{
		//Point attributes
		private int _x;
		private int _y;
		private bool _accessible;
        private char _mapChar;

		///<summary>Default point</summary>
		public Point()
		{
		    _mapChar = ' ';
			_accessible = true;
			_x = 0;
			_y = 0;
		}

		/// <param name="a">x-coordinate of the point</param>
		/// <param name="b">y-coordinate of the point</param>
		/// <param name="c">Character to represent this point on the map</param>
		public Point(int a, int b, char c = ' ')
		{
		    _mapChar = ' ';
			_accessible = true;
			_x = a;
			_y = b;
		}

		/// <returns>Accessibility for the point</returns>
		public bool IsAccessible()
		{
			return _accessible;
		}

		/// <param name="b">Sets accessibility for a point</param>
		public void SetAccessible(bool b)
		{
			_accessible = b;
		}

		/// <returns>Returns the x-coordinate for the point</returns>
		public int GetX()
		{
			return _x;
		}

		/// <param name="a">Sets the x-coordinate for the point</param>
		public void SetX(int a)
		{
			_x = a;
		}

		/// <returns>Returns the y-coordinate for the point</returns>
		public int GetY()
		{
			return _y;
		}

		/// <param name="a">Sets the y-coordinate for the point</param>
		public void SetY(int a)
		{
			_y = a;
		}

		/// <summary>Increases the y-coordinate by one</summary>
		public void Forward()
		{
			_y++;
		}

		/// <summary>Decreases the y-coordinate by one</summary>
		public void Back()
		{
			_y--;
		}

		/// <summary>Decreases the x-coordinate by one</summary>
		public void Left()
		{
			_x--;
		}

		/// <summary>Increases the x-coordinate by one</summary>
		public void Right()
		{
			_x++;
		}

		/// <summary>Checks if the given point equals this instance</summary>
		/// <param name="p">Takes in an external point to compare</param>
		public bool MatchPoint(Point p)
		{
			return (p._x == _x && p._y == _y);
		}

		/// <summary>Finds the diagonal distance between two points</summary>
		/// <param name="one">First point for distance</param>
		/// <param name="two">Second point for distance</param>
		public double PointDistance(Point one, Point two)
		{
			var firstHalf = Math.Pow((two._x - one._x), 2);
			var secondHalf = Math.Pow((two._y - one._y), 2);
			return Math.Sqrt(firstHalf + secondHalf);
		}

        /// <summary>
        /// Returns the map character for this point
        /// </summary>
        /// <returns>The point's _mapChar</returns>
        public char GetMapChar()
        {
            return _mapChar;
        }

        /// <summary>
        /// Sets the _mapChar to the given character
        /// </summary>
        /// <param name="c">The character that _mapChar will be set to</param>
        public void SetMapChar(char c)
        {
            _mapChar = c;
        }
	}
}