using DPAT_eindopdracht.Domain.Cell.State;

namespace DPAT_eindopdracht.Domain.Cell;

public class CellFactory
{
    //String defines the state of the cell
    private Dictionary<string, Cell> cellTypes;

    public CellFactory()
    {

        cellTypes = new Dictionary<string, Cell>();
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