namespace DPAT_eindopdracht.Services.SudokuImporters;

public interface ISudokuImportService
{
    public Board LoadSudoku(string fileLoc);
}