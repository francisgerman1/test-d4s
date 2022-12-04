namespace StarWars.Core.Data
{
    public class Planet
    {
        private IEnumerable<int> _films;
        private IEnumerable<int> _residents;

        public int Id { get; set; }
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public IEnumerable<People> Residents
        {
            get => Repository.People.Where(s => _residents.Any(x => x == s.Id));
            set { _residents = value.Select(x => x.Id); }
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
