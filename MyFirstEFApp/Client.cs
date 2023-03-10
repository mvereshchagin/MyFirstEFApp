using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEFApp;

[Index("Name", IsUnique = true)]
internal class Client
{
    [Column("user_id")]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Comment { get; set; }

    public int Height { get; set; }

    [Column("style_of_communication")]
    public string? StyleOfCommunication { get; set; }

    public Company? Company { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
    }
}
