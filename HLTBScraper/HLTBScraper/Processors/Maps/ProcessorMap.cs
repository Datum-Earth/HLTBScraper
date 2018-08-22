using HLTBScraper.Processors.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLTBScraper.Processors.Maps
{
    internal class ProcessorMap
    {
        private Dictionary<ProcessState, MapItem> Maps { get; set; }

        public ProcessorMap()
        {
            InitializeMaps();
        }
        private void InitializeMaps()
        {
            this.Maps = new Dictionary<ProcessState, MapItem>()
            {
                { ProcessState.Start, new MapItem(StateCommand.Forward, new string[1]{ "[STARTPROCESS]" })},
                { ProcessState.MainTables, new MapItem(StateCommand.Forward, new string[1]{ ".game_main_table" }) },
                { ProcessState.Terminated, null }, //if the state machine is in a terminated state, then we're finished doing work
                { ProcessState.BodyTables, new MapItem(StateCommand.Forward, new string[2]{ ".back_lighter", ".spreadsheet" } ) },
                { ProcessState.Rows, new MapItem(StateCommand.Forward, new string[1]{ "tr" }) },
                { ProcessState.Elements , new MapItem(StateCommand.Backward, new string[1]{ "td" }) }
            };
        }

        public MapItem GetValues(ProcessState state)
        {
            return Maps[state];
        }
    }
}
