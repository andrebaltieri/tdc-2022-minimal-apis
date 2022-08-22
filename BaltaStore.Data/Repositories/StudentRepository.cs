using BaltaStore.Core.Models;
using BaltaStore.Core.UseCases.Students.Create;

namespace BaltaStore.Data.Repositories;

public class StudentRepository : IRepository
{
    private readonly BaltaStoreDataContext _context;

    public StudentRepository(BaltaStoreDataContext context)
        => _context = context;

    public async Task CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }
}