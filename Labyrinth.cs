using System;
using System.Linq;
using System.Collections.Generic;

namespace Labyrinth
{
  public class Labyrinth
  {
    public int Width { get; set; }
    public int Height { get; set; }

    Block[,] _block;

    public Block this[int x, int y]
    {
      get
      {
        return _block[x,y];
      }
    }

    public static Labyrinth From(string labyrinthDefinition)
    {
      var rows = labyrinthDefinition.Split('\n').ToList().FindAll(row => row.Length > 0);
      var height = rows.Count;
      var width = (rows[0].Length+1)/4;
      var blocks = new Block[width,height];
      for(var y = 0; y < height; y++)
        for(var x = 0; x < width; x++)
          blocks[x,y] = Block.From(rows[y].Substring(x*4));
      return new Labyrinth { Width = width, Height = height, _block = blocks };
    }
  }
}


