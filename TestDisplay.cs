using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Labyrinth.Tests
{
	[TestFixture]
	public class TestDisplay
	{
		[Test]
		public void Small_1x1()
		{
      Assert.That( Labyrinth.From("(O)").ToSmallDisplay(), Is.EqualTo(@"
┏┓
┗┛
") );
    }

		[Test]
		public void Large_1x1()
		{
      Assert.That( Labyrinth.From("(O)").ToLargeDisplay(), Is.EqualTo(@"
┏━┓
┃ ┃
┗━┛
") );
    }
  }
}




