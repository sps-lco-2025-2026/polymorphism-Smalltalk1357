namespace People;

public class Teacher(string name, string surname, string email, DateOnly birthday, string subject) : Person(name, surname, email, birthday)
{
    private string Subject { get; } = subject;
    
    public Teacher(string name, string surname, string email, string birthday, string subject) : this(name, surname, email, DateOnly.Parse(birthday), subject)
    {
    }
    
    /// <summary>
    /// Returns screen name + teacher identification and subject
    /// </summary>
    public override string ScreenName()
    {
        return $"{Surname}{Name[0]}{Birthday.Year}-Teacher[{Subject}]";
    }
}