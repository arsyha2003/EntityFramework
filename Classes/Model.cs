using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace EntityFramework.Classes
{
    enum GameMode
    {
        SinglePlayer,
        MultiPlayer
    }
    internal class Model
    {
        public int Id { get; set; }
        public string NameOfGame { get; set; }
        public string Company {  get; set; }
        public string Style { get; set; }
        public DateTime DateOfPublication { get; set; }
        public GameMode GameMode { get; set; }
        public int CountOfCopies { get; set; }

    }
}
