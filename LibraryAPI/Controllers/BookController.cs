using Microsoft.AspNetCore.Mvc;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

/// <summary>
/// Controller for all the API calls related to the Book table.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BookController: ControllerBase{

    /// <summary>
    /// Database context for the API.
    /// </summary>
    private readonly AppDbContext dbContext;

    /// <summary>
    /// Constructor for the LoanController.
    /// </summary>
    /// <param name="context">The database context.</param>
    public BookController(AppDbContext context){
        dbContext=context;
    }

    /// <summary>
    /// Delete a book from the database by ID.
    /// </summary>
    /// <param name="id">The id of the book.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpDelete("DeleteBook")]
    public async Task<IResult> DeleteBook(string id)
    {
        try{
            if (await dbContext.Books.FindAsync(id) is Book book)
            {
                dbContext.Books.Remove(book);
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
    /// Get a book from the database by ID.
    /// </summary>
    /// <param name="id">The id of the book.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpGet("GetBook")]
    public async Task<IResult> GetBook(string id)
    {
        try{
            return await dbContext.Books.FindAsync(id) is Book book ? Results.Ok(book) : Results.NotFound();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Update a book from the database by ID.
    /// </summary>
    /// <param name="id">The id of the book.</param>
    /// <param name="inputBook">The new data of the entry.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpPut("UpdateBook")]
    public async Task<IResult> UpdateBook(string id, Book inputBook)
    {
        try{
            var book = await dbContext.Books.FindAsync(id);

            if (book is null) return Results.NotFound();

            book.Title = inputBook.Title;
            book.AuthorId = inputBook.AuthorId;
            book.PublicationDate = inputBook.PublicationDate;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
            
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Add a book from the database.
    /// </summary>
    /// <param name="book">The book to add.</param>
    /// <returns>The result of the query from the database.</returns>
    [HttpPost("AddBook")]
    public async Task<IResult> AddBook(Book book)
    {
        try{
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/BookItems/{book.Id}", book);
        }  catch(Exception e)
        {
            throw new Exception(e.Message);
        }  
    }
}