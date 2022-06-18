using DPAT_eindopdracht.Application.Algorithms;
using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services;

public class SudokuSolverService
{
    private ISudokuAlgorithm algorithm;

    public SudokuSolverService(ISudokuAlgorithm algorithm)
    {
        this.algorithm = algorithm;
    }

    public IBoard SolveSudoku(IBoard board)
    {
        return algorithm.SolveSudoku(board, null);
    }
}