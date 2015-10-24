using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class CopyTo : ICommand
    {
        private uint memoryIndex;

        public CopyTo(uint memoryIndex)
        {
            this.memoryIndex = memoryIndex;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
           memory.Set(memory.Local.Type, memory.Local.GetValue(memory.Local.Type), memoryIndex);
        }
    }
}
