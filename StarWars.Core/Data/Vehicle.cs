namespace StarWars.Core.Data
{
    public class Vehicle
    {
        private IEnumerable<int> _pilots;
        private IEnumerable<int> _films;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string VehicleClass { get; set; }
        public IEnumerable<People> Pilots
        {
            get => Repository.People.Where(s => _pilots.Any(x => x == s.Id));
            set { _pilots = value.Select(x => x.Id); }
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
