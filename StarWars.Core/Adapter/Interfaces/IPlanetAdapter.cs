using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface IPlanetAdapter
    {
        IEnumerable<Planet> GetPlanets();
    }
}
