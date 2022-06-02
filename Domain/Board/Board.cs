namespace DPAT_eindopdracht.Domain.Board;

public class Board : IBoard
{
    public Cell.Cell[][] Cells { get; private set; }

    public Board()
    {
        this.Cells = Array.Empty<Cell.Cell[]>();
    }

    public void SetCells(Cell.Cell[][] cells)
    {
        Cells = cells;
    }
    
    public bool Validate()
    {
        throw new NotImplementedException();
    }
}