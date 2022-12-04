using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface ISpecieAdapter
    {
        IEnumerable<Specie> GetSpecies();
    }
}