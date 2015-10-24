using HrmpInterpreter.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter
{
    public class ExecutionNode
    {
        public string ID { get; private set; }
        protected CommandList commandList;

        public ExecutionNode(string id, CommandList commandList)
        {
            ID = id;
            this.commandList = commandList;
        }

        public void Execute(ExecutionNodes nodes, ref Memory memory)
        {
            foreach (ICommand command in commandList)
            {
                command.Execute(nodes, ref memory);
            }
        }
    }
}
