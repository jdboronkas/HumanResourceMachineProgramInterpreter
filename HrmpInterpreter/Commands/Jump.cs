using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class Jump : ICommand
    {
        private string Label;

        public Jump(string label)
        {
            Label = label;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            ExecutionNode en;
            if (nodes.TryGetValue(Label, out en) == false)
            {
                throw new ArgumentException("Jump: Label " + Label + " does not exist.");
            }

            en.Execute(nodes, ref memory);
        }
    }
}
