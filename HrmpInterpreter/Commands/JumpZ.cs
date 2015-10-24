using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public class JumpZ : ICommand
    {
        private string Label;

        public JumpZ(string label)
        {
            Label = label;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            ExecutionNode en;
            if (nodes.TryGetValue(Label, out en) == false)
            {
                throw new ArgumentException("JumpZ: Label " + Label + " does not exist.");
            }

            int? localMaybe = (int?)memory.Local.GetValue(MemoryType.Int);
            if (localMaybe.HasValue)
            {
                int local = localMaybe.GetValueOrDefault();
                if (local == 0)
                {
                    en.Execute(nodes, ref memory);
                }
            }
        }
    }
}
