using System.Text.RegularExpressions;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Domain.Board;

public class BoardBuilder
{
    private IBoard board;
    private CellFactory _cellFactory;

    public BoardBuilder()
    {
        board = new Board();
        _cellFactory = new CellFactory();
    }
    
    public void CreateBoard()
    {
        board = new Board();
    }

    public IBoard GetBoard()
    {
        return board;
    }
    
    public void AddCells(List<Cell.Cell> cells)
    {
        //TODO: add cells to new Board
        throw new NotImplementedException();
    }
    
    public void AddGroups(List<Group> groups)
    {
        //TODO: add groups with cells to new Board
        throw new NotImplementedException();
    }
    
    public void AddBoards(List<Board> boards)
    {
        IBoard newBoard = new BoardCollection();
        //TODO: add boards to this board, making it a board collection and update board to be this new board
        throw new NotImplementedException();

        board = newBoard;
    }

    public void Prepare3X3()
    {
        throw new NotImplementedException();
    }

    public void Prepare6X6()
    {
        throw new NotImplementedException();
    }

    public void Prepare9X9()
    {
        throw new NotImplementedException();
    }
}