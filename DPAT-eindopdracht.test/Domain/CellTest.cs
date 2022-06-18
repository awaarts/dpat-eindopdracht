using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Cell.State;
using NSubstitute;
using Xunit;

namespace DPAT_eindopdracht.test.Domain;

public class CellTest
{
    [Fact]
    public void CanGetSetEmptyCellFixedValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);

        cell.SetFixedValue(1);
        var result = cell.FixedValue;
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public void CanGetSetEmptyCellHelperValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);

        cell.SetHelperValue(1);
        var result = cell.HelperValue;
        
        Assert.NotNull(result);
    }
    
    [Fact]
    public void CanGetSetEmptyCellX()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);

        cell.x = 1;
        
        Assert.Equal(1, cell.x);
    }
    
    [Fact]
    public void CanGetSetEmptyCellY()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);

        cell.y = 1;
        
        Assert.Equal(1, cell.y);
    }
    
    
    [Fact]
    public void CanCloneEmptyCell()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);

        var clone = cell.Clone();
        
        Assert.NotEqual(clone, cell);
    }
    
    
    [Fact]
    public void CanSetCellStateCorrect()
    {
        var cell = new Cell(null);
        
        cell.SetState(Cell.CellType.Correct);

        Assert.Equal(typeof(CorrectCellState), cell.CellState.GetType());
    }
    
    [Fact]
    public void CanSetCellStateIncorrect()
    {
        var cell = new Cell(null);
        
        cell.SetState(Cell.CellType.Incorrect);

        Assert.Equal(typeof(IncorrectCellState), cell.CellState.GetType());
    }
    
    [Fact]
    public void CanSetCellStateInitial()
    {
        var cell = new Cell(null);
        
        cell.SetState(Cell.CellType.Initial);

        Assert.Equal(typeof(InitialValueCellState), cell.CellState.GetType());
    }
    
    
    [Fact]
    public void FactoryCanCreateCell()
    {
        var factory = new CellFactory();

        factory.RegisterCell("cell", new Cell(null));
        var result = factory.CreateCell("cell");

        Assert.IsType<Cell>(result);
    }
    
    [Fact]
    public void CanGetEmptyCellState()
    {
        var cell = new Cell(null);
        
        cell.SetState(Cell.CellType.Empty);
        var result = cell.CellState.state;

        Assert.Equal("empty", result);
    }
    
    [Fact]
    public void CanGetCorrectCellState()
    {
        var cell = new Cell(null);
        
        cell.SetState(Cell.CellType.Correct);
        var result = cell.CellState.state;

        Assert.Equal("correct", result);
    }

    [Fact]
    public void CanGetIncorrectCellState()
    {
        var cell = new Cell(null);

        cell.SetState(Cell.CellType.Incorrect);
        var result = cell.CellState.state;

        Assert.Equal("incorrect", result);
    }
    
    [Fact]
    public void CanGetInitialCellState()
    {
        var cell = new Cell(null);

        cell.SetState(Cell.CellType.Initial);
        var result = cell.CellState.state;

        Assert.Equal("initial", result);
    }
    
    [Fact]
    public void CanGetCorrectCellType()
    {
        var cell = new Cell(null);

        cell.SetState(Cell.CellType.Correct);
        var result = cell.CellState.GetCellType();

        Assert.IsType<Cell.CellType>(result);
    }
    
    [Fact]
    public void CanGetIncorrectCellType()
    {
        var cell = new Cell(null);

        cell.SetState(Cell.CellType.Incorrect);
        var result = cell.CellState.GetCellType();

        Assert.IsType<Cell.CellType>(result);
    }
    
    [Fact]
    public void CanGetInitialCellType()
    {
        var cell = new Cell(null);

        cell.SetState(Cell.CellType.Initial);
        var result = cell.CellState.GetCellType();

        Assert.IsType<Cell.CellType>(result);
    }
    
    [Fact]
    public void CanSetCorrectCellFixedValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Correct);

        cell.SetFixedValue(1);
        var result = cell.FixedValue;

        Assert.Equal(1, result);
    }
    
    [Fact]
    public void CanSetIncorrectCellFixedValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Incorrect);

        cell.SetFixedValue(1);
        var result = cell.FixedValue;

        Assert.Null(result);
    }
    
    [Fact]
    public void CanSetInitialCellFixedValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Initial);

        cell.SetFixedValue(1);
        var result = cell.FixedValue;

        Assert.Equal(1, result);
    }
    
    [Fact]
    public void CanSetCorrectCellHelperValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Correct);

        cell.SetHelperValue(1);
        var result = cell.HelperValue;

        Assert.Equal(1, result);
    }
    
    [Fact]
    public void CanSetIncorrectCellHelperValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Incorrect);

        cell.SetHelperValue(1);
        var result = cell.HelperValue;

        Assert.Equal(1, result);
    }
    
    [Fact]
    public void CanSetInitialCellHelperValue()
    {
        var cell = new Cell(null);
        cell.SetState(Cell.CellType.Initial);

        cell.SetHelperValue(1);
        var result = cell.HelperValue;

        Assert.Equal(1, result);
    }
}