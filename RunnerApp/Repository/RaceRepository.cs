using Microsoft.EntityFrameworkCore;
using RunnerApp.Data;
using RunnerApp.Interfaces;
using RunnerApp.Models;

namespace RunnerApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        ApplicationDbContext _context;
        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Race Race)
        {
            _context.Races.Add(Race);
            return Save();
        }

        public bool Delete(Race Race)
        {
            _context.Remove(Race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }
        public async Task<Race?> GetByIdAsync(int id)
        {
            return await _context.Races.Include(i => i.Address).FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Race?> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<IEnumerable<Race>> GetAllRacesByCity(string City)
        {
            return await _context.Races.Where(r => r.Address.City.Contains(City)).ToListAsync();
        }
        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Race Race)
        {
            _context.Update(Race);
            return Save();
        }
    }
}
