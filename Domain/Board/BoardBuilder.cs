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
    
    public void CreateBoard()
    {
        _board = new Board();
    }

    public IBoard GetBoard()
    {
        return _board;
    }
    
    public void AddCells(Cell.Cell[][] cells)
    {
        _board.SetCells(cells);
    }
    
    public void AddGroup(Group.Group group)
    {
        _board.AddGroup(group);
    }
    
    public void AddBoards(List<Board> boards)
    {
        IBoard newBoard = new BoardCollection();
        //TODO: add boards to this board, making it a board collection and update board to be this new board
        throw new NotImplementedException();

        _board = newBoard;
    }

    private List<Group.Group> CreateHorizontalGroups(Cell.Cell[][] cells, int verticalLength)
    {
        var groups = new List<Group.Group>();
        for (var i = 0; i < verticalLength; i++)
        {
            var group = _groupFactory.CreateGroup("unique", cells[i].ToList());
            groups.Add(group);
        }

        return groups;
    }
    
    private List<Group.Group> CreateVerticalGroups(Cell.Cell[][] cells, int verticalLength, int horizontalLength)
    {
        var groups = new List<Group.Group>();
        for (var column = 0; column < horizontalLength; column++)
        {
            var cellLine = new List<Cell.Cell>();
            for (var row = 0; row < verticalLength; row++)
            {
                cellLine.Add(cells[row][column]);
            }
            
            var group = _groupFactory.CreateGroup("unique", cellLine);
            groups.Add(group);
        }

        return groups;
    }
    
    private Group.Group CreateRegionGroup(Cell.Cell[][] cells)
    {
        return _groupFactory.CreateGroup("unique", cells.SelectMany(cellRow => cellRow).ToList());
    }

    public void Prepare4X4(Cell.Cell[][] cells)
    {

        //check if we have been given the correct format
        if (cells.Length == 4 && cells[3].Length == 4)
        {
            CreateBoard();
            CreateHorizontalGroups(cells, 4).ForEach(AddGroup);
            CreateVerticalGroups(cells, 4, 4).ForEach(AddGroup);
            AddGroup(CreateRegionGroup(cells));
            Console.Write(_board.Groups.Count);
            AddCells(cells);
        }
    }

    public void Prepare6X6(Cell.Cell[][] cells)
    {
        //check if we have been given the correct format
        if (cells.Length == 6 && cells[5].Length == 6)
        {
            CreateBoard();
            CreateHorizontalGroups(cells, 6).ForEach(AddGroup);
            CreateVerticalGroups(cells, 6, 6).ForEach(AddGroup);
            AddGroup(CreateRegionGroup(cells));
        }
    }

    public void Prepare9X9(Cell.Cell[][] cells)
    {
        //check if we have been given the correct format
        if (cells.Length == 9 && cells[8].Length == 9)
        {
            CreateBoard();
            CreateHorizontalGroups(cells, 9).ForEach(AddGroup);
            CreateVerticalGroups(cells, 9, 9).ForEach(AddGroup);
            AddGroup(CreateRegionGroup(cells));
        }
    }
}