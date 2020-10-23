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
            controller.RollAllDice();
            var result = controller.Dice;

            // assert
            foreach(var die in result)
            {
                Assert.InRange(die, 1, 6);
            }
            Assert.Equal(5, result.Length);
        }

        [Fact]
        public void Should_Reroll_One_Die()
        {
            // arrange
            var controller = new DiceControllerStub();
            controller.RollAllDice();
            var initialRoll = controller.getDiceArray();

            // act
            controller.RollOneDie(0);
            var currentRoll = controller.getDiceArray();
            var intersect = initialRoll.Intersect(currentRoll).ToArray();

            // assert
            var expectedIntersect = new [] {2, 3, 4, 5};

            Assert.InRange(initialRoll[0], 1, 6);
            Assert.Equal(expectedIntersect, intersect);
        }
    }
}