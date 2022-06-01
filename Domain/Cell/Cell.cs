using DPAT_eindopdracht.Domain.Cell.State;
using Microsoft.AspNetCore.Components.Server;

namespace DPAT_eindopdracht.Domain.Cell;

public class Cell : ICloneable
{
    public ICellState CellState { get; private set; }
    public int? FixedValue { get; set; }
    public int HelperValue { get; set; }
    
    //TODO: create cellstates according to design pattern
    // private CellState currentState = new Empty ()
    public object Clone()
    {
        throw new NotImplementedException();
    }

    public void SetState(string state)
    {
        switch(state)
        {
            case "empty":
                CellState = new EmptyCellState(this);
                break;
            case "correct":
                CellState = new CorrectCellState(this);
                break;
            case "incorrect":
                CellState = new IncorrectCellState(this);
                break;
        }
    }

    public void SetFixedValue(int value)
    {
        //set value through state, as this will allow us to check if we are not overriding correct values
    }
    
    
}