namespace DPAT_eindopdracht.Domain.Cell.State;

public class IncorrectCellState : BaseCellState
{
    public IncorrectCellState(Cell context) : base(context)
    {
    }

    public override void SetFixedValue(int? value)
    {
        Context.FixedValue = value > 0 ? value : null;
        Context.SetState("empty");
    }
}