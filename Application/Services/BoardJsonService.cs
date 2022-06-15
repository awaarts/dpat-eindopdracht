using System.Text.Json.Serialization;
using System.Threading.Tasks.Dataflow;
using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;
using Newtonsoft.Json;

namespace DPAT_eindopdracht.Application.Services;

public class BoardJsonService
{
    public string getBoardJson(IBoard board)
    {
        List<GroupDto> regions = new List<GroupDto>();

        foreach (Group group in board.Groups)
        {
            GroupDto newGroup = new GroupDto(board.Groups.Count);
            int x = 0;
            foreach (Cell[] row in board.Cells)
            {
                x++;
                int y = 0;
                foreach (Cell cell in row)
                {
                    y++;
                    foreach (Cell cell2 in group.cells)
                    {
                        if (cell == cell2)
                        {
                            newGroup.AddCell(new GroupCellDto(x, y));
                        }
                    }
                }
            }
            regions.Append(newGroup);
        }

        return JsonConvert.SerializeObject(regions);
    }
}