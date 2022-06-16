namespace DPAT_eindopdracht.Domain.Cell.State;

public class InitialValueCellState : BaseCellState
{
    public override string state { get;  }
    public InitialValueCellState(Cell context) : base(context)
    {
        state = "initial";
    }

    public override void SetFixedValue(int? value)
    {
        //A Inital Value cell should not change its fixed value
        Context.FixedValue ??= value;
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
        return Cell.CellType.Initial;
    }
}