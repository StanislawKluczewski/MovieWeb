using MoviesWeb.WebApi.DAL.Models;

namespace MoviesWeb.WebApi.DAL.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetDirectors();
        Task<Director> GetDirector(int id);
        Task CreateDirector(Director director);
        Task UpdateDirector(int id, Director director);
        Task DeleteDirector(int id);
        Task Save();
    }
}
