namespace DPAT_eindopdracht.Domain.Board;

public class Board : IBoard
{
    public Cell.Cell[][] Cells { get; private set; }
    public List<Group.Group> Groups { get; }
    public List<IBoard> Boards { get; set; }
    
    public int offsetX { get; set; }
    public int offsetY { get; set; }

    public Board()
    {
        Cells = Array.Empty<Cell.Cell[]>();
        Groups = new List<Group.Group>();
    }

    public void SetCells(Cell.Cell[][] cells)
    {
        Cells = cells;
    }

    public void AddGroup(Group.Group group)
    {
        this.Groups.Add(group);
    }

    public void AddBoard(IBoard board)
    {
        throw new Exception("Can't create board inside board");
    }

    public bool Validate()
    {
        return Groups.All(group => group.Validate());
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