namespace MyFirstEFApp;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public List<Client> Clients { get; set; } = new();

    public List<ClientService> ClientServices { get; set; } = new();
}
