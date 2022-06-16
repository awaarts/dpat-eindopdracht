using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Algorithms;

public class SudokuAlgorithm : ISudokuAlgorithm
{
    public IBoard SolveSudoku(IBoard board)
    {
        //if it is a collection of boards, we will have to go deeper
        if (typeof(BoardCollection) == board.GetType())
        {
            //TODO: handle samurai
            return board;
        }
        if (board.GetType() == typeof(Board))
        {
            return SolveBoard((Board) board);
        }

        return board;
    }

    private Board SolveBoard(Board board)
    {
        return FindCellOnBoard(board) ?? board;
    }

    private Board? FindCellOnBoard(Board board)
    {
        Cell? targetCell = FindEmptyCell(board);

        if (targetCell == null)
        {
            return board;
        }
        
        //try to fill the target cell with 1 - max (Length of cell array is max number), if not possible, return null
        for (var value = 1; value <= board.Cells.Length; value++)
        {
            board.UpdateCell(targetCell.x, targetCell.y, value);
            if (targetCell.CellState.GetCellType() == Cell.CellType.Correct)
            {
                var result = FindCellOnBoard(board);
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
                if (board.Cells[y][x].CellState.GetCellType() == Cell.CellType.Empty)
                {
                    return board.Cells[y][x];
                }
            }
        }

        return null;
    }
}