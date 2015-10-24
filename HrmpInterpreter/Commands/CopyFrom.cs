using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class CopyFrom : ICommand
    {
        private uint memoryIndex;

        public CopyFrom(uint memoryIndex)
        {
            this.memoryIndex = memoryIndex;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            memory.Local = memory.Get(memoryIndex);
        }
    }
}
