using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface IVehicleAdapter
    {
        IEnumerable<Vehicle> GetVehicles();
    }
}
