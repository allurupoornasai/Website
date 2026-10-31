using Website.Data;
using Website.Models;
using Microsoft.EntityFrameworkCore;

namespace Website.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User Add)
        {
            await _context.Users.AddAsync(Add);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserbyId(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<List<User>> GetAllUsers ()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.EmailId == email);
        }
    }
}