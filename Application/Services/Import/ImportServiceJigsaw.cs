using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportServiceJigsaw : IImportService
{
    private BoardBuilder _boardBuilder;

    public ImportServiceJigsaw(BoardBuilder boardBuilder)
    {
        _boardBuilder = boardBuilder;
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        string text = reader.ReadToEnd();
        text = text.Split("V1=")[1];

        int[][] cells = new int[9][];
        int[][] regions = new int[9][];
        String[] cellStrings = text.Split('=');
        for (var y = 0; y < 9; y++)
        {
            cells[y] = new int[9];
            regions[y] = new int[9];
            for (int x = 0; x < 9; x++)
            {
                try
                {
                    cells[y][x] = int.Parse(cellStrings[y * 9 + x].Substring(0,1));
                    regions[y][x] = int.Parse(cellStrings[y * 9 + x].Substring(2,1));
                }
                catch
                {
                    cells[y][x] = 0;
                }
            }
        }

        _boardBuilder.PrepareJigsaw(cells, regions);
        return _boardBuilder.GetBoard();
    }
}