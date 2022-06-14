using DPAT_eindopdracht.Domain.Validation;
using DPAT_eindopdracht.Domain.Cell;

namespace DPAT_eindopdracht.Domain.Group;

public class Group
{
    public List<IValidator> validators { get; }
    public List<Cell.Cell> cells { get; }

    public Group(List<Cell.Cell> cells)
    {
        validators = new List<IValidator>();
        this.cells = cells;
    }

    protected void AddValidator(IValidator validator)
    {
        if (validators.All(val => val.GetType() != validator.GetType()))
        {
            validators.Add(validator);
        }
    }

    public bool Validate()
    {
        return validators.TrueForAll(validator => validator.Validate(cells));
    }
}