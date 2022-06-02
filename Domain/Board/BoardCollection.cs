namespace DPAT_eindopdracht.Domain.Board;

public class BoardCollection : IBoard
{
    public Cell.Cell[][] Cells { get; set; }

    List<IBoard> Boards { get; set; }

    public BoardCollection()
    {
        Cells = Array.Empty<Cell.Cell[]>();
        Boards = new List<IBoard>();
    }
    
    

    public void AddBoard(IBoard board)
    {
        Boards.Add(board);
    }
    
    public bool Validate()
    {
        throw new NotImplementedException();
    }
}