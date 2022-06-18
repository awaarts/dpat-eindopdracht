using DPAT_eindopdracht.Domain.Validation;

namespace DPAT_eindopdracht.Domain.Group;

public class Group
{
    public enum GroupTypes
    {
        Unique
    }
    public List<IValidator> Validators { get; }
    public List<Cell.Cell> Cells { get; }
    
    public string Type { get; set; }

    public Group(List<Cell.Cell> cells)
    {
        Type = "";
        Validators = new List<IValidator>();
        Cells = cells;
    }

    public void AddValidator(IValidator validator)
    {
        if (Validators.All(val => val.GetType() != validator.GetType()))
        {
            Validators.Add(validator);
        }
    }

    public bool Validate()
    {
        return Validators.TrueForAll(validator => validator.Validate(Cells));
    }
}