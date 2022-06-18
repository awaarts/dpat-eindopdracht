using System.Collections.Generic;
using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;
using System;
using Xunit;

namespace DPAT_eindopdracht.test.Domain;

public class BoardTest
{
    [Fact]
    public void CanGetBoardWithNoConfiguration()
    {
        var boardBuilder = new BoardBuilder();
        
        boardBuilder.CreateBoard(0,0);
        var board = boardBuilder.GetBoard();
        
        Assert.Empty(board.Cells);
    }
    
    [Fact]
    public void CanSetBoardWithCellsInFactory()
    {
        var boardBuilder = new BoardBuilder();
        var cell = new Cell(null);
        
        boardBuilder.CreateBoard(1,1);
        boardBuilder.SetCell(0, 0, cell);
        var board = boardBuilder.GetBoard();
        
        Assert.Equal(cell, board.Cells[0][0]);
    }
    
    [Fact]
    public void CanAddGroupToBoardInFactory()
    {
        var boardBuilder = new BoardBuilder();
        
        boardBuilder.CreateBoard(1,1);
        boardBuilder.AddGroup(Group.GroupTypes.Unique, new List<Cell>(), "unique");
        var board = boardBuilder.GetBoard();
        
        Assert.NotEmpty(board.Groups);
    }
    
    [Fact]
    public void CanCreateBoardCollection()
    {
        var boardBuilder = new BoardBuilder();
        
        boardBuilder.CreateBoardCollection(1,1);
        
        Assert.IsType<BoardCollection>(boardBuilder.GetBoard());
    }
    
    [Fact]
    public void CanAddBoardToBoardCollection()
    {
        var boardBuilder = new BoardBuilder();
        var board = new Board();
        
        boardBuilder.CreateBoardCollection(1,1);
        boardBuilder.AddBoards(new List<Board>{board});
        var boardCollection = boardBuilder.GetBoard();
        
        Assert.NotEmpty(boardCollection.Boards);
    }
    
    [Fact]
    public void CanCreate4X4Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(4, 4);
        
        boardBuilder.Prepare4X4(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.Equal(4, board.Cells.Length);
    }
    
    [Fact]
    public void CanCreate6X6Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(6, 6);
        
        boardBuilder.Prepare6X6(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.Equal(6, board.Cells.Length);
    }
    
    [Fact]
    public void CanCreate9X9Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(9, 9);
        
        boardBuilder.Prepare9X9(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.Equal(9, board.Cells.Length);
    }
    
    [Fact]
    public void CanCreateJigssawBoard()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(9, 9);
        
        boardBuilder.PrepareJigsaw(cells, cells);
        var board = boardBuilder.GetBoard();
        
        Assert.Equal(9, board.Cells.Length);
    }
    
    [Fact]
    public void CanCreateSamuraiBoard()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateSamuraiTestCellsForPrepare(9, 9);

        boardBuilder.PrepareSamurai(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.IsType<BoardCollection>(board);
    }
    
    
    
    [Fact]
    public void CannotCreateIncorrect4X4Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(3, 3);
        
        boardBuilder.Prepare4X4(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.NotEqual(3, board.Cells.Length);
    }
    
    [Fact]
    public void CannotCreateIncorrect6X6Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(3, 3);
        
        boardBuilder.Prepare6X6(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.NotEqual(3, board.Cells.Length);
    }
    
    [Fact]
    public void CannotCreateIncorrect9X9Board()
    {
        var boardBuilder = new BoardBuilder();
        var cells = CreateTestCellsForPrepare(3, 3);
        
        boardBuilder.Prepare9X9(cells);
        var board = boardBuilder.GetBoard();
        
        Assert.NotEqual(3, board.Cells.Length);
    }
    
    [Fact]
    public void GetOnlyEmptyBoardsInBoard()
    {
        var board = new Board();

        board.Boards = new List<IBoard>();
        
        Assert.Empty(board.Boards);
    }
    
    [Fact]
    public void AddingBoardToBoardGivesException()
    {
        var board = new Board();
        
        Assert.Throws<Exception>(() => board.AddBoard(new Board()));
    }
    
    [Fact]
    public void CanGetBoardOffsetX()
    {
        var board = new Board();

        board.offsetX = 1;
        
        Assert.Equal(1, board.offsetX);
    }
    
    [Fact]
    public void CanGetBoardOffsetY()
    {
        var board = new Board();

        board.offsetY = 1;
        
        Assert.Equal(1, board.offsetY);
    }
    
    [Fact]
    public void CanUpdateCellInBoard()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoard(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateCell(0,0, 2);

        Assert.Equal(board.Cells[0][0], cell);
        Assert.Equal(2, board.Cells[0][0].FixedValue);
    }
    
    [Fact]
    public void CanMakeCellInBoardEmpty()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoard(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateCell(0,0, null);

        Assert.Equal(
            Cell.CellType.Empty,
            board.Cells[0][0].CellState.GetCellType()
        );
    }
    
    [Fact]
    public void CanUpdateHelpValueOfCellInBoard()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoard(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateHelperValue(0,0, 1);

        Assert.Equal(1, board.Cells[0][0].HelperValue);
    }
    
    [Fact]
    public void CanValidateGroupsInCollectionValidators()
    {
        var builder = new BoardBuilder();
        builder.CreateBoard(1, 1);
        builder.AddGroup(Group.GroupTypes.Unique,new List<Cell>(), "unique");
        var board = builder.GetBoard();
        builder.CreateBoardCollection(1, 1);
        var boardCollection = builder.GetBoard();
        
        boardCollection.AddBoard(board);
        var result = boardCollection.Validate();

        Assert.True(result);
    }
    
    [Fact]
    public void CanAddGroupToBoardCollection()
    {
        var boardCollection = new BoardCollection();
        boardCollection.AddGroup(new Group(new List<Cell>()));

        Assert.NotEmpty(boardCollection.Groups);
    }
    
    [Fact]
    public void CanUpdateCellInBoardCollection()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoardCollection(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateCell(0,0, 2);

        Assert.Equal(board.Cells[0][0], cell);
        Assert.Equal(2, board.Cells[0][0].FixedValue);
    }
    
    [Fact]
    public void CanMakeCellInBoardCollectionEmpty()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoardCollection(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateCell(0,0, null);

        Assert.Equal(
            Cell.CellType.Empty,
            board.Cells[0][0].CellState.GetCellType()
        );
    }
    
    [Fact]
    public void CanUpdateHelpValueOfCellInBoardCollection()
    {
        var builder = new BoardBuilder();
        var cell = new Cell(null);
        builder.CreateBoardCollection(1, 1);
        builder.SetCell(0, 0, cell);
        var board = builder.GetBoard();
        
        board.UpdateHelperValue(0,0, 1);

        Assert.Equal(1, board.Cells[0][0].HelperValue);
    }

    private int[][] CreateTestCellsForPrepare(int x, int y)
    {
        var cells = new int[y][];
        for (var i = 0; i < y; i++)
        {
            cells[i] = new int[x];
        }

        cells[0][0] = 1;
        
        return cells;
    }

    private int[][][] CreateSamuraiTestCellsForPrepare(int x, int y)
    {
        var cells = new int[y][];
        for (var i = 0; i < y; i++)
        {
            cells[i] = new int[x];
        }

        var samuraiCells = new int [5][][];
        for (var i = 0; i < 5; i++)
        {
            samuraiCells[i] = cells;
        }

        return samuraiCells;
    }
}