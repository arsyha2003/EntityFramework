using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    internal class StyleOfGame
    {
        public int ID { get; set; }
        public ICollection<Game> Games { get; set; }
        public string Name { get; set; }
    }
}
