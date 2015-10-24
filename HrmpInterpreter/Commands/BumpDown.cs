using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class BumpDown : ICommand
    {
        private uint memoryIndex;

        public BumpDown(uint memoryIndex)
        {
            this.memoryIndex = memoryIndex;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            int local;
            if (memory.Local == null)
            {
                throw new InvalidOperationException("BumpDown: Local cannot be null.");
            }
            else
            {
                local = (int)memory.Local.GetValue(MemoryType.Int);
            }

            int register = (int)memory.Get(memoryIndex).GetValue(MemoryType.Int);

            memory.Local = new MemorySlot(MemoryType.Int, local - 1);
            memory.Set(MemoryType.Int, register - 1, memoryIndex);
        }
    }
}
