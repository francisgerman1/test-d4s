namespace StarWars.Core.Data
{
    public class Specie
    {
        private IEnumerable<int> _people;
        private IEnumerable<int> _films;
        private int _homeworld;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColors { get; set; }
        public string AverageLifespan { get; set; }
        public Planet Homeworld
        {
            get => Repository.Planets.Single(p => p.Id == _homeworld);
            set { _homeworld = value.Id; }
        }
        public string Language { get; set; }
        public IEnumerable<People> People
        {
            get => Repository.People.Where(s => _people.Any(x => x == s.Id));
            set { _people = value.Select(x => x.Id); }
        }
        public IEnumerable<Film> Films
        {
            get => Repository.Films.Where(s => _films.Any(x => x == s.Id));
            set { _films = value.Select(x => x.Id); }
        }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
