namespace Yatzy
{
    public interface IInputReader
    {
        Choice GetPlayerRollChoice();
        int[] GetDiceToHold();
        Category GetCategoryChoice();
    }
}