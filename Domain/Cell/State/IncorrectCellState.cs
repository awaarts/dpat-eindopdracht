namespace DPAT_eindopdracht.Domain.Cell.State;

public class IncorrectCellState : BaseCellState
{
    public IncorrectCellState(Cell context) : base(context)
    {
    }

    public override void SetFixedValue(int value)
    {
        if (value > 0)
        {
            Context.FixedValue = value;
        }
        else
        {
            Context.FixedValue = null;
        }
        Context.SetState("empty");
    }
}