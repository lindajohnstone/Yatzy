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
    }
}