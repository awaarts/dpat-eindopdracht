namespace DPAT_eindopdracht.Domain.Cell.State;

public class CorrectCellState : BaseCellState
{
    public CorrectCellState(Cell context) : base(context)
    {
    }

    public override void SetFixedValue(int? value)
    {
        //A correct cell should not change its fixed value
    }
}