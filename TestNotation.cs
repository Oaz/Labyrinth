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
			Assert.That( new Block { Closed = Walls.Nothing }.ToString(), Is.EqualTo("   ") );
			Assert.That( new Block { Closed = Walls.Left }.ToString(),    Is.EqualTo("(  ") );
			Assert.That( new Block { Closed = Walls.Right }.ToString(),   Is.EqualTo("  )") );
			Assert.That( new Block { Closed = Walls.Bottom }.ToString(),  Is.EqualTo(" _ ") );
			Assert.That( new Block { Closed = Walls.Top }.ToString(),     Is.EqualTo(" ^ ") );
		}
  }
}


