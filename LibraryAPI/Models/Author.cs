namespace LibraryExercise.Models;

/// <summary>
/// Model for the Author.
/// </summary>
public class Author{

    /// <summary>
    /// Gets/sets the ID of the author.
    /// </summary>
    public int Id {get; set;}

    /// <summary>
    /// Gets/sets the name of the author.
    /// </summary>
    public string Name {get; set;}

    /// <summary>
    /// Gets/sets the family name of the author.
    /// </summary>
    public string FamilyName {get; set;}

    /// <summary>
    /// Gets/sets the date of birth of the author.
    /// </summary>
    public DateOnly DateOfBirth {get; set;}
}