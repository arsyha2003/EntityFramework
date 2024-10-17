using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    class WorkingWithDB
    {
        public void FindGameByName(string name, ICollection<Model> collection)
        {
            var game = collection.Where(g => g.NameOfGame == name).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void FindGameByCompanyNameAndGameName(string companyName, string name, ICollection<Model> collection)
        {
            var game = collection.Where(g => g.Company == companyName && g.NameOfGame == name).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void FindGameByCompanyName(string companyName, ICollection<Model> collection)
        {
            var game = collection.Where(g => g.Company == companyName).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void FindGameByStyle(string style, ICollection<Model> collection)
        {
            var game = collection.Where(g => g.Style == style).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void FindGameByDateOfPublic(DateTime date, ICollection<Model> collection)
        {
            var game = collection.Where(g => g.DateOfPublication == date).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }


        public void SelectAllSinglePlayerGame(ICollection<Model> collection)
        {
            var game = collection.Where(g => g.GameMode == "SinglePlayer").Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void SelectAllMultiPlayerGame(ICollection<Model> collection)
        {
            var game = collection.Where(g => g.GameMode == "MultiPlayer").Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void SelectGameWithMaxSells(ICollection<Model> collection)
        {
            int maxSells = collection.Max(s => s.CountOfCopies);
            var game = collection.Where(g => g.CountOfCopies == maxSells).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void SelectGameWithMinSells(ICollection<Model> collection)
        {
            int minSells = collection.Min(s => s.CountOfCopies);
            var game = collection.Where(g => g.CountOfCopies == minSells).Select(g => g);
            foreach (var g in game)
            {
                Console.WriteLine($"{g.NameOfGame} {g.GameMode} {g.Company}");
            }
        }
        public void SelectTop3SellableGames(ICollection<Model> collection)
        {
            var game = from g in collection
                       orderby g descending
                       select g.NameOfGame;
            foreach (var g in game.Take(3))
            {
                Console.WriteLine($"{g}");
            }
        }
        public void SelectTop3NonSellableGames(ICollection<Model> collection)
        {
            var game = from g in collection
                       orderby g ascending
                       select g.NameOfGame;
            foreach (var g in game.Take(3))
            {
                Console.WriteLine($"{g}");
            }
        }

        public Model AddNewGame(ICollection<Model> collection)
        {
            Model addedGame = new Model();
            Console.WriteLine("Введите название игры: ");
            addedGame.NameOfGame = Console.ReadLine();
            Console.WriteLine("Введите имя компании: ");
            addedGame.Company = Console.ReadLine();
            Console.WriteLine("Введите жанр игры: ");
            addedGame.Style = Console.ReadLine();
            Console.WriteLine("Введите дату релиза игры: ");
            addedGame.DateOfPublication = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите режим игры:");
            addedGame.GameMode = Console.ReadLine();
            Console.WriteLine("Введите количество копий:");
            addedGame.CountOfCopies = int.Parse(Console.ReadLine());
            addedGame.Id = Convert.ToInt32(collection.Select(p => p.Id).Last()) + 1;
            return addedGame;
        }
        public void ChangeGame(ICollection<Model> collection)
        {
            Console.WriteLine("Напишите название игры");
            string name = Console.ReadLine();
            Console.WriteLine("Выберите что изменить: ");
            Console.WriteLine("1-Имя игры");
            Console.WriteLine("2-Количество копий");
            Console.WriteLine("3-Дату релиза");
            Console.WriteLine();
            int chose = int.Parse(Console.ReadLine());
            switch (chose)
            {
                case 1:
                    Console.WriteLine("Введите новое имя:");
                    var obj = collection.Where(p => p.NameOfGame == name).Select(p => p);
                    obj.ToList()[0].NameOfGame = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Введите новое количество копий:");
                    obj = collection.Where(p => p.NameOfGame == name).Select(p => p);
                    obj.ToList()[0].CountOfCopies = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Введите новую дату релиза:");
                    obj = collection.Where(p => p.NameOfGame == name).Select(p => p);
                    obj.ToList()[0].DateOfPublication = DateTime.Parse(Console.ReadLine());
                    break;
            }
        }
        public void DeleteGame(ICollection<Model> collection)
        {
            Console.WriteLine("Напишите название игры");
            string name = Console.ReadLine();
            var obj = collection.Where(p => p.NameOfGame == name).Select(p => p);
            obj.ToList().RemoveAt(0);
        }
    }
}
