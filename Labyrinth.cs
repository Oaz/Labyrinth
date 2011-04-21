using System;
using System.Diagnostics;
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

      Tools.Assert<ArgumentException>( (width*4-1)*height == rows.Select(row => row.Length).Sum(), "Unexpected labyrinth definition {0}", labyrinthDefinition );

      var blocks = new Block[width,height];
      for(var y = 0; y < height; y++)
        for(var x = 0; x < width; x++)
          blocks[x,y] = Block.From(rows[y].Substring(x*4,3));

      return new Labyrinth { Width = width, Height = height, _block = blocks };
    }

    public string ToSmallDisplay()
    {
      var sep = "\n";
      var row0 = "┏" + (Width==2?"━":"") + "┓";
      var row1 = "┗" + (Width==2?"━":"") + "┛";
      return sep + row0 + sep + row1 + sep;
    }

    public string ToLargeDisplay()
    {
      return @"
┏━┓
┃ ┃
┗━┛
";
    }
  }
}


