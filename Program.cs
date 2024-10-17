using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace EntityFramework.Classes
{

    partial class Program
    {
        public static void InsertData(Context context)
        { 
            GameMode gm1 = new GameMode()
            {
                Name = "Multiplayer"
            };
            GameMode gm2 = new GameMode()
            {
                Name = "SinglePlayer"
            };
            Game game1 = new Game()
            {
                NameOfGame = "UltraKiill",
                CompanyId = 1,
                GameModeId = 1,
                CountOfCopies = 1,
                DateOfPublication = DateTime.Now,
                GameMode = gm1
            };
            Game game2 = new Game()
            {
                NameOfGame = "Cuphead",
                CompanyId = 2,
                GameModeId = 2,
                CountOfCopies = 1,
                DateOfPublication = DateTime.Now,
                GameMode = gm2
            };

            Company company = new Company()
            {
                Name = "ImbaCompany",
                Games = new List<Game>()
                    { game1}

            };
            Company company2 = new Company()
            {
                Name = "SecondCompany",
                Games = new List<Game>()
                    {game2}

            };
            Countries country = new Countries()
            {
                Name = "RUSIA",
                Companies = new List<Company>()
                {
                    company
                }
            };
            Countries country2 = new Countries()
            {
                Name = "AMERICA",
                Companies = new List<Company>()
                {
                    company2
                }
            };
            StyleOfGame style = new StyleOfGame()
            {
                Name = "Shooter",
                Games = new List<Game>()
                { game1}
                
            };
            StyleOfGame style2 = new StyleOfGame()
            {
                Name = "Platformer",
                Games = new List<Game>()
                { game2}
                
            };

            context.game.Add(game1);
            context.game.Add(game2);

            context.gameMode.Add(gm1);
            context.gameMode.Add(gm2);

            context.countries.Add(country);
            context.countries.Add(country2);

            context.companies.Add(company);
            context.companies.Add(company2);

            context.styles.Add(style);
            context.styles.Add(style2);
            context.SaveChanges();
        }
        public static void SelectAllSingleplayerGames(Context context)
        {
            var select = from game in context.game
                         join gameMode in context.gameMode on game.GameModeId equals gameMode.ID
                         where gameMode.ID == 2
                         select new { Name = game.NameOfGame, GM = gameMode.Name };
            foreach(var i in select)
            {
                Console.WriteLine($"{i.Name} {i.GM}");
            }
        }
        public static void SelectAllMultiplayerGames(Context context)
        {
            var select = from game in context.game
                         join gameMode in context.gameMode on game.GameModeId equals gameMode.ID
                         where gameMode.ID == 1
                         select new { Name = game.NameOfGame, GM = gameMode.Name };
            foreach(var i in select)
            {
                Console.WriteLine($"{i.Name} {i.GM}");
            }
        }
        public static void SelectTopGameWithMaxSellsPerStyle(Context context,string styleName)
        {
            var select = from game in context.game
                      join style in context.styles on game.StyleID equals style.ID
                      where style.Name == styleName
                      select new { CountOfCopies = game.CountOfCopies };
            int max = select.Max(p=>p.CountOfCopies);
            var newSelect = from game in context.game
                     where game.CountOfCopies == max
                     select new { Name = game.NameOfGame, CountOfCopies = game.CountOfCopies };
            Console.WriteLine($"Игра с макимальным количеством копий жанра {styleName}: ");
            foreach (var i in newSelect)
            {
                Console.WriteLine($"{i.Name} {i.CountOfCopies}");
            }
        }
        public static void SelectTopFiveTopSellableGamesPerStyle(Context context, string styleName)
        {
            var newSelect = from game in context.game
                            join style in context.styles on game.StyleID equals style.ID
                            orderby game.CountOfCopies ascending
                            where style.Name == styleName
                            select new { Name = game.NameOfGame, CountOfCopies = game.CountOfCopies };
            Console.WriteLine($"Топ 5 самых продаваемых игр жанра {styleName}: ");
            foreach (var i in newSelect.Take(5))
            {
                Console.WriteLine($"{i.Name} {i.CountOfCopies}");
            }
        }
        public static void SelectTopFiveNonSellableGamesPerStyle(Context context, string styleName)
        {
            var newSelect = from game in context.game
                            join style in context.styles on game.StyleID equals style.ID
                            orderby game.CountOfCopies descending
                            where style.Name == styleName
                            select new { Name = game.NameOfGame, CountOfCopies = game.CountOfCopies };
            Console.WriteLine($"Топ 5 самых не продаваемых игр жанра {styleName}: ");
            foreach (var i in newSelect.Take(5))
            {
                Console.WriteLine($"{i.Name} {i.CountOfCopies}");
            }
        }
        public static void SelectFullInfoOfGame(Context context, string gameName)
        {
            var allInfo = context.game.Include(p => p.Companies).Include(p => p.GameMode).Include(p => p.Style);
            foreach (var i in allInfo)
            {
                Console.WriteLine($"{i.NameOfGame} {i.Style.Name} Количество компаний: {i.Companies.Count} {i.GameMode.Name}");
            }
        }
        public static void SelectStudio(Context context)
        {
        }
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                InsertData(context);

                SelectAllSingleplayerGames(context);
                SelectAllMultiplayerGames(context);
                SelectTopGameWithMaxSellsPerStyle(context, "Platformer");
                SelectTopFiveTopSellableGamesPerStyle(context, "Platformer");
                SelectTopFiveNonSellableGamesPerStyle(context, "Platformer");
                SelectFullInfoOfGame(context, "UltraKill");

            }
        }
    }
}
