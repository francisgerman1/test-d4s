using StarWars.Core.Data;

namespace StarWars.Core.Adapter.Interfaces
{
    public interface IPeopleAdapter
    {
        IEnumerable<People> GetPeople();
    }
}
