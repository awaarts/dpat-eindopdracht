using System.Globalization;
using System.Text.RegularExpressions;
using DPAT_eindopdracht.Application.Services.Import;
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
    
    public void AddGroup(string validator, List<Cell.Cell> cells, string type)
    {
        _board.AddGroup(_groupFactory.CreateGroup(validator, cells, type));
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
                cell.x = x;
                cell.y = y;
                if (cellValues[y][x] > 0)
                {
                    
                    cell.SetFixedValue(cellValues[y][x]);
                    cell.SetState("correct");
                }

                _board.Cells[y][x] = cell;
            }
        }
    }
    
    private void CreateBoardGroup(string validator)
    {
        var cells = new List<Cell.Cell>();
        for (var y = 0; y < _board.Cells.Length; y++)
        {
            for (var x = 0; x < _board.Cells[y].Length; x++)
            {
                cells.Add(_board.Cells[y][x]);
            }
        }
        
        AddGroup(validator, cells, "board");
    }

    private void CreateHorizontalGroups(string validator)
    {
        for (var y = 0; y < _board.Cells.Length; y++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var x = 0; x < _board.Cells[y].Length; x++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(validator, cells, "horizontal");
        }
    }
    
    private void CreateVerticalGroups(string validator)
    {
        for (var x = 0; x < _board.Cells[0].Length; x++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var y = 0; y < _board.Cells.Length; y++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(validator, cells, "vertical");
        }
    }

    public void CreateRegions(string validator, int columns, int rows)
    {
        for (var row = 0; row < _board.Cells[0].Length / columns; row++)
        {
            
            for (var column = 0; column < _board.Cells.Length / rows; column++)
            {
                CreateRegion(column, row, rows,columns, validator);
            }
        }
    }

    public void Create4x4RegionGroups(string validator)
    {
        var columns = 2;
        var rows = 2;
        CreateRegions(validator,columns,rows);
    }
    
    public void Create6x6RegionGroups(string validator)
    {
        var columns = 3;
        var rows = 2;
        CreateRegions(validator,columns,rows);
    }
    public void Create9x9RegionGroups(string validator)
    {
        var columns = 3;
        var rows = 3;
        CreateRegions(validator,columns,rows);
    }
    
    public void CreateJigsawRegionGroups(string validator, int[][] regions)
    {
        List<Cell.Cell>[] regionList = new List<Cell.Cell>[9];
        for (int i = 0; i < regionList.Length; i++)
        {
            regionList[i] = new List<Cell.Cell>();
        }

        for (int y = 0; y < regions.Length; y++)
        {
            int[] region = regions[y];
            for (int x = 0; x < region.Length; x++)
            {
                int cell = region[x];
                regionList[cell].Add(_board.Cells[y][x]);
            }
        }

        foreach (List<Cell.Cell> region in regionList)
        {
            AddGroup(validator,region, "region");
        }
        
    }
    

    public void CreateRegion(int col, int row, int width, int height, string validator)
    {
        List<Cell.Cell> cells = new List<Cell.Cell>();
        for (var x = col * width; x < (col * width) + width; x++)
        {
            for (var y = row * height; y < (row * height) + height; y++)
            {
                cells.Add(_board.Cells[x][y]);
            }
        }
        AddGroup(validator, cells, "region");
    }

    public void Prepare4X4(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 4 || cellValues[3].Length != 4) return;
        _board = new Board();
        CreateBoard(4, 4);
        CreateCells(cellValues);
        CreateBoardGroup("unique");
        Create4x4RegionGroups("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void Prepare6X6(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 6 || cellValues[5].Length != 6) return;
        _board = new Board();
        CreateBoard(6, 6);
        CreateCells(cellValues);
        CreateBoardGroup("unique");
        Create6x6RegionGroups("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void Prepare9X9(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 9 || cellValues[8].Length != 9) return;
        _board = new Board();
        CreateBoard(9, 9);
        CreateCells(cellValues);
        CreateBoardGroup("unique");
        Create9x9RegionGroups("unique");
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void PrepareJigsaw(int[][] cellValues, int[][] regions)
    {
        _board = new Board();
        CreateBoard(9, 9);
        CreateCells(cellValues);
        CreateBoardGroup("unique");
        CreateJigsawRegionGroups("unique", regions);
        CreateHorizontalGroups("unique");
        CreateVerticalGroups("unique");
    }

    public void prepareSamurai(int[][][] boardCells)
    {
        BoardBuilder boardBuilder = new BoardBuilder();
        Board[] boards = new Board[5];
        _board = new BoardCollection();
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardBuilder.Prepare9X9(boardCells[i]);
            boards[i] = boardBuilder.GetBoard() as Board;
            _board.AddBoard(boards[i]);
            
        }
       
        
        
    }
}