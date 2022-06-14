using System.Text.RegularExpressions;
using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;

namespace DPAT_eindopdracht.Domain.Board;

public class BoardBuilder
{
    private IBoard _board;
    private CellFactory _cellFactory;
    private GroupFactory _groupFactory;

    public BoardBuilder()
    {
        _board = new Board();
        _cellFactory = new CellFactory();
        _groupFactory = new GroupFactory();
        
        //factory inits
        _groupFactory.AddGroupType(typeof(UniqueGroup), "unique");
    }
    
    public void CreateBoard(int width, int length)
    {
        _board = new Board();
        Cell.Cell[][] cells = new Cell.Cell[length][];
        for (int i = 0; i < length; i++)
        {
            cells[i] = new Cell.Cell[width];
        }

        _board.SetCells(cells);
    }

    public IBoard GetBoard()
    {
        return _board;
    }
    
    public void SetCell(int x, int y, Cell.Cell cell)
    {
        _board.Cells[y][x] = cell;
    }
    
    public void AddGroup(string type, List<Cell.Cell> cells)
    {
        _board.AddGroup(_groupFactory.CreateGroup(type, cells));
    }
    
    public void AddBoards(List<Board> boards)
    {
        IBoard newBoard = new BoardCollection();
        //TODO: add boards to this board, making it a board collection and update board to be this new board
        throw new NotImplementedException();

        _board = newBoard;
    }
    
    private void CreateCells(int[][] cellValues)
    {
        for (var y = 0; y < cellValues.Length; y++)
        {
            for (var x = 0; x < cellValues[y].Length; x++)
            {
                Cell.Cell cell = _cellFactory.CreateCell("empty");
                if (cellValues[y][x] > 0)
                {
                    cell.SetFixedValue(cellValues[y][x]);
                    cell.SetState("correct");
                }

                _board.Cells[y][x] = cell;
            }
        }
    }
    
    private void CreateRegionGroup(string type)
    {
        var cells = new List<Cell.Cell>();
        for (var y = 0; y < _board.Cells.Length; y++)
        {
            for (var x = 0; x < _board.Cells[y].Length; x++)
            {
                cells.Add(_board.Cells[y][x]);
            }
        }
        
        AddGroup(type, cells);
    }

    private void CreateHorizontalGroups(string type)
    {
        for (var y = 0; y < _board.Cells.Length; y++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var x = 0; x < _board.Cells[y].Length; x++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(type, cells);
        }
    }
    
    private void CreateVerticalGroups(string type)
    {
        for (var x = 0; x < _board.Cells[0].Length; x++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var y = 0; y < _board.Cells.Length; y++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(type, cells);
        }
    }

    public void Prepare4X4(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 4 || cellValues[3].Length != 4) return;
        
        CreateBoard(4, 4);
        CreateCells(cellValues);
        CreateRegionGroup("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void Prepare6X6(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 6 || cellValues[5].Length != 6) return;
        
        CreateBoard(6, 6);
        CreateCells(cellValues);
        CreateRegionGroup("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void Prepare9X9(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 9 || cellValues[8].Length != 9) return;
        
        CreateBoard(9, 9);
        CreateCells(cellValues);
        CreateRegionGroup("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }
}