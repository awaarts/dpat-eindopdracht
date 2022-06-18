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
        //reset it to be an empty state, so we check again if it is correct or not
        Context.SetState(Cell.CellType.Empty);
        Context.SetFixedValue(value);
    }

    public override void SetHelperValue(int? helperValue)
    {
        if (helperValue > 0)
        {
            base.SetHelperValue(helperValue);
        }
    }

    public override Cell.CellType GetCellType()
    {
        return Cell.CellType.Correct;
    }
}