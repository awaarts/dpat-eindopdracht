using System.Text.Json.Serialization;
using DPAT_eindopdracht.Domain.Cell.State;
using Microsoft.AspNetCore.Components.Server;

namespace DPAT_eindopdracht.Domain.Cell;

public class Cell
{
    public ICellState CellState { get; private set; }
    public int? FixedValue { get; set; }
    public int? HelperValue { get; set; }
    
    //only used to properly initialise model from controller
    public string? jsonState { get; }

    [JsonConstructor]
    public Cell(int? fixedValue, int? helperValue, string? jsonState)
    {
        if (jsonState != null)
        {
            SetState(jsonState);
        }

        if (fixedValue != null)
        {
            FixedValue = fixedValue;
        }

        if (helperValue != null)
        {
            HelperValue = helperValue;
        }
    }
    
    public Cell(ICellState? state)
    {
        if (state != null)
        {
            CellState = state;
        }
        else
        {
            CellState = new EmptyCellState(this);
        }
    }
    public Cell Clone()
    {
        Cell clone = new Cell(null);
        clone.SetState(CellState.ToString());
        return clone;
    }

    public void SetState(string state)
    {
        CellState = state switch
        {
            "empty" => new EmptyCellState(this),
            "correct" => new CorrectCellState(this),
            "incorrect" => new IncorrectCellState(this),
            _ => CellState
        };
    }

    public void SetFixedValue(int? value)
    {
        CellState.SetFixedValue(value);
        //set value through state, as this will allow us to check if we are not overriding correct values
    }

    public void SetHelperValue(int? value)
    {
        CellState.SetHelperValue(value);
    }
    
}