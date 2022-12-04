using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface IStarshipAdapter
    {
        IEnumerable<Starship> GetStarships();
    }
}
