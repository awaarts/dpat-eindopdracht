using DPAT_eindopdracht.Domain.Validation;

namespace DPAT_eindopdracht.Domain.Group;

public class UniqueGroup : Group
{
    public UniqueGroup(List<Cell.Cell> cells) : base(cells)
    {
        AddValidator(new UniqueValidator());
    }
}