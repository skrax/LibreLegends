namespace LibreLegends.Game;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public required string Name { get; init; }
}


public class UserService
{
    private readonly Dictionary<Guid, User> _users = new();

    public User Create(string name)
    {
        var user = new User
        {
            Name = name
        };
        
        _users.Add(user.Id, user);
        
        return user;
    }

    public User? Get(Guid id)
    {
        return _users.GetValueOrDefault(id);
    }

    public List<User> Get()
    {
        return _users.Values.ToList();
    }

    public void Delete(Guid id)
    {
        _users.Remove(id);
    }
}