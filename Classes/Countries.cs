using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Classes
{
    internal class Countries
    {
        public int ID {  get; set; }
        public ICollection<Company> Companies { get; set; }
        public string Name { get; set; }
    }
}
