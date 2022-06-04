namespace DPAT_eindopdracht.Domain.Cell.State;

public class EmptyCellState : BaseCellState
{
    public EmptyCellState(Cell context) : base(context)
    {
    }

    public override void SetFixedValue(int? value)
    {
        if (value > 0)
        {
            base.SetFixedValue(value);
        }
    }

    public override void SetHelperValue(int? helperValue)
    {
        if (helperValue > 0)
        {
            base.SetHelperValue(helperValue);
        }
    }
}