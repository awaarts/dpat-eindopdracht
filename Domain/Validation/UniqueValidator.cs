namespace DPAT_eindopdracht.Domain.Validation;

public class UniqueValidator : IValidator
{
    public bool Validate(List<Cell.Cell> cells)
    {
        var numbersPresent = new List<int>();
        var isValid = true;  
        cells.ForEach(cell =>
        {
            if (cell.FixedValue != null)
            {
                if (numbersPresent.Contains((int)cell.FixedValue))
                {
                    isValid = false;
                } else
                {
                    numbersPresent.Add((int) cell.FixedValue);
                }
            }
        });
        return isValid;
    }
}