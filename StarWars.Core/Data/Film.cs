namespace StarWars.Core.Data
{
    public class Film
    {
        private IEnumerable<int> _characters;
        private IEnumerable<int> _planets;
        private IEnumerable<int> _starships;
        private IEnumerable<int> _vehicles;
        private IEnumerable<int> _species;

        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public IEnumerable<People> Characters
        {
            get => Repository.People.Where(s => _characters.Any(x => x == s.Id));
            set { _characters = value.Select(x => x.Id); }
        }
        public IEnumerable<Planet> Planets
        {
            get => Repository.Planets.Where(s => _planets.Any(x => x == s.Id));
            set { _planets = value.Select(x => x.Id); }
        }
        public IEnumerable<Starship> Starships
        {
            get => Repository.Starships.Where(s => _starships.Any(x => x == s.Id));
            set { _starships = value.Select(x => x.Id); }
        }
        public IEnumerable<Vehicle> Vehicles
        {
            get => Repository.Vehicles.Where(s => _vehicles.Any(x => x == s.Id));
            set { _vehicles = value.Select(x => x.Id); }
        }
        public IEnumerable<Specie> Species
        {
            get => Repository.Species.Where(s => _species.Any(x => x == s.Id));
            set { _species = value.Select(x => x.Id); }

        }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
