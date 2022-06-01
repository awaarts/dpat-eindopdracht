namespace DPAT_eindopdracht.Services.SudokuImporters;

public class SudokuImportService4x4 : ISudokuImportService
{
    public Board LoadSudoku(string fileLoc)
    {
        string text = System.IO.File.ReadAllText(@fileLoc);
        Console.WriteLine(text);
        return new Board();
    }
}