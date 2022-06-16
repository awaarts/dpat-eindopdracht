namespace DPAT_eindopdracht.Domain.Group;

public class GroupFactory
{
    private readonly Dictionary<Group.GroupTypes, Type> _groupTypes;

    public GroupFactory()
    {
        _groupTypes = new Dictionary<Group.GroupTypes, Type>();
    }

    public void AddGroupType(Type type, Group.GroupTypes groupType)
    {
        _groupTypes[groupType] = type;
    }

    public Group? CreateGroup(Group.GroupTypes groupType, List<Cell.Cell> cells, string type)
    {
        var groupValidator = _groupTypes[groupType];
        var group = (Group?) Activator.CreateInstance(groupValidator, cells);
        if (group != null)
        {
            group.Type = type;
        }
        return group;
    }
}