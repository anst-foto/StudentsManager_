using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentsManager.Desktop.Model;

public class Account
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
    
    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }
    
    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }
    
    [JsonIgnore]
    public string FullName => $"{LastName} {FirstName}";
    
    [JsonPropertyName("login")]
    public required string Login { get; init; }
    
    [JsonPropertyName("password")]
    public required string Password { get; init; }

    public static IEnumerable<Account>? Load(string path = "accounts.json")
    {
        var json = File.ReadAllText(path);
        var accounts = JsonSerializer.Deserialize<IEnumerable<Account>>(json);
        return accounts;
    }
}