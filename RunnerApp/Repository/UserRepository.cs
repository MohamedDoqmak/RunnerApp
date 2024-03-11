using Microsoft.EntityFrameworkCore;
using RunnerApp.Data;
using RunnerApp.Interfaces;
using RunnerApp.Models;

namespace RunnerApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        async Task<IEnumerable<AppUser>> IUserRepository.GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        async Task<AppUser> IUserRepository.GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public bool Add(AppUser user)
        {
            throw new NotImplementedException();
        }
        public bool Update(AppUser user)
        {
            _context.Update(user);
            return save();
        }
        public bool Delete(AppUser user)
        {
            throw new NotImplementedException();
        }
        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
