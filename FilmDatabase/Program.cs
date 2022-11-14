using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmDatabase
{
    public class Film
    {
        public string FilmName { get; set; }
        public int FilmRelease { get; set; }
        public string FilmDirector { get; set; }
        

        public override string ToString()
        {
            return $"{FilmName} ({FilmRelease}) regisserad av {FilmDirector}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Film> films = new List<Film>();
            films.Add(new Film() { FilmName = "Titel 1",  FilmRelease = 2022, FilmDirector = "Person 1"});

            List<Film> watchlist = new List<Film>();
            watchlist.Add(new Film() { FilmName = "Titel 2", FilmRelease = 2022, FilmDirector = "Person 2" });

            Menu(films, watchlist);
        }
        static void Menu(List<Film> films, List<Film> watchlist)
        {
            Console.Clear();

            Console.WriteLine("Meny:");
            Console.WriteLine("(a) Mina filmer");
            Console.WriteLine("(b) Bevakningslista");
            Console.WriteLine("(c) Återställ");

            string menuInput = Console.ReadLine();

            switch (menuInput.ToLower())
            {
                case "a":
                    MyFilms(films, watchlist);
                    break;
                case "b":
                    Watchlist(films, watchlist);
                    break;
                case "c":
                    Reset(films, watchlist);
                    break;
                default:
                    Console.WriteLine("Klicka på en knapp för att fortsätta.");
                    Console.ReadKey();
                    Menu(films, watchlist);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Klicka på en knapp för att fortsätta.");
            Console.ReadKey();
            Menu(films, watchlist);
        }

        static void MyFilms(List<Film> films, List<Film> watchlist)
        {
            Console.Clear();

            Console.WriteLine("Mina filmer:");
            foreach(Film aFilm in films)
            {
                Console.WriteLine(aFilm);
            }

            Console.WriteLine();
            Console.WriteLine("(a) Lägg till film i mina filmer");
            Console.WriteLine("(b) Ta bort film från mina filmer");

            string filmInput = Console.ReadLine();

            switch(filmInput.ToLower())
            {
                case "a":
                    Console.Clear();
                    Console.WriteLine("Namn på film:");
                    string aNameInput = Console.ReadLine();

                    try
                    {

                        Console.Clear();
                        Console.WriteLine("Året filmen släpptes:");
                        int aYearInput = int.Parse(Console.ReadLine());


                        Console.Clear();
                        Console.WriteLine("Regissör för filmen:");
                        string aDirectorInput = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Vill du lägga till filmen {aNameInput} ({aYearInput}) regisserad av {aDirectorInput}? (y/n)");
                        string aConfirmInput = Console.ReadLine();
                        if (aConfirmInput == "y")
                        {
                            films.Add(new Film() { FilmName = aNameInput, FilmRelease = aYearInput, FilmDirector = aDirectorInput });
                            Menu(films, watchlist);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                case "b":
                    Console.Clear();
                    Console.WriteLine("Namn på film:");
                    string bNameInput = Console.ReadLine();
                    foreach(Film aFilm in films)                                                
                    {
                        if(bNameInput.ToLower() == aFilm.FilmName.ToLower())
                        {
                            Console.WriteLine($"Vill du ta bort {aFilm.FilmName} ({aFilm.FilmRelease}) från mina filmer? (y/n)");
                            string bConfirmInput = Console.ReadLine();
                            if(bConfirmInput.ToLower() == "y")
                            {
                                films.Remove(aFilm);
                                Menu(films, watchlist);
                            }
                        }
                    }
                    break;
                default:
                    Menu(films, watchlist);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Klicka på en knapp för att fortsätta.");
            Console.ReadKey();
            Menu(films, watchlist);
        }
        static void Watchlist(List<Film> films, List<Film> watchlist)
        {
            Console.Clear();

            Console.WriteLine("Bevakningslista:");
            foreach (Film aFilm in watchlist)
            {
                Console.WriteLine(aFilm);
            }

            Console.WriteLine();
            Console.WriteLine("(a) Lägg till film i bevakningslista");
            Console.WriteLine("(b) Ta bort film från bevakningslista");

            string filmInput = Console.ReadLine();

            switch (filmInput.ToLower())
            {
                case "a":
                    Console.Clear();
                    Console.WriteLine("Namn på film:");
                    string nameInput = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Året filmen släpptes:");
                    int yearInput = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Regissör för filmen:");
                    string directorInput = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine($"Vill du lägga till filmen {nameInput} ({yearInput}) regisserad av {directorInput}? (y/n)");
                    string confirmInput = Console.ReadLine();
                    if (confirmInput == "y")
                    {
                        watchlist.Add(new Film() { FilmName = nameInput, FilmRelease = yearInput, FilmDirector = directorInput });
                        Menu(films, watchlist);
                    }
                    break;
                case "b":
                    Console.Clear();
                    Console.WriteLine("Namn på film:");
                    string bNameInput = Console.ReadLine();
                    foreach (Film aFilm in watchlist)
                    {
                        if (bNameInput.ToLower() == aFilm.FilmName.ToLower())
                        {
                            Console.WriteLine($"Vill du ta bort {aFilm.FilmName} ({aFilm.FilmRelease}) från bevakningslista? (y/n)");
                            string bConfirmInput = Console.ReadLine();
                            if (bConfirmInput.ToLower() == "y")
                            {
                                watchlist.Remove(aFilm);

                                Menu(films, watchlist);
                            }
                        }
                    }
                    break;
                default:
                    Menu(films, watchlist);
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Klicka på en knapp för att fortsätta.");
            Console.ReadKey();
            Menu(films, watchlist);
        }
        static void Reset(List <Film> films, List<Film> watchlist)
        {
            try
            {
                foreach (Film aFilm in films.ToList())
                {
                    films.Remove(aFilm);
                    continue;
                }
                foreach (Film aFilm in watchlist.ToList())
                {
                    watchlist.Remove(aFilm);
                    continue;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Klicka på en knapp för att fortsätta.");
            Console.ReadKey();
            Menu(films, watchlist);
        }
    }
}
