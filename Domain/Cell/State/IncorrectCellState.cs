namespace DPAT_eindopdracht.Domain.Cell.State;

public class IncorrectCellState : BaseCellState
{
    public override string state { get;  }
    public IncorrectCellState(Cell context) : base(context)
    {
        state = "incorrect";
    }

    public override void SetFixedValue(int? value)
    {
        Context.FixedValue = value > 0 ? value : null;
        Context.SetState(Cell.CellType.Empty);
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
        return Cell.CellType.Incorrect;
    }
}