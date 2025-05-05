namespace LibraryExercise.Models;

public class Loan{

    public string ISBN {get; set;}

    public int Id {get; set;}

    public int AuthorId {get; set;}

    public DateOnly LoanDate {get; set;}

    public DateOnly ReturnDate {get; set;}
}