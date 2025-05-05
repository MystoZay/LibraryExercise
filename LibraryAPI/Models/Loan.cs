namespace LibraryExercise.Models;

/// <summary>
/// Model for the Loan.
/// </summary>
public class Loan{

    /// <summary>
    /// Gets/sets the ISBN of the book.
    /// </summary>
    public string ISBN {get; set;}

    /// <summary>
    /// Gets/sets the ID of the loan.
    /// </summary>
    public int Id {get; set;}

    /// <summary>
    /// Gets/sets the ID of the author of the book.
    /// </summary>
    public int AuthorId {get; set;}

    /// <summary>
    /// Gets/sets the start date of the loan.
    /// </summary>
    public DateOnly LoanDate {get; set;}

    /// <summary>
    /// Gets/sets the end date of the loan.
    /// </summary>
    public DateOnly ReturnDate {get; set;}
}