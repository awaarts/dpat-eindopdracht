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
    private IBoard _board;

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
            _board = board;
            return board;
        }
        
        return null;
    }

    [HttpGet]
    public IBoard LoadGame()
    {
        return this._board; 
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
    
    [HttpPost, Route("board/check")]
    public IBoard CheckSudoku(IBoard board)
    {
        IBoard oldBoard = board;
        IBoard correctBoard = _sudokuSolverService.SolveSudoku(board);
        
        //TODO: compare two boards and update the given cells to either correct or incorrect states
        throw new NotImplementedException();
    }

    [HttpPost, Route("cell")]
    public Cell? UpdateCell([FromBody] Cell cell)
    {
        // return cell;
        return cell;
    }
}