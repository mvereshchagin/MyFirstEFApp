namespace MyFirstEFApp;

internal class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
    }
}
