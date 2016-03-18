using System;

namespace TextAdventure.Objects
{
  public class Point
  {
    private int x;
    private int y;

    public Point()
    {
      x = 0;
      y = 0;
    }

    public Point(int a, int b)
    {
      x = a;
      y = b;
    }

    public int GetX()
    {
      return x;
    }

    public void SetX(int a)
    {
      x = a;
    }

    public int GetY()
    {
      return y;
    }

    public void SetY(int a)
    {
      y = a;
    }

    public bool MatchPoint(Point p)
    {
      return (p.x == x && p.y == y);
    }

    public double PointDistance(Point one, Point two)
    {
      var firstHalf = Math.Pow((two.x - one.x), 2);
      var secondHalf = Math.Pow((two.y - one.y), 2);
      return Math.Sqrt(firstHalf + secondHalf);
    }
  }
}