using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEFApp;

// [NotMapped]
[Table("Companies")]
public class Company
{
    private string _name;

    public int Id { get; set; }

    // не попадает в БД
    // [NotMapped]
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public virtual List<Client> Clients { get; set; } = new();

    public override string ToString()
    {
        return $"{Name}";
    }
}
