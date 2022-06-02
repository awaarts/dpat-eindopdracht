using DPAT_eindopdracht.Application.Services;
using DPAT_eindopdracht.Domain.Board;
using Microsoft.AspNetCore.Mvc;

namespace DPAT_eindopdracht.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private SudokuSolverService sudokuSolverService;

    public GameController(SudokuSolverService sudokuSolverService)
    {
        this.sudokuSolverService = sudokuSolverService;
    }
    
    [HttpGet]
    public IBoard LoadGame(FileStream file)
    {
        //TODO: implement loadGame
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public IBoard SolveSudoku(IBoard board)
    {
        return sudokuSolverService.SolveSudoku(board);
    }
    
    [HttpGet]
    public IBoard CheckSudoku(IBoard board)
    {
        IBoard oldBoard = board;
        IBoard correctBoard = sudokuSolverService.SolveSudoku(board);
        
        //TODO: compare two boards and update the given cells to either correct or incorrect states
        throw new NotImplementedException();
    }
}