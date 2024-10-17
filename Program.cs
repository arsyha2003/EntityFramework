using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace EntityFramework.Classes
{
   
    partial class Program
    {
        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                WorkingWithDB working = new WorkingWithDB();
                context.Game.Add(working.AddNewGame((ICollection<Model>)context.Game));//добавления данных в таблицу
                working.ChangeGame((ICollection<Model>)context.Game);
                working.DeleteGame((ICollection<Model>)context.Game);
            }
        }
    }
}
