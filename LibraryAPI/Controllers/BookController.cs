using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryExercise.Models;

namespace LibraryExercise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController: ControllerBase{
    private readonly AppDbContext dbContext;

    public BookController(AppDbContext context){
        dbContext=context;
    }

    [HttpDelete("DeleteBook")]
    public async Task<IResult> DeleteBook(string id, AppDbContext db)
    {
        try{
            if (await db.Books.FindAsync(id) is Book book)
            {
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }      
        }  catch(Exception e)
        {
            throw new Exception(e.Message);
        }  

        return Results.NotFound();
    }

    [HttpGet("GetBook")]
    public async Task<IResult> GetBook(string id, AppDbContext db)
    {
        try{
            return await db.Books.FindAsync(id) is Book book ? Results.Ok(book) : Results.NotFound();
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPut("UpdateBook")]
    public async Task<IResult> UpdateBook(string id, AppDbContext db, Book inputBook)
    {
        try{
            var book = await db.Books.FindAsync(id);

            if (book is null) return Results.NotFound();

            book.Title = inputBook.Title;
            book.AuthorId = inputBook.AuthorId;
            book.PublicationDate = inputBook.PublicationDate;

            await db.SaveChangesAsync();

            return Results.NoContent();
            
        } catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost("AddBook")]
    public async Task<IResult> AddBook(Book book, AppDbContext db)
    {
        try{
            db.Books.Add(book);
            await db.SaveChangesAsync();

            return Results.Created($"/BookItems/{book.Id}", book);
        }  catch(Exception e)
        {
            throw new Exception(e.Message);
        }  
    }
}