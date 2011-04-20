using System;

namespace Labyrinth
{
  public class Labyrinth
  {
    public int Width { get; set; }
    public int Height { get; set; }

    Block[] _block;

    public Block this[int x, int y]
    {
      get
      {
        return _block[x];
      }
    }

    public static Labyrinth From(string labyrinthDefinition)
    {
      var width = (labyrinthDefinition.Length+1)/4;
      var blocks = new Block[width];
      for(var x = 0; x < width; x++)
        blocks[x] = Block.From(labyrinthDefinition.Substring(x*4));
      return new Labyrinth { Width = width, Height = 1, _block = blocks };
    }
  }
}


