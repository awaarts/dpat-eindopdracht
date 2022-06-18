using System.Collections.Generic;
using DPAT_eindopdracht.Application.Algorithms;
using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;
using Xunit;

namespace DPAT_eindopdracht.DPAT_eindopdracht.test.Application.Algorithm;

public class AlgorithmTest
{
    [Fact]
    public void CanSolveSudokuWithAlgorithm()
    {
        var board = CreateTestBoard();
        var algorithm = new SudokuAlgorithm();

        var solvedBoard = algorithm.SolveSudoku(board, null);

        Assert.Equal(2, solvedBoard.Cells[0][0].FixedValue);
    }

    private IBoard CreateTestBoard()
    {
        var testInput = new int[2][];
        for (var i = 0; i < 2; i++)
        {
            testInput[i] = new int[1];
        }
        testInput[1][0] = 1;

        var boardBuilder = new BoardBuilder();
        boardBuilder.CreateBoard(1, 2);
        boardBuilder.CreateCells(testInput);
        var temp = boardBuilder.GetBoard();
        boardBuilder.AddGroup(Group.GroupTypes.Unique, new List<Cell>{temp.Cells[0][0], temp.Cells[1][0]}, "unique");
        return boardBuilder.GetBoard();
    }
}