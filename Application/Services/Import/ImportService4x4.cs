using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportService4X4 : MainImportService{
    public override Cell[][] LoadSudoku(IFormFile file)
    {
        Cell[][] cells = InitialiseCells(4, 4);
        
        using var fileStream = file.OpenReadStream();
        using var reader = new StreamReader(fileStream);
        while (reader.ReadLine() is { } numbers)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    try
                    {
                        cells[x][y] = CreateCell(
                            Int32.Parse(
                                numbers.Substring(y * 4 + x, 1)
                                )
                            );
                    }
                    catch
                    {
                        cells[x][y] = CreateCell(0);
                    }
                }
            }
        }

        return cells;
    }

}