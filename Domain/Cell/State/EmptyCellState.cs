namespace DPAT_eindopdracht.Domain.Cell.State;

public class EmptyCellState : BaseCellState
{
    public override string state { get;  }
    public EmptyCellState(Cell context) : base(context)
    {
        state = "empty";
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