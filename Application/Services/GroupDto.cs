namespace DPAT_eindopdracht.Application.Services;

public class GroupDto
{
    private GroupCellDto[] _cells;

    public GroupDto(int amount)
    {
        _cells = new GroupCellDto[amount];
    }

    public void AddCell(GroupCellDto cell)
    {
        _cells.Append(cell);
    }

}