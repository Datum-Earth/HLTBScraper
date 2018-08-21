using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Objects
{
    public class GameData
    {
        public string Title { get; }
        public IEnumerable<GameDataCategory> Categories { get; }
    }
}
