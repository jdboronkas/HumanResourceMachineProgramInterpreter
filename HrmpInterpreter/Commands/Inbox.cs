using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class Inbox : ICommand
    {
        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            Console.Write("INBOX > ");
            string input = Console.ReadLine();

            int intResult;
            char charResult;
            if (int.TryParse(input, out intResult))
            {
                memory.Local = new MemorySlot(MemoryType.Int, intResult);
            }
            else if (char.TryParse(input, out charResult))
            {
                memory.Local = new MemorySlot(MemoryType.Char, charResult);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Inbox: Cannot parse `{0}`.", input));
            }
        }
    }
}
