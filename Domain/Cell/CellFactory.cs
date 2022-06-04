using DPAT_eindopdracht.Domain.Cell.State;

namespace DPAT_eindopdracht.Domain.Cell;

public class CellFactory
{
    //String defines the state of the cell
    private Dictionary<string, Cell> cellTypes;

    public CellFactory()
    {
        Cell emptyCell = new Cell(null);
        emptyCell.SetState("empty");
        Cell incorrectCell = new Cell(null);
        incorrectCell.SetState("incorrect");
        Cell correctCell = new Cell(null);
        correctCell.SetState("correct");
        
        cellTypes = new Dictionary<string, Cell>()
        {
            {"empty", emptyCell},
            {"incorrect", incorrectCell},
            {"correct", correctCell}
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