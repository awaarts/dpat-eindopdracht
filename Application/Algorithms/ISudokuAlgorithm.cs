using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Algorithms;

public interface ISudokuAlgorithm
{
    public IBoard SolveSudoku(IBoard board);
}