using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController: ControllerBase{
    private readonly AppDbContext dbContext;

    public AuthorController(AppDbContext context){
        dbContext=context;
    }

    [HttpDelete("DeleteAuthor")]
    public async Task<IResult> DeleteAuthor(int id)
    {
        try{
            if (await dbContext.Authors.FindAsync(id) is Author author)
            {
                dbContext.Authors.Remove(author);
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            }      
        }  catch(Exception e)
        {
            throw new Exception(e.Message);
        }  

        return Results.NotFound();
    }

    [HttpGet("GetAuthor")]
    public async Task<IResult> GetAuthor(int id)
    {
        try{
            return await dbContext.Authors.FindAsync(id) is Author author ? Results.Ok(author) : Results.NotFound();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPut("UpdateAuthor")]
    public async Task<IResult> UpdateAuthor(int id, Author inputAuthor)
    {
        try{
            var author = await dbContext.Authors.FindAsync(id);

            if (author is null) return Results.NotFound();

            author.Name = inputAuthor.Name;
            author.FamilyName = inputAuthor.FamilyName;
            author.DateOfBirth = inputAuthor.DateOfBirth;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
            
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost("AddAuthor")]
    public async Task<IResult> AddAuthor(Author author)
        {
            try{
                dbContext.Authors.Add(author);
                await dbContext.SaveChangesAsync();

                return Results.Created($"/AuthorItems/{author.Id}", author);
            }  catch(Exception e){
                throw new Exception(e.Message);
            }  
        }
}