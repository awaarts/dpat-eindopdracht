using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportService6X6 : IImportService
{
    private BoardBuilder _boardBuilder;

    public ImportService6X6(BoardBuilder boardBuilder)
    {
        _boardBuilder = boardBuilder;
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        int[][] cells = new int[6][];

        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        while (reader.ReadLine() is { } numbers)
        {
            for (var y = 0; y < 6; y++)
            {
                cells[y] = new int[6];
                for (int x = 0; x < 6; x++)
                {
                    try
                    {
                        cells[y][x] =
                            Int32.Parse(
                                numbers.Substring(y * 6 + x, 1)
                            );
                    }
                    catch
                    {
                        cells[y][x] = 0;
                    }
                }
            }
        }
        _boardBuilder.Prepare6X6(cells);

        return _boardBuilder.GetBoard();
    }
}