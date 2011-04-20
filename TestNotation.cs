using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Labyrinth.Tests
{
  [TestFixture]
  public class TestNotation
  {
    [Test]
    public void BlockToSimpleNotation()
    {
      Assert.That( new Block { Closed = Walls.Nothing }.ToString(),                Is.EqualTo("   ") );

      Assert.That( new Block { Closed = Walls.Left }.ToString(),                   Is.EqualTo("(  ") );
      Assert.That( new Block { Closed = Walls.Right }.ToString(),                  Is.EqualTo("  )") );
      Assert.That( new Block { Closed = Walls.Bottom }.ToString(),                 Is.EqualTo(" _ ") );
      Assert.That( new Block { Closed = Walls.Top }.ToString(),                    Is.EqualTo(" ^ ") );

      Assert.That( new Block { Closed = Walls.Top + Walls.Bottom }.ToString(),     Is.EqualTo(" O ") );
      Assert.That( new Block { Closed = Walls.Top + Walls.Left }.ToString(),       Is.EqualTo("(^ ") );
      Assert.That( new Block { Closed = Walls.Top + Walls.Right }.ToString(),      Is.EqualTo(" ^)") );
      Assert.That( new Block { Closed = Walls.Bottom + Walls.Left }.ToString(),    Is.EqualTo("(_ ") );
      Assert.That( new Block { Closed = Walls.Bottom + Walls.Right }.ToString(),   Is.EqualTo(" _)") );
      Assert.That( new Block { Closed = Walls.Left + Walls.Right }.ToString(),     Is.EqualTo("( )") );

      Assert.That( new Block { Closed = Walls.Top + Walls.Bottom + Walls.Left }.ToString(),     Is.EqualTo("(O ") );
      Assert.That( new Block { Closed = Walls.Top + Walls.Bottom + Walls.Right }.ToString(),    Is.EqualTo(" O)") );
      Assert.That( new Block { Closed = Walls.Top + Walls.Left + Walls.Right }.ToString(),      Is.EqualTo("(^)") );
      Assert.That( new Block { Closed = Walls.Bottom + Walls.Left + Walls.Right }.ToString(),   Is.EqualTo("(_)") );

      Assert.That( new Block { Closed = Walls.Top + Walls.Bottom + Walls.Left + Walls.Right }.ToString(),   Is.EqualTo("(O)") );
    }

    [Test]
    public void BlockFromSimpleNotation()
    {
      Assert.That( Block.From("   "), Is.EqualTo(new Block { Closed = Walls.Nothing }) );

      Assert.That( Block.From("(  "), Is.EqualTo(new Block { Closed = Walls.Left }) );
      Assert.That( Block.From("  )"), Is.EqualTo(new Block { Closed = Walls.Right }) );
      Assert.That( Block.From(" _ "), Is.EqualTo(new Block { Closed = Walls.Bottom }) );
      Assert.That( Block.From(" ^ "), Is.EqualTo(new Block { Closed = Walls.Top }) );

      Assert.That( Block.From(" O "), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Bottom }) );
      Assert.That( Block.From("(^ "), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Left }) );
      Assert.That( Block.From(" ^)"), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Right }) );
      Assert.That( Block.From("(_ "), Is.EqualTo(new Block { Closed = Walls.Bottom + Walls.Left }) );
      Assert.That( Block.From(" _)"), Is.EqualTo(new Block { Closed = Walls.Bottom + Walls.Right }) );
      Assert.That( Block.From("( )"), Is.EqualTo(new Block { Closed = Walls.Left + Walls.Right }) );

      Assert.That( Block.From("(O "), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Bottom + Walls.Left }) );
      Assert.That( Block.From(" O)"), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Bottom + Walls.Right }) );
      Assert.That( Block.From("(^)"), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Left + Walls.Right }) );
      Assert.That( Block.From("(_)"), Is.EqualTo(new Block { Closed = Walls.Bottom + Walls.Left + Walls.Right }) );

      Assert.That( Block.From("(O)"), Is.EqualTo(new Block { Closed = Walls.Top + Walls.Bottom + Walls.Left + Walls.Right }) );
    }

    [Test]
    public void LabyrinthFromSimpleNotationSize1x1()
    {
      var labyrinth = Labyrinth.From("(O ");
      Assert.That( labyrinth.Width, Is.EqualTo(1) );
      Assert.That( labyrinth.Height, Is.EqualTo(1) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From("(O ")) );
    }
  }
}


