namespace DPAT_eindopdracht.Domain.Board;

public class BoardCollection : IBoard
{
    public Cell.Cell[][] Cells { get; set; }
    public List<Group.Group> Groups { get; }

    List<IBoard> Boards { get; set; }

    public BoardCollection()
    {
        Cells = Array.Empty<Cell.Cell[]>();
        Groups = new List<Group.Group>();
        Boards = new List<IBoard>();
    }

    public void AddGroup(Group.Group group)
    {
        Groups.Add(group);
    }
 
    public void AddBoard(IBoard board)
    {
        Boards.Add(board);
    }
    
    public void SetCells(Cell.Cell[][] cells)
    {
        Cells = cells;
    }

    public bool Validate()
    {
        return Boards.All(board => board.Validate());
    }
}