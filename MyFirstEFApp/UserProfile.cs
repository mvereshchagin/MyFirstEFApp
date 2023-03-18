using System.ComponentModel.DataAnnotations;

namespace MyFirstEFApp;

public class UserProfile
{
    [Key]
    public int Id { get; set; }

    public byte[]? Image { get; set; }

    public string? Status { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

}
