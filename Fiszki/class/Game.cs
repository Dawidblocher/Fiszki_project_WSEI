using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    public class Game
    {
        public int points = 0;
        public int faul = 0;
        public int gameCategoryId { get; set; }

        public List<Fiche> fichePack { get; set; }

        public Game(string category)
        {
            this.gameCategoryId = DatabaseAccess.GetCategoryId(category)[0];
            fichePack = DatabaseAccess.LoadFiche(this.gameCategoryId);
        }


        
    }
}
