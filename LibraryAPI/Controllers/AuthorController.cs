using Microsoft.AspNetCore.Mvc;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

/// <summary>
/// Controller for all the API calls related to the Author table.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthorController: ControllerBase{

    /// <summary>
    /// Database context for the API.
    /// </summary>
    private readonly AppDbContext dbContext;

    /// <summary>
    /// Constructor for the LoanController.
    /// </summary>
    /// <param name="context">The database context.</param>
    public AuthorController(AppDbContext context){
        dbContext=context;
    }

    /// <summary>
    /// Delete a author from the database by ID.
    /// </summary>
    /// <param name="id">The id of the author.</param>
    /// <returns>The result of the query from the database.</returns>
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

    /// <summary>
    /// Get a author from the database by ID.
    /// </summary>
    /// <param name="id">The id of the author.</param>
    /// <returns>The result of the query from the database.</returns>
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

    /// <summary>
    /// Update a author from the database by ID.
    /// </summary>
    /// <param name="id">The id of the author.</param>
    /// <param name="inputAuthor">The new data of the entry.</param>
    /// <returns>The result of the query from the database.</returns>
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

    /// <summary>
    /// Add a author from the database.
    /// </summary>
    /// <param name="author">The author to add.</param>
    /// <returns>The result of the query from the database.</returns>
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