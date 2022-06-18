using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Validation;
using Xunit;
using System.Collections.Generic;

namespace DPAT_eindopdracht.test.Domain;

public class ValidationTest
{
    [Fact]
    public void UniqueValidatorCheckCorrect()
    {
        IValidator validator = new UniqueValidator();
        List<Cell> cells = new List<Cell>
        {
            createTestCell(1),
            createTestCell(3),
            createTestCell(9)
        };

        var validationResult = validator.Validate(cells);
        
        Assert.True(validationResult);
    }
    
    [Fact]
    public void UniqueValidatorCheckIncorrect()
    {
        IValidator validator = new UniqueValidator();
        List<Cell> cells = new List<Cell>
        {
            createTestCell(1),
            createTestCell(3),
            createTestCell(9),
            createTestCell(9)
        };

        var validationResult = validator.Validate(cells);
        
        Assert.False(validationResult);
    }

    private Cell createTestCell(int fixedValue)
    {
        Cell cell = new Cell(null);
        cell.SetState(Cell.CellType.Empty);
        cell.FixedValue = fixedValue;

        return cell;
    }
}