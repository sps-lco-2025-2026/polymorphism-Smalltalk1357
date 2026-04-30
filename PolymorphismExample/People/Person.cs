using System.Globalization;

namespace People;

// Date format: YYYY-MM-DD
public class Person(string name, string surname, string email, DateOnly birthday)
{
    protected string Name { get; } = name;
    protected string Surname { get; } = surname;
    protected string Email { get; } = email;
    protected DateOnly Birthday { get; } = birthday;

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
    private static DateOnly Validate(string birthday)
    {
        if (DateOnly.TryParse(birthday, out DateOnly tBirthday))
        {
            return tBirthday;
        }
        throw new ArgumentException("Invalid date format");
    }

    /// <summary>
    /// Calculates the age of the person in years
    /// </summary>
    public int Age()
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        int age = now.Year - Birthday.Year;
        
        // if the birthday hasn't happened yet this year, subtract 1
        if (now < Birthday.AddYears(age)) 
            age--;
        
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
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        return (currentDate.Month == Birthday.Month && currentDate.Day == Birthday.Day);
    }
    
    /// <summary>
    /// Calculates the Chinese zodiac sign of the person using simple 'divide by twelve' formula
    /// - not accurate for some birthdays in january/february 
    /// </summary>
    public string ChineseZodiac1()
    {
        string[] animalList = [
            "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"];
        
        string[] elementList = ["Metal", "Wood", "Water", "Fire", "Earth"];
        
        int year = Birthday.Year;
        
        int animal = year % 12;
        int element = (year % 10) / 2;
        
        return $"{elementList[element]} {animalList[animal]}";
    }

    /// <summary>
    /// A more accurate calculation of the chinese zodiac using builtin ChineseLunisolarCalendar
    /// </summary>
    public string ChineseZodiac2()
    {
        string[] animalList =
        [
            "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
        ];
        var calendar = new ChineseLunisolarCalendar();
        DateTime birthdate = Birthday.ToDateTime(TimeOnly.MinValue);
        int chineseYear = calendar.GetYear(birthdate);
        int index = ((chineseYear - 4) % 12 + 12) % 12;
        return animalList[index];
    }
    
    /// <summary>
    /// Returns a screen name for the person
    /// </summary>
    public virtual string ScreenName()
    {
        return $"{Surname}{Name[0]}{Birthday.Year}";
    }
}