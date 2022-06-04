using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application.Services.Import;

public interface IImportService
{
    public Board loadSudoku(FileStream file);
}