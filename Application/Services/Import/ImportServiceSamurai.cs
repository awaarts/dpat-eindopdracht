using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportServiceSamurai : IImportService
{
    private BoardBuilder _boardBuilder;

    public ImportServiceSamurai(BoardBuilder boardBuilder)
    {
        _boardBuilder = boardBuilder;
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        string[] lines = reader.ReadToEnd().Split("\r\n");
        int[][][] boardCells = new int[5][][];
        for (var i = 0; i < 5; i++)
        {
            
            int[][] cells = new int[9][];
            for (var y = 0; y < 9; y++)
            {
                cells[y] = new int[9];
                string line = lines[i];
                for (int x = 0; x < 9; x++)
                {
                    try
                    {
                        cells[x][y]=Int32.Parse(
                            line.Substring(y * 9 + x, 1)
                        );
                    }
                    catch
                    {
                        cells[y][x] = 0;
                    }
                }
            }

            boardCells[i] = cells;
        }

        _boardBuilder.prepareSamurai(boardCells);
        return _boardBuilder.GetBoard();
    }
}