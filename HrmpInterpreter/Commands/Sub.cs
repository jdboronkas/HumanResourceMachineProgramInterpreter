using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class Sub : ICommand
    {
        private uint memoryIndex;

        public Sub(uint memoryIndex)
        {
            this.memoryIndex = memoryIndex;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            int rhv;
            if (memory.Local == null)
            {
                throw new InvalidOperationException("Sub: Local cannot be null.");
            }
            else
            {
                rhv = (int)memory.Local.GetValue(MemoryType.Int);
            }

            int lhv = (int)memory.Get(memoryIndex).GetValue(MemoryType.Int);

            memory.Local = new MemorySlot(MemoryType.Int, lhv - rhv);
        }
    }
}
