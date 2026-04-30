namespace People;

public class Student(string name, string surname, string email, DateOnly birthday, int yeargroup) : Person(name, surname, email, birthday)
{
    private int YearGroup { get; } = yeargroup;

    public Student(string name, string surname, string email, string birthday, int yeargroup) : this(name, surname, email, DateOnly.Parse(birthday), yeargroup)
    {
    }
    
    /// <summary>
    /// Returns screen name + yeargroup for the student
    /// </summary>
    public override string ScreenName()
    {
        return $"{Surname}{Name[0]}{Birthday.Year}-{YearGroup}";
    }
}