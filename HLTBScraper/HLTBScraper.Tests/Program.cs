using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLTBScraper.Objects;
using HLTBScraper.Processors;
using HLTBScraper.Processors.Objects;

namespace HLTBScraper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var gd = new GameData();
            var processor = new StateProcessor(ProcessState.Start);

            processor.Enumerate(ref gd);
        }
    }
}
