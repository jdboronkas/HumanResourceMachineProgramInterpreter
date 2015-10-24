using HrmpInterpreter.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter
{
    public class Parser
    {
        public Parser()
        {
        }

        public HrmpProgram Parse(string filepath)
        {
            HrmpProgram program = null;

            using (StreamReader file = new StreamReader(filepath))
            {
                string lastLabel = null;
                CommandList commandList = new CommandList();

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    ICommand command = ParseLine(line);
                    if (command == null)
                    {
                        // Not a command, check if it is a label for a jump.
                        if (line.EndsWith(":"))
                        {
                            // If there was a previous label, save the current commandList to that ExecutionNode.
                            if (lastLabel != null && program != null)
                            {
                                ExecutionNode en = new ExecutionNode(lastLabel, commandList);
                                program.AddExecutionNode(en);
                            }
                            // Else, create the main ExecutionNode and create the HrmpProgram.
                            else
                            {
                                ExecutionNode en = new ExecutionNode("main", commandList);
                                program = new HrmpProgram(en);
                            }

                            // Clear the current commandList.
                            commandList.Clear();

                            // Save the label for the next ExecutionNode.
                            line = line.Remove(line.Count() - 1);
                            lastLabel = line;
                        }

                        continue;
                    }
                    // Else, it is a command.
                    else
                    {
                        commandList.Add(command);
                    }
                }

                // End of file, so add the current commandList.
                // If there was a previous label, save the current commandList to that ExecutionNode.
                if (lastLabel != null && program != null)
                {
                    ExecutionNode en = new ExecutionNode(lastLabel, commandList);
                    program.AddExecutionNode(en);
                }
                // Else, create the main ExecutionNode and create the HrmpProgram.
                else
                {
                    ExecutionNode en = new ExecutionNode("main", commandList);
                    program = new HrmpProgram(en);
                }

                file.Close();
            }

            return program;
        }

        private ICommand ParseLine(string line)
        {
            line = line.ToLower();
            line = line.Trim();
            string[] tokens = line.Split(' ');

            // Empty lines.
            if (tokens.Length <= 0 || tokens[0].Equals(""))
            {
                return null;
            }

            // # and -- are comments
            if (tokens[0].StartsWith("#") || tokens[0].StartsWith("--") || tokens[0].StartsWith("comment"))
            {
                return null;
            }

            // Switch the token for the actual command.
            switch(tokens[0])
            {
                case "inbox":
                    return new Inbox();

                case "outbox":
                    return new Outbox();

                case "copyto":
                    return new CopyTo(uint.Parse(tokens[1]));

                case "copyfrom":
                    return new CopyFrom(uint.Parse(tokens[1]));

                case "add":
                    return new Add(uint.Parse(tokens[1]));

                case "sub":
                    return new Sub(uint.Parse(tokens[1]));

                case "bumpup":
                    return new BumpUp(uint.Parse(tokens[1]));

                case "bumpdn":
                    return new BumpDown(uint.Parse(tokens[1]));

                case "jump":
                    return new Jump(tokens[1]);

                case "jumpz":
                    return new JumpZ(tokens[1]);

                case "jumpn":
                    return new JumpZ(tokens[1]);

                default:
                    return null;
                    //throw new InvalidOperationException(string.Format("Token `{0}` is invalid.", tokens[0]));
            }
        }
    }
}
