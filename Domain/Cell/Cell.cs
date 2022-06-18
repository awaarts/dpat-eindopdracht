using DPAT_eindopdracht.Domain.Cell.State;

namespace DPAT_eindopdracht.Domain.Cell;

public class Cell
{
    public enum CellType
    {
        Empty,
        Correct,
        Incorrect,
        Initial
    }
    public ICellState CellState { get; private set; }
    public int? FixedValue { get; set; }
    public int? HelperValue { get; set; }
    
    public int x { get; set; }
    public int y { get; set; }


    public Cell(ICellState? state)
    {
        CellState = state ?? new EmptyCellState(this);
    }
    public Cell Clone()
    {
        Cell clone = new Cell(null);
        clone.SetState(CellState.GetCellType());
        return clone;
    }

    public void SetState(CellType state)
    {
        CellState = state switch
        {
            CellType.Empty => new EmptyCellState(this),
            CellType.Correct => new CorrectCellState(this),
            CellType.Incorrect => new IncorrectCellState(this),
            CellType.Initial => new InitialValueCellState(this)
        };
    }

    public void SetFixedValue(int? value)
    {
        CellState.SetFixedValue(value);
    }

    public void SetHelperValue(int? value)
    {
        CellState.SetHelperValue(value);
    }
    
}