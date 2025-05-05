namespace LibraryExercise.Models;

public class Book{

    public string Id {get; set;}

    public string Title {get; set;}

    public int AuthorId {get; set;}

    public DateOnly PublicationDate {get; set;}
}