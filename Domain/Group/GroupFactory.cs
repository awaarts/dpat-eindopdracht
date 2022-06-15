namespace DPAT_eindopdracht.Domain.Group;

public class GroupFactory
{
    private Dictionary<string, Type> _groupTypes;

    public GroupFactory()
    {
        _groupTypes = new Dictionary<string, Type>();
    }

    public void AddGroupType(Type groupType, string typeName)
    {
        _groupTypes[typeName] = groupType;
    }

    public Group CreateGroup(string validator, List<Cell.Cell> cells, string type)
    {
        Type groupValidator = _groupTypes[validator];
        Group? group = (Group?) Activator.CreateInstance(groupValidator, cells);
        group.type = type;
        return group ?? new Group(cells);
    }
}