namespace Tests;
using People;

[TestClass]
public class Tests
{
    // Test Person Class
    [TestMethod]
    public void CheckBirthdayValidation()
    {
        try
        {
            Person p = new Person("John", "Doe", "", "1990-20-20");
            Assert.Fail();
        }
        catch (ArgumentException e)
        {
            Assert.AreEqual("Invalid date format", e.Message);
        }
    }
    
    [TestMethod]
    public void TestAge()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.AreEqual(36, p.Age());
    }

    [TestMethod]
    public void TestBirthday()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.IsFalse(p.IsBirthday());
        
        Person p2 = new Person("John", "Doe", "", "2010-04-26");
        Assert.IsTrue(p2.IsBirthday());
    }

    [TestMethod]
    public void TestScreenName()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.AreEqual("DoeJ1990", p.ScreenName());
    }
    // Date format: YYYY-MM-DD
    
    // Test Student Class
    [TestMethod]
    public void TestStudentScreenName()
    {
        Student s = new Student("John", "Doe", "", "1990-01-01", 11);
        Assert.AreEqual("DoeJ1990-11", s.ScreenName());
    }
    
    // Test Teacher Class
    [TestMethod]
    public void TestTeacherScreenName()
    {
        Teacher t = new Teacher("John", "Doe", "", "1990-01-01", "Maths");
        Assert.AreEqual("DoeJ1990-Teacher[Maths]", t.ScreenName());
    }

    [TestMethod]
    public void TestList()
    {
        List<Person> people = new List<Person>();
        people.Add(new Person("John", "Doe", "", "1990-01-01"));
        people.Add(new Student("Jane", "Smith", "", "1985-05-15", 12));
        people.Add(new Teacher("Bob", "Johnson", "", "1970-08-20", "Science"));

        foreach (Person p in people)
        {
            Console.WriteLine(p.ScreenName());
        }
        Assert.HasCount(3, people);
    }
}