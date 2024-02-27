using RunnerApp.Models;

namespace RunnerApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string City);
        bool Add(Race Race);
        bool Update(Race Race);
        bool Delete(Race Race);
        bool Save();
    }
}
