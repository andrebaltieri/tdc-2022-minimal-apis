using BaltaStore.Core.UseCases.Students.Create;

namespace BaltaStore.Core.Tests;

[TestClass]
public class CreateStudentRequestTests
{
    [TestMethod]
    [DataRow("André", "Baltieri", "email@email.com", true)]
    [DataRow("oi", "Baltieri", "email@email.com", false)]
    [DataRow("André", "oi", "email@email.com", false)]
    [DataRow("André", "Baltieri", "oi", false)]
    public void ShouldValidateRequest(string firstName, string lastName, string email, bool isValid)
    {
        var request = new Request
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
        request.Validate();
        
        Assert.AreEqual(request.IsValid, isValid);
    }
}