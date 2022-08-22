using Flunt.Notifications;
using Flunt.Validations;

namespace BaltaStore.Core.UseCases.Students.Create;

public class Request : Notifiable<Notification>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNull(FirstName, "FirstName", "Nome inválido")
            .IsGreaterThan(FirstName, 3, "FirstName", "Nome inválido")
            .IsLowerThan(FirstName, 16, "FirstName", "Nome inválido")
            .IsNotNull(LastName, "LastName", "Sobrenome inválido")
            .IsGreaterThan(LastName, 3, "Sobrenome", "Nome inválido")
            .IsLowerThan(LastName, 16, "Sobrenome", "Nome inválido")
            .IsNotNull(Email, "Email", "E-mail inválido")
            .IsEmail(Email, "Email", "E-mail inválido"));
    }
}