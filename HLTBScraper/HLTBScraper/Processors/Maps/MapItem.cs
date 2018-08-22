using HLTBScraper.Processors.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors.Maps
{
    internal class MapItem
    {
        public StateCommand NextCommand { get; }
        public string[] Values { get; }
        public MapItem(StateCommand com, string[] values)
        {
            this.NextCommand = com;
            this.Values = values;
        }
    }
}
