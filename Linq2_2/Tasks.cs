using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2_2
{
    public static class Tasks
    {
        private static ActorComparer actorEqC = new ActorComparer();

        public static List<object> data = new List<object> {
            "Hello",
            new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
            new List<int> {45, 9, 8, 3},
            new string[] {"Hello inside array"},
            new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
            }},
            new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
            }},
            new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
            "Leonardo DiCaprio"
        };

        public static void Task1()
        {
            Console.WriteLine(string.Join(",",
                data.OfType<Film>().SelectMany(f => f.Actors.Select(a => a.Name)).Distinct()));
        }

        public static void Task2()
        {
            Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors.Where(a => a.Birthdate.Month == 8))
                .Distinct(actorEqC).Count());
        }

        public static void Task3()
        {
            Console.WriteLine(string.Join(",",
                data.OfType<Film>().SelectMany(f => f.Actors).Distinct(actorEqC).OrderBy(a => a.Birthdate).Take(2)
                    .Select(a => a.Name)));
        }
        
        public static void Task4()
        {
            var output = data.OfType<Article>().GroupBy(a => a.Author);

            foreach (var i in output)
            {
                Console.WriteLine($"{i.Key}: {i.Count()}");
            }
        }
        
        public static void Task5()
        {
            Task4();
            
            var output = data.OfType<Film>().GroupBy(a => a.Author);

            foreach (var i in output)
            {
                Console.WriteLine($"{i.Key}: {i.Count()}");
            }
        }
        
        public static void Task6()
        {
            Console.WriteLine(string.Join("",
                data.OfType<Film>().SelectMany(f => f.Actors.Select(a => a.Name.Replace(" ", "").ToLower())).Distinct()
                    .Count()));
        }

        public static void Task7()
        {
            Console.WriteLine(string.Join(",",data.OfType<Article>()
                .OrderBy(a => a.Author).ThenBy(a => a.Pages).Select(a => a.Name)));
        }
        
        public static void Task8()
        {
            var filmsOfActors = data.OfType<Film>().SelectMany(f => f.Actors.Select(a => a.Name)).Distinct().GroupBy(n => n)
                .Select(g => new
                {
                    Actor = g.Key,
                    Films = data.OfType<Film>().Where(f => f.Actors.Any(a => a.Name == g.Key))
                });

            foreach (var filmsOfActor in filmsOfActors)
            {
                Console.WriteLine($"{filmsOfActor.Actor}: {string.Join(",", filmsOfActor.Films.Select(f => f.Name))}");
            }
        }
        
        public static void Task9()
        {
            var sumOfInts = data.OfType<List<int>>().SelectMany(e => e).Sum();
            var sumOfPages = data.OfType<Article>().Select(a => a.Pages).Sum();

            Console.WriteLine(sumOfInts + sumOfPages);
        }
        
        public static void Task10()
        {
            var dict = data.OfType<Article>().GroupBy(a => a.Author)
                .ToDictionary(author => author.Key, articles => articles.ToList());

            foreach (var record in dict)
            {
                Console.WriteLine($"{record.Key}: {string.Join(",", record.Value.Select(a => a.Name))}");
            }
        }
    }
}
