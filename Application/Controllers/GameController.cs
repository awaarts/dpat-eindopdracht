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
    private SudokuSolverService _sudokuSolverService;
    private Dictionary<string, IImportService> _importServices;
    private string[] _acceptedFileExtensions;
    private BoardBuilder _boardBuilder;

    public GameController()
    {
        _boardBuilder = new BoardBuilder();
        // this._sudokuSolverService = new SudokuSolverService();
        _acceptedFileExtensions = new[] { ".samurai", ".jigsaw", ".9x9", ".6x6", ".4x4" };
        SetupImportServices();
    }

    private void SetupImportServices()
    {
        this._importServices = new Dictionary<string, IImportService>()
        {
            {".4x4", new ImportService4X4()} 
        };
    }
    
    [HttpPost, Microsoft.AspNetCore.Mvc.Route("board"), DisableRequestSizeLimit]
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
        _boardBuilder.CreateBoard();
        
        var cells = _importServices[Path.GetExtension(file.FileName).ToLower()].LoadSudoku(file);
        switch (Path.GetExtension(file.FileName).ToLower())
        {
            case ".4x4":
                _boardBuilder.Prepare4X4(cells);
                break;
        }
        return _boardBuilder.GetBoard();
    }
    
    public IBoard SolveSudoku(IBoard board)
    {
        return _sudokuSolverService.SolveSudoku(board);
    }
    
    public IBoard CheckSudoku(IBoard board)
    {
        IBoard oldBoard = board;
        IBoard correctBoard = _sudokuSolverService.SolveSudoku(board);
        
        //TODO: compare two boards and update the given cells to either correct or incorrect states
        throw new NotImplementedException();
    }

    public Cell UpdateCell(Cell cell)
    {
        return cell;
    }
}