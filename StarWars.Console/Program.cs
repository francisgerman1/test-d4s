using Microsoft.Extensions.Configuration;
using StarWars.Core.Adapter.Implementation;
using StarWars.Core.Api;
using StarWars.Core.Integration;
using System.Diagnostics;

IConfiguration config = new ConfigurationBuilder().AddJsonFile($"AppSettings.json").Build();

Stopwatch clock = new Stopwatch();
clock.Start();

//Avoid throttling from api for testing purposes
#if DEBUG
var starships = DataExtractor.GetAllFromJson<Starship>();
var films = DataExtractor.GetAllFromJson<Film>();
var people = DataExtractor.GetAllFromJson<People>();
var planets = DataExtractor.GetAllFromJson<Planet>();
var species = DataExtractor.GetAllFromJson<Specie>();
var vehicles = DataExtractor.GetAllFromJson<Vehicle>();
#endif
#if !DEBUG
var starships = DataExtractor.GetAll<Starship>(config["Resource:Starship"]);
var films = DataExtractor.GetAll<Film>(config["Resource:Film"]);
var people = DataExtractor.GetAll<People>(config["Resource:People"]);
var planets = DataExtractor.GetAll<Planet>(config["Resource:Planet"]);
var species = DataExtractor.GetAll<Specie>(config["Resource:Specie"]);
var vehicles = DataExtractor.GetAll<Vehicle>(config["Resource:Vehicle"]);
#endif


Task.WaitAll(new Task[] { starships, films, people, planets, species, vehicles });

Adapter adapter = new Adapter(films.Result, people.Result,
                              planets.Result, species.Result,
                              starships.Result, vehicles.Result);

StarWars.Core.Data.Repository.Species = adapter.GetSpecies();
StarWars.Core.Data.Repository.Planets = adapter.GetPlanets();
StarWars.Core.Data.Repository.Films = adapter.GetFilms();
StarWars.Core.Data.Repository.Starships = adapter.GetStarships();
StarWars.Core.Data.Repository.Vehicles = adapter.GetVehicles();
StarWars.Core.Data.Repository.People = adapter.GetPeople();

clock.Stop();

Console.WriteLine($"Performed in {clock.Elapsed}");