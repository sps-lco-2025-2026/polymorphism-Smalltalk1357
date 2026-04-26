namespace Tests;
using People;

[TestClass]
public class Tests
{
    [TestMethod]
    public void TestBirthday()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.AreEqual(p.Birthday, DateOnly.FromDateTime(new DateTime(1990, 1, 1)) );
    }
    
    [TestMethod]
    public void TestAge()
    {
        Person p = new Person("John", "Doe", "", "1990-01-01");
        Assert.AreEqual(36, p.Age());
    }
    
    [TestMethod]
    public void TestBirthdayValidation()
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
}