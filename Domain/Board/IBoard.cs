namespace DPAT_eindopdracht.Domain.Board;

public interface IBoard
{
     Cell.Cell[][] Cells
     {
          get;
     }

     public bool Validate();
}