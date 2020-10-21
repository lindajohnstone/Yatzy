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
            var controller = new DiceController();
            var roll = new [] {1, 0, 5, 0, 5};
            var expectedIntersect = new [] {1, 5, 5};

            // act
            var result = controller.Reroll(roll);
            var intersect = roll.Intersect(result);

            // assert
            foreach(var die in result)
            {
                Assert.InRange(die, 1, 6);
            }
            Assert.Equal(expectedIntersect, intersect);
        }
    }
}