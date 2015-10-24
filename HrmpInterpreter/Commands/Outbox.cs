using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class Outbox : ICommand
    {
        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            Console.WriteLine(string.Format("OUTBOX > {0}", memory.Local.GetValue(memory.Local.Type)));
        }
    }
}
