using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoanController: ControllerBase{
    private readonly AppDbContext dbContext;

    public LoanController(AppDbContext context){
        dbContext=context;
    }

    [HttpGet("GetLoan")]
    public async Task<IResult> GetLoan(int id, AppDbContext db)
    {
        try{
            return await db.Loans.FindAsync(id) is Loan loan ? Results.Ok(loan) : Results.NotFound();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    [HttpPost("AddLoan")]
    public async Task<IResult> AddLoan(Loan loan, AppDbContext db)
    {
        try{

            if(loan.LoanDate .CompareTo(loan.ReturnDate) > 0) throw new InvalidOperationException();

            db.Loans.Add(loan);
            await db.SaveChangesAsync();

            return Results.Created($"/LoanItems/{loan.Id}", loan);
        }  catch(InvalidOperationException e){
            throw new Exception("The date of the loan cannot be superior than the date of return.");
        }  catch(Exception e){
            throw new Exception(e.Message);
        }  
    }
}