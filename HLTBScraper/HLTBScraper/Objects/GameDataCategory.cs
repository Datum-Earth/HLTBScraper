using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Objects
{
    public class GameDataCategory
    {
        public string Category { get; set; }
        public IEnumerable<GameDataSubCategory> SubCategories { get; set; }
    }
}
