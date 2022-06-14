using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportService4X4 : IImportService
{
    private BoardBuilder _boardBuilder;

    public ImportService4X4(BoardBuilder boardBuilder)
    {
        _boardBuilder = boardBuilder;
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        int[][] cells = new int[4][];

        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        while (reader.ReadLine() is { } numbers)
        {
            for (var y = 0; y < 4; y++)
            {
                cells[y] = new int[4];
                for (int x = 0; x < 4; x++)
                {
                    try
                    {
                        cells[y][x] =
                            Int32.Parse(
                                numbers.Substring(y * 4 + x, 1)
                            );
                    }
                    catch
                    {
                        cells[y][x] = 0;
                    }
                }
            }
        }
        _boardBuilder.Prepare4X4(cells);

        return _boardBuilder.GetBoard();
    }
}