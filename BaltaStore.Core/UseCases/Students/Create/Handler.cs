using BaltaStore.Core.Models;
using Flunt.Notifications;

namespace BaltaStore.Core.UseCases.Students.Create;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
        => _repository = repository;

    public async Task<Response> HandleAsync(Request request)
    {
        request.Validate();
        if (!request.IsValid)
            return new Response("Requisição inválida", request.Notifications);

        try
        {
            var student = new Student(
                Guid.NewGuid(),
                $"{request.FirstName} {request.LastName}",
                request.Email);
            await _repository.CreateAsync(student);
        }
        catch
        {
            return new Response("", new Notification
            {
                Key = "InternalError",
                Message = "Não foi possível realizar seu cadastro"
            });
        }

        return new Response("Cadastro realizado com sucesso!");
    }
}