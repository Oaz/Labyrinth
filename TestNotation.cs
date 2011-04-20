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

    [Test]
    public void LabyrinthFromSimpleNotationSize1x1_Bis()
    {
      var labyrinth = Labyrinth.From(" O)");
      Assert.That( labyrinth.Width, Is.EqualTo(1) );
      Assert.That( labyrinth.Height, Is.EqualTo(1) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From(" O)")) );
    }

    [Test]
    public void LabyrinthFromSimpleNotationSize2x1()
    {
      var labyrinth = Labyrinth.From("(O . O)");
      Assert.That( labyrinth.Width, Is.EqualTo(2) );
      Assert.That( labyrinth.Height, Is.EqualTo(1) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From("(O ")) );
      Assert.That( labyrinth[1,0], Is.EqualTo(Block.From(" O)")) );
    }

    [Test]
    public void LabyrinthFromSimpleNotationSize3x1()
    {
      var labyrinth = Labyrinth.From("(O . O . O)");
      Assert.That( labyrinth.Width, Is.EqualTo(3) );
      Assert.That( labyrinth.Height, Is.EqualTo(1) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From("(O ")) );
      Assert.That( labyrinth[1,0], Is.EqualTo(Block.From(" O ")) );
      Assert.That( labyrinth[2,0], Is.EqualTo(Block.From(" O)")) );
    }

    [Test]
    public void LabyrinthFromSimpleNotationSize3x2()
    {
      var labyrinth = Labyrinth.From(@"
(^ . ^ . ^)
(_ . _ . _)
");
      Assert.That( labyrinth.Width, Is.EqualTo(3) );
      Assert.That( labyrinth.Height, Is.EqualTo(2) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From("(^ ")) );
      Assert.That( labyrinth[1,0], Is.EqualTo(Block.From(" ^ ")) );
      Assert.That( labyrinth[2,0], Is.EqualTo(Block.From(" ^)")) );
      Assert.That( labyrinth[0,1], Is.EqualTo(Block.From("(_ ")) );
      Assert.That( labyrinth[1,1], Is.EqualTo(Block.From(" _ ")) );
      Assert.That( labyrinth[2,1], Is.EqualTo(Block.From(" _)")) );
    }

    [Test]
    public void LabyrinthFromSimpleNotationSize5x3()
    {
      var labyrinth = Labyrinth.From(@"
(^).(O . ^).(^ . ^)
(  . O .  ).(_).( )
(_ . O). _ . O . _)
");
      Assert.That( labyrinth.Width, Is.EqualTo(5) );
      Assert.That( labyrinth.Height, Is.EqualTo(3) );
      Assert.That( labyrinth[0,0], Is.EqualTo(Block.From("(^)")) );
      Assert.That( labyrinth[1,0], Is.EqualTo(Block.From("(O ")) );
      Assert.That( labyrinth[2,0], Is.EqualTo(Block.From(" ^)")) );
      Assert.That( labyrinth[3,0], Is.EqualTo(Block.From("(^ ")) );
      Assert.That( labyrinth[4,0], Is.EqualTo(Block.From(" ^)")) );
      Assert.That( labyrinth[0,1], Is.EqualTo(Block.From("(  ")) );
      Assert.That( labyrinth[1,1], Is.EqualTo(Block.From(" O ")) );
      Assert.That( labyrinth[2,1], Is.EqualTo(Block.From("  )")) );
      Assert.That( labyrinth[3,1], Is.EqualTo(Block.From("(_)")) );
      Assert.That( labyrinth[4,1], Is.EqualTo(Block.From("( )")) );
      Assert.That( labyrinth[0,2], Is.EqualTo(Block.From("(_ ")) );
      Assert.That( labyrinth[1,2], Is.EqualTo(Block.From(" O)")) );
      Assert.That( labyrinth[2,2], Is.EqualTo(Block.From(" _ ")) );
      Assert.That( labyrinth[3,2], Is.EqualTo(Block.From(" O ")) );
      Assert.That( labyrinth[4,2], Is.EqualTo(Block.From(" _)")) );
    }

    [Test]
    [ExpectedException( typeof(ArgumentException) )]
    public void LabyrinthFromSimpleNotation_Error1()
    {
      var labyrinth = Labyrinth.From("xxx");
    }

    [Test]
    [ExpectedException( typeof(ArgumentException) )]
    public void LabyrinthFromSimpleNotation_Error2()
    {
      var labyrinth = Labyrinth.From("(O");
    }

    [Test]
    [ExpectedException( typeof(ArgumentException) )]
    public void LabyrinthFromSimpleNotation_Error3()
    {
      var labyrinth = Labyrinth.From("(^).(O");
    }

    [Test]
    [ExpectedException( typeof(ArgumentException) )]
    public void LabyrinthFromSimpleNotation_Error4()
    {
      var labyrinth = Labyrinth.From(@"
(^).(O . ^).(^ . ^)
(  . O .  ).(_).( 
(_ . O). _ . O . _)
");
    }
  }
}


