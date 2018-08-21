using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors.Objects
{
    internal enum ProcessState
    {
        Start,
        MainTables,
        BodyTables,
        Rows,
        Elements,
        End,
        Terminated
    }
}
