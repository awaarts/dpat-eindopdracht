using DPAT_eindopdracht.Domain.Cell.State;

namespace DPAT_eindopdracht.Domain.Cell;

public class CellFactory
{
    //String defines the state of the cell
    private Dictionary<string, Cell> cellTypes;

    public CellFactory()
    {
        Cell emptyCell = new Cell(null);
        emptyCell.SetState(Cell.CellType.Empty);
        Cell incorrectCell = new Cell(null);
        incorrectCell.SetState(Cell.CellType.Incorrect);
        Cell correctCell = new Cell(null);
        correctCell.SetState(Cell.CellType.Correct);
        Cell initialValueCell = new Cell(null);
        initialValueCell.SetState(Cell.CellType.Initial);
        
        cellTypes = new Dictionary<string, Cell>()
        {
            {"empty", emptyCell},
            {"incorrect", incorrectCell},
            {"correct", correctCell},
            {"initial", initialValueCell}
        };
    }

    public void RegisterCell(string name, Cell cell)
    {
        cellTypes[name] = cell;
    }

    public Cell CreateCell(string state)
    {
        Cell prototype = cellTypes[state];
        return prototype.Clone();
    }
}