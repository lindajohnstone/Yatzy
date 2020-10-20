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
            var query = result.Where(_ => _ > 0 && _ < 7);
            var isValidRoll = query.ToArray().Length == 5;
            // assert
            Assert.True(isValidRoll);
        }
    }
}