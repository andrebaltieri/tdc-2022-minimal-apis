using BaltaStore.Core.Models;
using BaltaStore.Core.UseCases.Students.Create;

namespace BaltaStore.Core.Tests;

public class FakeRepository : IRepository
{
    public async Task CreateAsync(Student student)
        => await Task.Delay(0);
}

[TestClass]
public class CreateStudentHandlerTests
{
    [TestMethod]
    [DataRow("André", "Baltieri", "email@email.com", true)]
    [DataRow("oi", "Baltieri", "email@email.com", false)]
    [DataRow("André", "oi", "email@email.com", false)]
    [DataRow("André", "Baltieri", "oi", false)]
    public async Task ShouldValidateHandler(string firstName, string lastName, string email, bool isValid)
    {
        var request = new Request
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
        var repository = new FakeRepository();
        var handler = new Handler(repository);

        var response = await handler.HandleAsync(request);
        Assert.AreEqual(response.IsValid, isValid);
    }
}