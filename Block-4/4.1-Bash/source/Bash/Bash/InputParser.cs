using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bash
{
    internal class InputParser
    {

        private static string[] separators = { "&&", "||", ";" };

        public enum Priorities
        {
            Always, And, Or
        };

        public List<(string, Priorities)> Parse(string? commands)
        {
            commands = commands.Trim();
            if (commands.Length == 0)
            {
                return null;
            }

            var commands_parsed_with_connectors = new List<(string Command, Priorities Priority)>();

            var commands_splited = commands.Split(separators, StringSplitOptions.None);

            int position = 0;

            if (commands_splited[0] != "")
                commands_parsed_with_connectors.Add((commands_splited[0].Trim(), Priorities.Always));
            else
                return null;

            for (int i = 1; i < commands_splited.Length; i++)
            {
                if (commands_splited[i] == "")
                    return null;

                position += commands_splited[i - 1].Length;

                char current_connector = commands[position];

                if (current_connector == ';')
                {
                    position += 1;
                    commands_parsed_with_connectors.Add((commands_splited[i].Trim(), Priorities.Always));
                }
                else if (current_connector == '&')
                {
                    position += 2;
                    commands_parsed_with_connectors.Add((commands_splited[i].Trim(), Priorities.And));
                }
                else if (current_connector == '|')
                {
                    position += 2;
                    commands_parsed_with_connectors.Add((commands_splited[i].Trim(), Priorities.Or));
                }
            }

            return commands_parsed_with_connectors;
        }
    }
}
