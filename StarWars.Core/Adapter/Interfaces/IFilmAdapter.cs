using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface IFilmAdapter
    {
        IEnumerable<Film> GetFilms();
    }
}
