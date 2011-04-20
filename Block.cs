using System;

namespace Labyrinth
{
	public class Walls
  {
    public const int Nothing = 0;
    public const int Top = 1;
    public const int Bottom = 2;
    public const int Right = 4;
    public const int Left = 8;
  }

	public class Block
	{
    public int Closed { get; set; }

    public static Block From(string blockDefinition)
    {
      return new Block();
    }

    public override bool Equals(object otherBlock)
    {
       return Closed == ((Block)otherBlock).Closed;
    }

    public override string ToString()
    {
       var char1 = (Closed == Walls.Left) ? "(" : " ";
       var char2 = (Closed == Walls.Bottom) ? "_" : " ";
       var char3 = (Closed == Walls.Right) ? ")" : " ";
       return char1 + char2 + char3;
    }
	}
}


