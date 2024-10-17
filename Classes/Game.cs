using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace EntityFramework.Classes
{
    internal class Game
    {
        public int ID { get; set; }
        public string NameOfGame { get; set; }
        public int CompanyId { get; set; }
        public ICollection<Company>? Companies { get; set; }
        public int GameModeId {  get; set; }
        public GameMode GameMode { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int CountOfCopies { get; set; }
        public int StyleID { get; set; }
        public StyleOfGame Style { get; set; }

    }
}
