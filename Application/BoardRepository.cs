using System.Xml.Serialization;
using DPAT_eindopdracht.Domain.Board;

namespace DPAT_eindopdracht.Application;

public static class BoardRepository
{
    private static IBoard _board;

    public static void SetBoard(IBoard board)
    {
        _board = board;
    }

    public static IBoard GetBoard()
    {
        return _board;
    }
    
    
}