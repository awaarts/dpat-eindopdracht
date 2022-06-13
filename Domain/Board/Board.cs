namespace DPAT_eindopdracht.Domain.Board;

public class Board : IBoard
{
    public Cell.Cell[][] Cells { get; private set; }
    public List<Group.Group> Groups { get; private set; }

    public Board()
    {
        this.Cells = Array.Empty<Cell.Cell[]>();
        this.Groups = new List<Group.Group>();
    }

    public void SetCells(Cell.Cell[][] cells)
    {
        Cells = cells;
    }

    public void AddGroup(Group.Group group)
    {
        this.Groups.Add(group);
    }
    
    public bool Validate()
    {
        return Groups.All(group => group.Validate());
    }
}