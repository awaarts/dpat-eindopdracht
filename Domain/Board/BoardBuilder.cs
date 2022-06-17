using Castle.DynamicProxy.Generators;
using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;

namespace DPAT_eindopdracht.Domain.Board;

public class BoardBuilder
{
    private IBoard _board;
    private readonly CellFactory _cellFactory;
    private readonly GroupFactory _groupFactory;

    public BoardBuilder()
    {
        _board = new Board();
        _cellFactory = new CellFactory();
        _groupFactory = new GroupFactory();
        
        //factory inits
        _groupFactory.AddGroupType(typeof(UniqueGroup), Group.Group.GroupTypes.Unique);
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
    
    public void CreateBoardCollection(int width, int length)
    {
        _board = new BoardCollection();
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
    
    public void AddGroup(Group.Group.GroupTypes groupType, List<Cell.Cell> cells, string type)
    {
        var group = _groupFactory.CreateGroup(groupType, cells, type);
        if (group != null)
        {
            _board.AddGroup(group);
        }
    }
    
    public void AddBoards(List<Board> boards)
    {
        IBoard newBoard = new BoardCollection();
        boards.ForEach(board => newBoard.AddBoard(board));
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
                    cell.SetState(Cell.Cell.CellType.Initial);
                }

                _board.Cells[y][x] = cell;
            }
        }
    }

    public void CreateHorizontalGroups(Group.Group.GroupTypes groupType)
    {
        for (var y = 0; y < _board.Cells.Length; y++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var x = 0; x < _board.Cells[y].Length; x++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(groupType, cells, "horizontal");
        }
    }
    
    public void CreateVerticalGroups(Group.Group.GroupTypes groupType)
    {
        for (var x = 0; x < _board.Cells[0].Length; x++)
        {
            List<Cell.Cell> cells = new List<Cell.Cell>();
            
            for (var y = 0; y < _board.Cells.Length; y++)
            {
                cells.Add(_board.Cells[y][x]);
            }
            
            AddGroup(groupType, cells, "vertical");
        }
    }

    public void CreateRegions(Group.Group.GroupTypes groupType, int columns, int rows)
    {
        for (var row = 0; row < _board.Cells[0].Length / columns; row++)
        {
            
            for (var column = 0; column < _board.Cells.Length / rows; column++)
            {
                CreateRegion(column, row, rows,columns, groupType);
            }
        }
    }

    public void Create4X4RegionGroups(Group.Group.GroupTypes groupType)
    {
        var columns = 2;
        var rows = 2;
        CreateRegions(groupType,columns,rows);
    }
    
    public void Create6X6RegionGroups(Group.Group.GroupTypes groupType)
    {
        var columns = 2;
        var rows = 3;
        CreateRegions(groupType,rows,columns);
    }
    public void Create9X9RegionGroups(Group.Group.GroupTypes groupType)
    {
        var columns = 3;
        var rows = 3;
        CreateRegions(groupType,columns,rows);
    }
    
    public void CreateJigsawRegionGroups(Group.Group.GroupTypes groupType, int[][] regions)
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
            AddGroup(groupType,region, "region");
        }
        
    }
    

    public void CreateRegion(int col, int row, int width, int height, Group.Group.GroupTypes groupType)
    {
        List<Cell.Cell> cells = new List<Cell.Cell>();
        for (var x = col * width; x < (col * width) + width; x++)
        {
            for (var y = row * height; y < (row * height) + height; y++)
            {
                cells.Add(_board.Cells[x][y]);
            }
        }
        AddGroup(groupType, cells, "region");
    }
    
    private void CreateSamuraiRegions(Board[] boards)
    {
        foreach (Board board in boards)
        {
            foreach (Group.Group group in board.Groups)
            {
                _board.Groups.Add(group);
            }
        }
    }

    private void CreateSamuraiCells(Board[] boards)
    {
        Dictionary<int, int> boardOffsetX = new Dictionary<int, int>()
        {
            { 0, 0 },
            { 1, 12 },
            { 2, 6 },
            { 3, 0 },
            { 4, 12 }
        };
        Dictionary<int, int> boardOffsetY = new Dictionary<int, int>()
        {
            { 0, 0 },
            { 1, 0 },
            { 2, 6 },
            { 3, 12 },
            { 4, 12 }
        };


        for (int i = 0; i < boards.Length; i++)
        {
            Board board = boards[i];
            board.offsetX = boardOffsetX[i];
            board.offsetY = boardOffsetY[i];
            for (int y = 0; y < board.Cells.Length; y++)
            {
                Cell.Cell[] col = board.Cells[y];
                for (int x = 0; x < col.Length; x++)
                {
                    Cell.Cell cell = board.Cells[y][x];
                    _board.Cells[y + boardOffsetY[i]][x + boardOffsetX[i]] = cell;
                    cell.y = y + boardOffsetY[i];
                    cell.x = x + boardOffsetX[i];
                }

            }
        }
    }

    public void Prepare4X4(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 4 || cellValues[3].Length != 4) return;
        _board = new Board();
        CreateBoard(4, 4);
        CreateCells(cellValues);
        Create4X4RegionGroups(Group.Group.GroupTypes.Unique);
        CreateHorizontalGroups(Group.Group.GroupTypes.Unique);
        CreateVerticalGroups(Group.Group.GroupTypes.Unique);
    }

    public void Prepare6X6(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 6 || cellValues[5].Length != 6) return;
        _board = new Board();
        CreateBoard(6, 6);
        CreateCells(cellValues);
        Create6X6RegionGroups(Group.Group.GroupTypes.Unique);
        CreateHorizontalGroups(Group.Group.GroupTypes.Unique);
        CreateVerticalGroups(Group.Group.GroupTypes.Unique);
    }

    public void Prepare9X9(int[][] cellValues)
    {
        //check if we have been given the correct format
        if (cellValues.Length != 9 || cellValues[8].Length != 9) return;
        _board = new Board();
        CreateBoard(9, 9);
        CreateCells(cellValues);
        Create9X9RegionGroups(Group.Group.GroupTypes.Unique);
        CreateHorizontalGroups(Group.Group.GroupTypes.Unique);
        CreateVerticalGroups(Group.Group.GroupTypes.Unique);
    }

    public void PrepareJigsaw(int[][] cellValues, int[][] regions)
    {
        _board = new Board();
        CreateBoard(9, 9);
        CreateCells(cellValues);
        CreateJigsawRegionGroups(Group.Group.GroupTypes.Unique, regions);
        CreateHorizontalGroups(Group.Group.GroupTypes.Unique);
        CreateVerticalGroups(Group.Group.GroupTypes.Unique);
    }

    public void PrepareSamurai(int[][][] boardCells)
    {
        CreateBoardCollection(21, 21);
        Board[] boards = new Board[5];
        for (var i = 0; i < boardCells.Length; i++)
        {
            BoardBuilder boardBuilder = new BoardBuilder();
            boardBuilder.CreateBoard(9, 9);
            boardBuilder.Prepare9X9(boardCells[i]);
            boards[i] = (Board) boardBuilder.GetBoard();
            _board.AddBoard(boards[i]);
        }
        CreateSamuraiCells(boards);
        CreateSamuraiRegions(boards);
    }
}