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

  static class BlockIntExtensionHelper
  {
    public static bool Has(this int closed, int test)
    {
      return (closed & test) != 0;
    }
  }

  public class Block
  {
    public int Closed { get; set; }

    public static Block From(string blockDefinition)
    {
      var closed =
        (blockDefinition[0] == '(' ? Walls.Left : Walls.Nothing)
        + (blockDefinition[2] == ')' ? Walls.Right : Walls.Nothing)
        + (blockDefinition[1] == '_' ? Walls.Bottom : Walls.Nothing)
        + (blockDefinition[1] == '^' ? Walls.Top : Walls.Nothing)
        + (blockDefinition[1] == 'O' ? Walls.Top + Walls.Bottom : Walls.Nothing);
      var block = new Block { Closed = closed };
      Tools.Assert<ArgumentException>( block.ToString() == blockDefinition, "Unexpected block definition {0}", blockDefinition );
      return block;
    }

    public override bool Equals(object otherBlock)
    {
       return Closed == ((Block)otherBlock).Closed;
    }

    public override string ToString()
    {
       var char1 = Closed.Has(Walls.Left) ? "(" : " ";
       var char2 = Closed.Has(Walls.Top) && Closed.Has(Walls.Bottom) ? "O" : Closed.Has(Walls.Bottom) ? "_" : Closed.Has(Walls.Top) ? "^" : " ";
       var char3 = Closed.Has(Walls.Right) ? ")" : " ";
       return char1 + char2 + char3;
    }
  }
}


