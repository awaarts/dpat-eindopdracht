using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Algorithms;

public class SudokuAlgorithm : ISudokuAlgorithm
{
    public IBoard SolveSudoku(IBoard board, int? maxLength)
    {
        //if it is a collection of boards, we will have to go deeper
        if (typeof(BoardCollection) == board.GetType())
        {
            var maxNumber = board.Boards.Count > 0 ? board.Boards[0].Cells.Length : 0;
            Console.WriteLine(board.Boards.Count);
            for (var i = 0; i > board.Boards.Count; i++)
            {
                board.Boards[i] = SolveSudoku(board.Boards[i], maxNumber);
            }

            return board;
        }
        if (board.GetType() == typeof(Board))
        {
            return SolveBoard((Board)board, maxLength);
        }

        return board;
    }

    private Board SolveBoard(Board board, int? maxNumber)
    {
        return FindCellOnBoard(board, maxNumber ?? board.Cells.Length) ?? board;
    }

    private Board? FindCellOnBoard(Board board, int maxNumber)
    {
        Cell? targetCell = FindEmptyCell(board);

        if (targetCell == null)
        {
            return board;
        }
        
        //try to fill the target cell with 1 - max (Length of cell array is max number), if not possible, return null
        for (var value = 1; value <= maxNumber; value++)
        {
            board.UpdateCell(targetCell.x, targetCell.y, value);
            if (targetCell.CellState.GetCellType() == Cell.CellType.Correct)
            {
                var result = FindCellOnBoard(board, maxNumber);
                if (result != null)
                {
                    return board;
                }
            }
        }

        //reset our attempt
        board.UpdateCell(targetCell.x, targetCell.y, null);
        return null;
    }

    private Cell? FindEmptyCell(IBoard board)
    {
        for (var y = 0; y < board.Cells.Length; y++)
        {
            for (var x = 0; x < board.Cells[y].Length; x++)
            {
                Cell cell = board.Cells[y][x];
                if (cell == null)
                {
                    break;
                }
                if (cell.CellState.GetCellType() == Cell.CellType.Empty)
                {
                    return board.Cells[y][x];
                }
            }
        }

        return null;
    }
}