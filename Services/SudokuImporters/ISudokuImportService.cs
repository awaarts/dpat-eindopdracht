namespace DPAT_eindopdracht.Services.SudokuImporters;

public interface ISudokuImportService
{
    public Board loadSudoku(string file);
}