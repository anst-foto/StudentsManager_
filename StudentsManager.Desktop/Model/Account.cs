using System.IO;
using System.Text.Json;

namespace StudentsManager.Desktop.Model;

public class Account
{
    public required Guid Id { get; init; }
    
    public required string LastName { get; init; }
    public required string FirstName { get; init; }
    
    public string FullName => $"{LastName} {FirstName}";
    
    public required string Login { get; init; }
    public required string Password { get; init; }

    public static IEnumerable<Account>? Load(string path = "accounts.json")
    {
        var json = File.ReadAllText(path);
        var accounts = JsonSerializer.Deserialize<IEnumerable<Account>>(json);
        return accounts;
    }
}