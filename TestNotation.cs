using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Labyrinth.Tests
{
  [TestFixture]
  public class TestDisplay
  {
    [Test]
    public void ToSimpleNotation()
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
    }
  }
}


