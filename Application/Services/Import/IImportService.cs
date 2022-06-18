using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Services.Import;

public interface IImportService
{
    public IBoard LoadSudoku(IFormFile file);
}