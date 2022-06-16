using DPAT_eindopdracht.Application.Services;
using DPAT_eindopdracht.Application.Services.Import;
using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DPAT_eindopdracht.Application.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class GameController : ControllerBase
{
    private BoardBuilder _boardBuilder;
    private SudokuSolverService _sudokuSolverService;
    private ImportService _importService;
    private BoardJsonService _boardJsonService;
    private string[] _acceptedFileExtensions;

    public GameController()
    {
        _boardBuilder = new BoardBuilder();
        _boardJsonService = new BoardJsonService();
        _importService = new ImportService(_boardBuilder);
        // this._sudokuSolverService = new SudokuSolverService();
        _acceptedFileExtensions = new[] { ".samurai", ".jigsaw", ".9x9", ".6x6", ".4x4" };
    }
    
    [HttpPost, DisableRequestSizeLimit,  Route("new")]
    public IBoard? NewGame([FromForm]IFormFile file)
    {
        if (file != null && _acceptedFileExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
        {
            IBoard board = ImportFile(file);
            BoardRepository.SetBoard(board);
            return board;
        }
        
        return null;
    }

    [HttpGet]
    public IBoard LoadGame()
    {
        return BoardRepository.GetBoard();
    }

    private IBoard ImportFile(IFormFile file)
    {
        IBoard board = _importService.LoadSudoku(file);
        return board;
    }
    
    [HttpPost, Route("board/solve")]
    public IBoard SolveSudoku(IBoard board)
    {
        return _sudokuSolverService.SolveSudoku(board);
    }
    
    [HttpGet, Route("board/check")]
    public bool CheckSudoku()
    {
        return BoardRepository.GetBoard().Validate();
    }

    [HttpPost, Route("cell")]
    public IBoard UpdateCell(int x, int y, int newValue)
    {
        IBoard board = BoardRepository.GetBoard();
        
        board.UpdateCell(x,y,newValue);
        BoardRepository.SetBoard(board);

        return board;
    }
}