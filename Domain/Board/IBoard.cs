namespace DPAT_eindopdracht.Domain.Board;

public interface IBoard
{
     Cell.Cell[][] Cells
     {
          get;
     }

     List<Group.Group> Groups
     {
         get;
     }

     public void SetCells(Cell.Cell[][] cells);
     public void AddGroup(Group.Group group);

     public void AddBoard(IBoard board);
     public bool Validate();

     public void UpdateCell(int x, int y, int newValue);
}