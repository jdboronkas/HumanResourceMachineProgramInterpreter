using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter
{
    public class HrmpProgram
    {
        private ExecutionNode startNode;
        private ExecutionNodes executionNodes;

        public HrmpProgram(ExecutionNode startNode)
        {
            this.startNode = startNode;
            executionNodes = new ExecutionNodes();
        }

        public void AddExecutionNode(ExecutionNode node)
        {
            if (executionNodes.ContainsKey(node.ID))
            {
                throw new InvalidOperationException(string.Format("AddExecutionNode: ExecutionTree already contains a node with ID `{0}`.", node.ID));
            }

            executionNodes.Add(node.ID, node);
        }

        public void Run(Memory memory)
        {
            startNode.Execute(executionNodes, ref memory);
        }
    }
}
