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

    public void UpdateCell(int x, int y, int? newValue)
    {
        if (newValue != null)
        {
            Cells[y][x].FixedValue = newValue;
            Cells[y][x].SetState(Validate() ? Cell.Cell.CellType.Correct : Cell.Cell.CellType.Incorrect);
        }
        else
        {
            Cells[y][x].SetState(Cell.Cell.CellType.Empty);
        }
    }
    public void UpdateHelperValue(int x, int y, int? newValue)
    {
        Cells[y][x].SetHelperValue(newValue);
    }
}