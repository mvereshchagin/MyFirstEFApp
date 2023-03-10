using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstEFApp;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appconfig.json")
    .Build();

var _connectionString = config.GetConnectionString("DefaultConnection");

if (String.IsNullOrEmpty(_connectionString))
{
    Console.WriteLine("Can not find connection string");
    return;
}


// применяем миграции
using (var db = new ApplicationContext(_connectionString!))
{
    try
    {
        db.Database.Migrate();
    }
    catch 
    {
        Console.WriteLine("Error connecting database. Exiting...");
        return;
    }
}



Console.WriteLine("Welcome to our app.");


while (true)
{
    Console.WriteLine("Please, select an action: " +
    "1 - List clients, 2 - Add client, 3 - Update client, 4 - Delete client; 0 - Exit");

    var shouldExit = false;

    var strChoice = Console.ReadLine();

    int choice;
    if (!Int32.TryParse(strChoice, out choice))
        continue;

    switch (choice)
    {
        case 1:
            ListClients();
            break;
        case 2:
            AddClient();
            break;
        case 3:
            UpdateClient();
            break;
        case 4:
            DeleteClient();
            break;
        case 0:
            shouldExit = true;
            break;
    }

    if (shouldExit)
        break;
}

Console.WriteLine("Thank you for using our app. See you later.");


#region CRUD

void AddClient()
{
    string? name = null;
    do
    {
        Console.WriteLine("Please, enter name");
        name = Console.ReadLine();
    }
    while (String.IsNullOrEmpty(name));

    Console.WriteLine("Please, enter email");
    var email = Console.ReadLine();

    Console.WriteLine("Please, enter phone");
    var phone = Console.ReadLine();

    var client = new Client()
    {
        Name = name!,
        Email = email,
        Phone = phone,
    };


    try
    {
        //var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        //var serverVersion = ServerVersion.AutoDetect(_connectionString);
        //optionBuilder.UseMySql(_connectionString, serverVersion);

        //using var context = new ApplicationContext(optionBuilder.Options);

        using var context = new ApplicationContext(_connectionString);

        context.Clients.Add(client);
        context.SaveChanges();

        Console.WriteLine("A client has been stored");
    }
    catch
    {
        Console.WriteLine("An error occured while storing user");
    }
}

void ListClients()
{
    List<Client> clients = new();
    try
    {
        using var context = new ApplicationContext(_connectionString);

        clients = context.Clients.ToList();
    }
    catch
    { }

    Console.WriteLine("Clients:");
    Console.WriteLine("-----------------------");
    foreach (var client in clients)
        Console.WriteLine(client);
    Console.WriteLine("-----------------------");
}

void UpdateClient()
{
    using var context = new ApplicationContext(_connectionString);

    var user = FindClientByName(context);

    while (true)
    {

        bool shouldFinish = false;

        Console.WriteLine("Please, select a field to edit: 1 - Name, 2 - Email, 3 - Phone, 0 - Finish editing");
        var strFieldNumber = Console.ReadLine();

        int fieldNumber;

        if (!Int32.TryParse(strFieldNumber, out fieldNumber))
        {
            Console.WriteLine("Incorrect input");
            continue;
        }

        switch (fieldNumber)
        {
            case 1:
                Console.WriteLine("Please enter new Name");
                var newName = Console.ReadLine();
                user.Name = newName;
                break;
            case 2:
                Console.WriteLine("Please enter new Email");
                var newEmail = Console.ReadLine();
                user.Email = newEmail;
                break;
            case 3:
                Console.WriteLine("Please enter new Phone");
                var newPhone = Console.ReadLine();
                user.Phone = newPhone;
                break;
            case 0:
                shouldFinish = true;
                break;
        }

        if (shouldFinish)
        {
            try
            { 

                context.SaveChanges();
                Console.WriteLine("User is updated");
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured while updating user");
            }
            break;
        }
    }
}

void DeleteClient()
{
    using var context = new ApplicationContext(_connectionString);

    var user = FindClientByName(context);

    Console.WriteLine("Are you sure that you want to delete user? (y / N)");
    var answer = Console.ReadLine();

    if (answer != "y")
        return;

    try
    {
        context.Clients.Remove(user);
        context.SaveChanges();

        Console.WriteLine("The user is deleted");
    }
    catch(Exception e)
    {
        Console.WriteLine("An error occured while deleting user");
    }
}

Client FindClientByName(ApplicationContext context)
{
    Client? user = null;

    while (true)
    {
        Console.WriteLine("Please, enter the user name");
        var name = Console.ReadLine();

        user = (from client in context.Clients
                where client.Name == name
                select client)
                   .FirstOrDefault();

        if (user is null)
        {
            Console.WriteLine("User is not found");
            continue;
        }

        Console.WriteLine("User is found");

        return user;
    }
}

#endregion





