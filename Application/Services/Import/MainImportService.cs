using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Application.Services.Import;

public class MainImportService : IImportService
{
    private CellFactory _cellFactory = new CellFactory();
    public virtual Cell[][] LoadSudoku(IFormFile file)
    {
        throw new NotImplementedException();
    }
    
    protected Cell[][] InitialiseCells(int xsize, int ysize)
    {
        Cell[][] cells = new Cell[xsize][];

        for (int x = 0; x < xsize; x++)
        {
            cells[x] = new Cell[ysize];
        }

        return cells;
    }

    protected Cell CreateCell(int fixedValue)
    {
        Cell cell = _cellFactory.CreateCell(fixedValue == 0 ? "empty" : "correct");
        if (fixedValue > 0)
        {
            cell.SetFixedValue(fixedValue);
        }

        return cell;
    }
}