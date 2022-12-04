namespace StarWars.Core.Data
{
    public class People
    {
        private IEnumerable<int> _films;
        private IEnumerable<int> _species;
        private IEnumerable<int> _vehicles;
        private IEnumerable<int> _starships;
        private int _homeworld;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }

        public Planet Homeworld
        {
            get => Repository.Planets.Single(p => p.Id == _homeworld);
            set { _homeworld = value.Id; }
        }
        public IEnumerable<Film> Films
        {
            get => Repository.Films.Where(s => _films.Any(x => x == s.Id));
            set { _films = value.Select(x => x.Id); }
        }
        public IEnumerable<Specie> Species
        {
            get => Repository.Species.Where(s => _species.Any(x => x == s.Id));
            set { _species = value.Select(x => x.Id); }
        }
        public IEnumerable<Vehicle> Vehicles
        {
            get => Repository.Vehicles.Where(s => _vehicles.Any(x => x == s.Id));
            set { _vehicles = value.Select(x => x.Id); }
        }
        public IEnumerable<Starship> Starships
        {
            get => Repository.Starships.Where(s => _starships.Any(x => x == s.Id));
            set { _starships = value.Select(x => x.Id); }
        }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
