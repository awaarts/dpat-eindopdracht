using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Services.SudokuImporters;

public class SudokuImportService4x4 : ISudokuImportService
{
    public Board LoadSudoku(string fileLoc)
    {
        string text = System.IO.File.ReadAllText(@fileLoc);
        return new Board();
    }
}