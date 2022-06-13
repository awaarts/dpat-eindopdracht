namespace DPAT_eindopdracht.Domain.Validation;

public interface IValidator
{
    public bool Validate(List<Cell.Cell> cells);
}