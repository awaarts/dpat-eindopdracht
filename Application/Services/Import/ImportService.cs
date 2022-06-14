using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public class ImportService
{
    private Dictionary<string, IImportService> importServices;

    public ImportService(BoardBuilder boardBuilder)
    {
        importServices = new Dictionary<string, IImportService>
        {
            { ".4x4", new ImportService4X4(boardBuilder) },
            { ".6x6", new ImportService6X6(boardBuilder) },
            { ".9x9", new ImportService9X9(boardBuilder) }
        };
    }

    public IBoard LoadSudoku(IFormFile file)
    {
        return importServices[Path.GetExtension(file.FileName).ToLower()].LoadSudoku(file);
    }
}