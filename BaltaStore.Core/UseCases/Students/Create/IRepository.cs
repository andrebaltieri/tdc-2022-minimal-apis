using BaltaStore.Core.Models;

namespace BaltaStore.Core.UseCases.Students.Create;

public interface IRepository
{
    Task CreateAsync(Student student);
}