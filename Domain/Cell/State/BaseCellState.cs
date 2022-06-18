namespace DPAT_eindopdracht.Domain.Cell.State;

public abstract class BaseCellState : ICellState
{
    public Cell Context { get; }
    public virtual string state { get;  }
    
    public BaseCellState(Cell context)
    {
        state = "empty";
        Context = context;
    }
    
    public virtual void SetFixedValue(int? value)
    {
        Context.FixedValue = value;
    }

    public virtual void SetHelperValue(int? helperValue)
    {
        Context.HelperValue = helperValue;
    }

    public virtual Cell.CellType GetCellType()
    {
        return Cell.CellType.Empty;
    }
}