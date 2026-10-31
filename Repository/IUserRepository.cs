using Website.Models;
namespace Website.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User Add);
        Task<User?> GetUserbyId(int id);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByEmail(string email);
    }
}
