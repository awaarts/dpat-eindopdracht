using DPAT_eindopdracht.Application.Services;
using DPAT_eindopdracht.Application.Services.Import;
using DPAT_eindopdracht.Domain.Board;
using DPAT_eindopdracht.Domain.Cell;
using Microsoft.AspNetCore.Mvc;

namespace DPAT_eindopdracht.Application.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class GameController : ControllerBase
{
    private BoardBuilder _boardBuilder;
    private SudokuSolverService _sudokuSolverService;
    private ImportService _importService;
    private string[] _acceptedFileExtensions;

    public GameController()
    {
        _boardBuilder = new BoardBuilder();
        _importService = new ImportService(_boardBuilder);
        // this._sudokuSolverService = new SudokuSolverService();
        _acceptedFileExtensions = new[] { ".samurai", ".jigsaw", ".9x9", ".6x6", ".4x4" };
    }
    
    [HttpPost, DisableRequestSizeLimit]
    public IBoard? LoadGame([FromForm]IFormFile file)
    {
        if (file != null && _acceptedFileExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
        {
            return ImportFile(file);
        }
        
        return null;
    }

    private IBoard ImportFile(IFormFile file)
    {
        return _importService.LoadSudoku(file);
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