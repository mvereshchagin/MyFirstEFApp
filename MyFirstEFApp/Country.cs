namespace MyFirstEFApp;

internal class Country
{
    public int Id { get; set; }

    public string ShortName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int PhoneCode { get; set; }

    public string CurrencyName { get; set; } = null!;
}
