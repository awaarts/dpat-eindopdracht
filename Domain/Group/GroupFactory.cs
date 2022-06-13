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

    public Group CreateGroup(string type, List<Cell.Cell> cells)
    {
        Type groupType = _groupTypes[type];
        Group? group = (Group?) Activator.CreateInstance(groupType, cells);
        return group ?? new Group(cells);
    }
}