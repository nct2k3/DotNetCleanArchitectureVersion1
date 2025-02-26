using Application.Common.Interfaces.Persistence;
using Domanin.Entities;

namespace Infrastructure.Persistance;

public class UserRepository:IUserRepository
{
    private static List<User> _users=new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u=>u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}