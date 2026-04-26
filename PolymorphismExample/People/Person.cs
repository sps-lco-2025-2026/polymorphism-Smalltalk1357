namespace People;

// Date format: YYYY-MM-DD
public class Person(string name, string surname, string email, DateOnly birthday)
{
    public string Name { get; } = name;
    public string Surname { get; } = surname;
    public string Email { get; } = email;
    public DateOnly Birthday { get; } = birthday;

    /// <summary>
    /// Constructor
    /// </summary>
    public Person(string name, string surname, string email, string birthday) : this(name, surname, email,
        Validate(birthday))
    {
    }
    
    /// <summary>
    /// Validates if Birthday is a valid date format, otherwise throws an exception.
    /// </summary>
    ///
    private static DateOnly Validate(string birthday)
    {
        if (DateOnly.TryParse(birthday, out DateOnly tBirthday))
        {
            return tBirthday;
        }
        throw new ArgumentException("Invalid date format");
    }

    /// <summary>
    /// Calculates the age of the person
    /// </summary>
    public int Age()
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        int age = now.Year - Birthday.Year;
        
        // if the birthday hasn't happened yet this year, subtract 1
        if (now < Birthday.AddYears(age)) age--;
        
        return age;
    }

    /// <summary>
    /// Checks if the person is an adult
    /// </summary>
    public bool IsAdult()
    {
        return Age() >= 18;
    }

    /// <summary>
    /// Checks if it's the person's birthday
    /// </summary>
    public bool IsBirthday()
    {
        return DateOnly.FromDateTime(DateTime.Now) == Birthday;
    }
}