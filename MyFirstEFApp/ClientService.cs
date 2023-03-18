using System.ComponentModel.DataAnnotations;

namespace MyFirstEFApp;

public class ClientService
{
    public int Id { get; set; }

    public Client Client { get; set; } = null!;

    public int ClientId { get; set; }

    public Service Service { get; set; } = null!;

    public int ServiceId { get; set; }

    public DateOnly ExpireDate { get; set; }
}
