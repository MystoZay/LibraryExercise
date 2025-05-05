using Microsoft.AspNetCore.Mvc;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

/// <summary>
/// Controller for all the API calls related to the Loan table.
/// </summary>s
[Route("api/[controller]")]
[ApiController]
public class LoanController: ControllerBase{

    /// <summary>
    /// Database context for the API.
    /// </summary>
    private readonly AppDbContext dbContext;

    /// <summary>
    /// Constructor for the LoanController.
    /// </summary>
    /// <param name="context">The database context.</param>
    public LoanController(AppDbContext context){
        dbContext=context;
    }

    /// <summary>
    /// Get a loan from the database by ID.
    /// </summary>
    /// <param name="id">The id of the loan.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpGet("GetLoan")]
    public async Task<IResult> GetLoan(int id)
    {
        try{
            return await dbContext.Loans.FindAsync(id) is Loan loan ? Results.Ok(loan) : Results.NotFound();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Add a loan to the database.
    /// </summary>
    /// <param name="loan">The loan to add.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpPost("AddLoan")]
    public async Task<IResult> AddLoan(Loan loan)
    {
        try{

            if(loan.LoanDate .CompareTo(loan.ReturnDate) > 0) throw new InvalidOperationException();

            dbContext.Loans.Add(loan);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/LoanItems/{loan.Id}", loan);
        }  catch(InvalidOperationException e){
            throw new Exception("The date of the loan cannot be superior than the date of return.");
        }  catch(Exception e){
            throw new Exception(e.Message);
        }  
    }
}