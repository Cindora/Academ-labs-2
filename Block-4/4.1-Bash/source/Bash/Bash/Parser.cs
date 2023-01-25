namespace Bash
{
    internal class InputParser
    {

        private static string[] separators = { "&&", "||", ";" };

        public enum Priorities
        {
            Always, And, Or
        };

        public List<(string, Priorities)> InputParse(string? commands)
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

    public enum Direction
    {
        Quote, Doublequote, Backquote, None
    };

    public class CurrentCommand
    {
        public string Command;
        public string? Filename;
        public Direction Direction;

        public CurrentCommand(string Command)
        {
            this.Command = Command;
            this.Filename = null;
            this.Direction = Direction.None;
        }

        public CurrentCommand(string Command, string? Filename, Direction Direction)
        {
            this.Command = Command;
            this.Filename = Filename;
            this.Direction = Direction;
        }
    }

    internal class CommandParser
    {

        private static string[] separators = { ">>", ">", "<" };

        public CurrentCommand? CommandParse(string? commands)
        {

            CurrentCommand? commands_parsed_with_directions;

            string[] commands_splited = commands.Split(separators, StringSplitOptions.None);

            int comm_spl_len = commands_splited.Length;

            if (comm_spl_len == 1)
            {
                commands_parsed_with_directions = new CurrentCommand(commands_splited[0].Trim(), null, Direction.None);
                return commands_parsed_with_directions;
            }
            else if (comm_spl_len == 2)
            {
                if (commands.Length >= commands_splited[0].Length + 2 &&
                    commands[commands_splited[0].Length+1] == '>')
                {
                    commands_parsed_with_directions = new CurrentCommand(commands_splited[0].Trim(),
                        commands_splited[1].Trim(), Direction.Doublequote);
                }
                else if (commands[commands_splited[0].Length] == '>')
                {
                    commands_parsed_with_directions = new CurrentCommand(commands_splited[0].Trim(),
                        commands_splited[1].Trim(), Direction.Quote);
                }
                else if (commands[commands_splited[0].Length] == '<')
                {
                    commands_parsed_with_directions = new CurrentCommand(commands_splited[0].Trim(),
                        commands_splited[1].Trim(), Direction.Backquote);
                }
                else
                {
                    return null;
                }
                return commands_parsed_with_directions;
            }
            else
            {
                return null;
            }
        }
    }
}