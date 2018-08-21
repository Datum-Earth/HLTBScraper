using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLTBScraper.Processors;
using HLTBScraper.Processors.Objects;

namespace HLTBScraper.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var trans = new Dictionary<StateTransition, ProcessState>()
            {
                { new StateTransition(ProcessState.Start, StateCommand.Forward), ProcessState.MainTables },
                { new StateTransition(ProcessState.Start, StateCommand.Backward), ProcessState.Terminated },
                { new StateTransition(ProcessState.MainTables, StateCommand.Forward), ProcessState.BodyTables },
                { new StateTransition(ProcessState.MainTables, StateCommand.Backward), ProcessState.Terminated },
                { new StateTransition(ProcessState.BodyTables, StateCommand.Forward), ProcessState.Rows },
                { new StateTransition(ProcessState.BodyTables, StateCommand.Backward), ProcessState.MainTables},
                { new StateTransition(ProcessState.Rows, StateCommand.Forward), ProcessState.Elements },
                { new StateTransition(ProcessState.Rows, StateCommand.Backward), ProcessState.BodyTables },
                { new StateTransition(ProcessState.Elements, StateCommand.Forward), ProcessState.Rows },
                { new StateTransition(ProcessState.Elements, StateCommand.Backward), ProcessState.Rows }
            };

            var mc = new MachineCore(ProcessState.Start, trans);

            while (1 > 0)
            {
                Console.WriteLine($"State | {mc.CurrentState.ToString()}");
                
                var conIn = Console.ReadLine().ToLower();
                StateCommand move;

                switch (conIn)
                {
                    case "forward":
                        move = StateCommand.Forward;
                        break;
                    case "backward":
                        move = StateCommand.Backward;
                        break;
                    default:
                        move = StateCommand.Forward;
                        break;
                }
                        
                mc.MoveNext(move);
            }
        }
    }
}
