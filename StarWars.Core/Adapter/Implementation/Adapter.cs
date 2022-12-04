using StarWars.Core.Adapter.Interfaces;
using StarWars.Core.Api;
using System.Text.RegularExpressions;

namespace StarWars.Core.Adapter.Implementation
{
    public class Adapter : IFilmAdapter, IPeopleAdapter,
                           IPlanetAdapter, ISpecieAdapter,
                           IStarshipAdapter, IVehicleAdapter
    {
        private readonly IEnumerable<Film> _filmsFromApi;
        private readonly IEnumerable<People> _peopleFromApi;
        private readonly IEnumerable<Planet> _planetFromApi;
        private readonly IEnumerable<Specie> _speciesFromApi;
        private readonly IEnumerable<Starship> _starshipsFromApi;
        private readonly IEnumerable<Vehicle> _vehiclesFromApi;

        public Adapter(IEnumerable<Film> filmsFromApi,
                       IEnumerable<People> peopleFromApi,
                       IEnumerable<Planet> planetFromApi,
                       IEnumerable<Specie> speciesFromApi,
                       IEnumerable<Starship> starshipsFromApi,
                       IEnumerable<Vehicle> vehiclesFromApi)
        {
            _filmsFromApi = filmsFromApi;
            _peopleFromApi = peopleFromApi;
            _planetFromApi = planetFromApi;
            _speciesFromApi = speciesFromApi;
            _starshipsFromApi = starshipsFromApi;
            _vehiclesFromApi = vehiclesFromApi;
        }

        public IEnumerable<Data.Planet> GetPlanets()
        {
            return _planetFromApi.Select(p => new Data.Planet
            {
                Id = GetId(p.url),
                Climate = p.climate,
                Created = p.created,
                Diameter = p.diameter,
                Edited = p.edited,
                Gravity = p.gravity,
                Name = p.name,
                Population = p.population,
                OrbitalPeriod = p.orbital_period,
                RotationPeriod = p.rotation_period,
                SurfaceWater = p.surface_water,
                Terrain = p.terrain,
                Films = p.films.Select(x => new Data.Film { Id = GetId(x) }),
                Residents = p.residents.Select(x => new Data.People { Id = GetId(x) })
            });
        }

        public IEnumerable<Data.Specie> GetSpecies()
        {
            return _speciesFromApi.Select(s => new Data.Specie
            {
                Id = GetId(s.url),
                AverageHeight = s.average_height,
                AverageLifespan = s.average_lifespan,
                Classification = s.classification,
                Created = s.created,
                Designation = s.designation,
                Edited = s.edited,
                EyeColors = s.eye_colors,
                HairColors = s.hair_colors,
                Language = s.language,
                Name = s.name,
                SkinColors = s.skin_colors,
                People = s.people.Select(x => new Data.People { Id = GetId(x) }),
                Films = s.films.Select(x => new Data.Film { Id = GetId(x) }),
                Homeworld = new Data.Planet { Id = GetId(s.homeworld) }
            });
        }

        public IEnumerable<Data.Starship> GetStarships()
        {
            return _starshipsFromApi.Select(s => new Data.Starship
            {
                Id = GetId(s.url),
                Name = s.name,
                CargoCapacity = s.cargo_capacity,
                Consumables = s.consumables,
                CostInCredits = s.cost_in_credits,
                Created = s.created,
                Crew = s.crew,
                Edited = s.edited,
                HyperdriveRating = s.hyperdrive_rating,
                Length = s.length,
                Manufacturer = s.manufacturer,
                MaxAtmospheringSpeed = s.max_atmosphering_speed,
                MGLT = s.MGLT,
                Model = s.model,
                StarshipClass = s.starship_class,
                Passengers = s.passengers,
                Films = s.films.Select(x => new Data.Film { Id = GetId(x) }),
                Pilots = s.pilots.Select(x => new Data.People { Id = GetId(x) })
            });
        }

        public IEnumerable<Data.Vehicle> GetVehicles()
        {
            return _vehiclesFromApi.Select(v => new Data.Vehicle
            {
                Id = GetId(v.url),
                CargoCapacity = v.cargo_capacity,
                Consumables = v.consumables,
                CostInCredits = v.cost_in_credits,
                Created = v.created,
                Crew = v.crew,
                Edited = v.edited,
                Length = v.length,
                Name = v.name,
                MaxAtmospheringSpeed = v.max_atmosphering_speed,
                Model = v.model,
                Passengers = v.passengers,
                VehicleClass = v.vehicle_class,
                Films = v.films.Select(x => new Data.Film { Id = GetId(x) }),
                Pilots = v.pilots.Select(x => new Data.People { Id = GetId(x) })
            });
        }

        public IEnumerable<Data.Film> GetFilms()
        {
            return _filmsFromApi.Select(f => new Data.Film
            {
                Id = GetId(f.url),
                Created = f.created,
                Edited = f.edited,
                EpisodeId = f.episode_id,
                OpeningCrawl = f.opening_crawl,
                ReleaseDate = f.release_date,
                Title = f.title,
                Producer = f.producer,
                Director = f.director,
                Characters = f.characters.Select(x => new Data.People { Id = GetId(x) }),
                Planets = f.planets.Select(x => new Data.Planet { Id = GetId(x) }),
                Vehicles = f.vehicles.Select(x => new Data.Vehicle { Id = GetId(x) }),
                Starships = f.starships.Select(x => new Data.Starship { Id = GetId(x) }),
                Species = f.species.Select(x => new Data.Specie { Id = GetId(x) })
            });
        }

        public IEnumerable<Data.People> GetPeople()
        {
            return _peopleFromApi.Select(p => new Data.People
            {
                Id = GetId(p.url),
                BirthYear = p.birth_year,
                Created = p.created,
                Edited = p.edited,
                EyeColor = p.eye_color,
                Gender = p.gender,
                HairColor = p.hair_color,
                Height = p.height,
                Name = p.name,
                Mass = p.mass,
                SkinColor = p.skin_color,
                Films = p.films.Select(x => new Data.Film { Id = GetId(x) }),
                Vehicles = p.vehicles.Select(x => new Data.Vehicle { Id = GetId(x) }),
                Starships = p.starships.Select(x => new Data.Starship { Id = GetId(x) }),
                Species = p.species.Select(x => new Data.Specie { Id = GetId(x) }),
                Homeworld = new Data.Planet { Id = GetId(p.homeworld) }
            });
        }

        private int GetId(string value)
        {

            Regex regex = new Regex(@"\/[0-9]+\/");
            return Convert.ToInt32(regex.Match(value).Value.Replace('/', ' ').Trim());
        }
    }
}
