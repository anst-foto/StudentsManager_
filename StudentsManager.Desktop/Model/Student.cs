using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudentsManager.Desktop.Model;

public class Student
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
    
    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }
    
    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }
    
    [JsonIgnore]
    public string FullName => $"{LastName} {FirstName}";
    
    [JsonPropertyName("photo")]
    public Uri? Photo { get; set; }
    
    [JsonPropertyName("faculty")]
    public required string Faculty { get; init; }
    
    public static IEnumerable<Student>? Load(string path = "students.json")
    {
        var json = File.ReadAllText(path);
        var students = JsonSerializer.Deserialize<IEnumerable<Student>>(json);
        return students;
    }

    public static void Save(IEnumerable<Student> students, string path = "students.json")
    {
        var json = JsonSerializer.Serialize(students);
        File.WriteAllText(path, json);
    }
}