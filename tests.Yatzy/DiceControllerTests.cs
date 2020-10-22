using System.Data;
using System.Linq;
using Xunit;
using Yatzy;

namespace tests.Yatzy
{
    public class DiceControllerTests
    {
        [Fact]
        public void Should_Return_Five_Dice_Roll()
        {
            // arrange
            var controller = new DiceController();
            // act
            var result = controller.Roll();
            // assert
            foreach(var die in result)
            {
                Assert.InRange(die, 1, 6);
            }
            Assert.Equal(5, result.Length);
        }

        [Fact]
        public void Should_Reroll_Previous_Roll()
        {
            // arrange
            var controller = new DiceControllerStub();
            var roll = new [] {1, 0, 4, 0, 5};

            // act
            var result = controller.Reroll(roll);

            var first = new [] {1, 2, 3, 4, 5};

            var expectedIntersect = new [] {1, 4, 5};
            var intersect = roll.Intersect(first).ToArray();

            // assert
            foreach(var die in result)
            {
                Assert.InRange(die, 1, 6);
            }
            Assert.Equal(expectedIntersect, intersect);
        }
    }
}