namespace DPAT_eindopdracht.Domain.Cell.State;

public class CorrectCellState : BaseCellState
{
    public override string state { get;  }
    public CorrectCellState(Cell context) : base(context)
    {
        state = "correct";
    }

    public override void SetFixedValue(int? value)
    {
        Context.FixedValue ??= value;
        //A correct cell should not change its fixed value
    }

    public override void SetHelperValue(int? helperValue)
    {
        if (helperValue > 0)
        {
            base.SetHelperValue(helperValue);
        }
    }
}