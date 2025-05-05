namespace LibraryExercise.Models;

/// <summary>
/// Model for the Book.
/// </summary>
public class Book{
    /// <summary>
    /// Gets/sets the ID of the book.
    /// </summary>
    public string Id {get; set;}

    /// <summary>
    /// Gets/sets the title of the book.
    /// </summary>
    public string Title {get; set;}

    /// <summary>
    /// Gets/sets the ID of the author of the book.
    /// </summary>
    public int AuthorId {get; set;}

    /// <summary>
    /// Gets/sets the publication date of the book.
    /// </summary>
    public DateOnly PublicationDate {get; set;}
}