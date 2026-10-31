using Website.DTOs;
using Website.Models;
namespace Website.Services
{
    public interface IUserServices
    {
        Task<string> AddUser(RegisterDto add);
        Task<List<RegisterDto>> GetAllUsers();
        Task<RegisterDto?> GetbyId(int id);
        Task<string> GetUserbyEmail(LoginDto login);
    }
}
