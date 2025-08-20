namespace WpfApp4;

public class Account
{
    public required Guid Id { get; init; }
    
    public required string LastName { get; init; }
    public required string FirstName { get; init; }
    
    public string FullName => $"{LastName} {FirstName}";
    /*public string FullName
    {
        get
        {
            return $"{LastName} {FirstName}";
        }
    }*/
    
    public required string Login { get; init; }
    public required string Password { get; init; }
}