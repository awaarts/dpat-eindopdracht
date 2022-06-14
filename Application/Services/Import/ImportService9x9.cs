using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportService9X9 : IImportService
{
    private BoardBuilder _boardBuilder;

    public ImportService9X9(BoardBuilder boardBuilder)
    {
        _boardBuilder = boardBuilder;
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        int[][] cells = new int[9][];

        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        while (reader.ReadLine() is { } numbers)
        {
            for (var y = 0; y < 9; y++)
            {
                cells[y] = new int[9];
                for (int x = 0; x < 9; x++)
                {
                    try
                    {
                        cells[y][x] =
                            Int32.Parse(
                                numbers.Substring(y * 9 + x, 1)
                            );
                    }
                    catch
                    {
                        cells[y][x] = 0;
                    }
                }
            }
        }
        _boardBuilder.Prepare9X9(cells);

        return _boardBuilder.GetBoard();
    }
}