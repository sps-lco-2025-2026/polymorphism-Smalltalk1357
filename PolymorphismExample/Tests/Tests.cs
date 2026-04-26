namespace Tests;
using People;

[TestClass]
public class Tests
{
    [TestMethod]
    public void CheckBirthday()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.AreEqual(p.Birthday, DateOnly.FromDateTime(new DateTime(1990, 1, 1)) );
    }
    
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
    
    // Date format: YYYY-MM-DD
}