using Microsoft.Extensions.Configuration;
using StarWars.Core.Data;
using StarWars.Core.Integration;
using System.Diagnostics;

var configuration = new ConfigurationBuilder()
     .AddJsonFile($"AppSettings.json");

IConfiguration config = configuration.Build();

Stopwatch clock = new Stopwatch();

clock.Start();

var starships = DataExtractor.GetAll<Starship>(config["Resource:Starship"]);
var films = DataExtractor.GetAll<Film>(config["Resource:Film"]);
var people = DataExtractor.GetAll<People>(config["Resource:People"]);
var planets = DataExtractor.GetAll<Planet>(config["Resource:Planet"]);
var species = DataExtractor.GetAll<Specie>(config["Resource:Specie"]);
var vehicles = DataExtractor.GetAll<Vehicle>(config["Resource:Vehicle"]);

clock.Stop();

Console.WriteLine($"Performed in {clock.Elapsed}");