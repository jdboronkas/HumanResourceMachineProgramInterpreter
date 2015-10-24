using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter.Commands
{
    public interface ICommand
    {
        void Execute(ExecutionNodes nodes, ref Memory memory);
    }
}
