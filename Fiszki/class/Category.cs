using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    public class Category
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        
        public string FullName
        {
            get
            {
                return $"-{nazwa}-";
            }
        }
    }
}
