using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter
{
    public class Start
    {
        /// <summary>
        /// Runs a Hrmp program, the user supplies the input for Inbox commands.
        /// Program outputs Outbox commands.
        /// </summary>
        /// <param name="args">args[0] is program file path, args[1] is memory size.</param>
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    HrmpProgram program = new Parser().Parse(args[0]);
                    program.Run(new Memory(uint.Parse(args[1])));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Program Error!");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("FIN - Press any key to exit program...");
                    Console.ReadKey();
                }
            }
        }
    }
}
