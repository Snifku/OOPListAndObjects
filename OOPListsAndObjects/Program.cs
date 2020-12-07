using System;
using System.Collections.Generic;
using System.IO;

namespace OOPListsAndObjects
{
    class Program
    {
        private static object stringsplitoptions;

        class Planet
        {
            string name;
            int mass;

            public Planet(string _name, int _mass)
            {
                name = _name;
                mass = _mass;
            }

            public string Name { get { return name; } }
            public int Mass { get { return mass; } }

            int static void Add(Planet newPlanet)
            {
                
            }
        }

        class ListOfPlanets
        {
            List<Planet> planets;
            int totalMass;
            private object planetFromList;

            public ListOfPlanets()
            {
                planets = new List<Planet>();
                totalMass = 0;
            }


            public void AddPlanetToList(string planetName, int planetMass)
            {
                Planet newPlanet = new Planet(planetName, planetMass);
                Planet.Add(newPlanet);
            }

            public void PrintPlanets()
            {
                foreach(Planet planetFromList in planets)
                {
                    Console.WriteLine($"Planet:{planetFromList.Name}; Mass:{planetFromList.Mass}");
                }
            }
        }
        static void Main(string[] args)
        {
            ListOfPlanets newPlanetsList = new ListOfPlanets();
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"planets.txt";
            string fullPath = Path.Combine(filePath, fileName);


            string[] planetsFromFile = File.ReadAllLines(fullPath);

            foreach (string line in planetsFromFile)
            {
                string[] tempArray= line.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                string planetName = tempArray[0];
                int planetMass = int.Parse(tempArray[1]);
                Console.WriteLine(planetName);
                Console.WriteLine(planetMass);
                Console.WriteLine("------------");

                
                newPlanetsList.AddPlanetToList(planetName, planetMass);

            }

            newPlanetsList.PrintPlanets();
        }
    }
}
