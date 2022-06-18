namespace DPAT_eindopdracht.Domain.Cell.State;

public class EmptyCellState : BaseCellState
{
    public EmptyCellState(Cell context) : base(context)
    {
        Context.FixedValue = null;
    }

    public override void SetHelperValue(int? helperValue)
    {
        if (helperValue > 0)
        {
            base.SetHelperValue(helperValue);
        }
    }
}