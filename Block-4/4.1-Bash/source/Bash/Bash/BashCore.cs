using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using static Bash.CommandParser;
using static Bash.InputParser;
using static System.Net.Mime.MediaTypeNames;

namespace Bash
{
    class BashCore
    {
        public int LastRunCommandStatus = 0;

        public void RunBash()
        {
            InputParser inputParser = new InputParser();
            CommandParser commandParser = new CommandParser();

            List<(string Command, Priorities Priority)> commands_list;
            CurrentCommand? current_command;

            string command_output;

            while (true)
            {
                Console.Write(": ");

                commands_list = inputParser.InputParse(Console.ReadLine());

                if (commands_list != null)
                {
                    foreach (var command in commands_list)
                    {
                        if ((command.Priority == Priorities.Always) ||
                            (command.Priority == Priorities.And && LastRunCommandStatus == 0) ||
                            (command.Priority == Priorities.Or && LastRunCommandStatus != 0))
                        {
                            current_command = commandParser.CommandParse(command.Command);

                            if (current_command != null)
                            {
                                command_output = RunCommand(current_command.Command.Split(' '));

                                if (command_output != "" &&
                                    current_command.Direction == Direction.None)
                                {
                                    Console.WriteLine(command_output);
                                }
                                else if (current_command.Direction == Direction.Quote)
                                {
                                    try
                                    {
                                        using (StreamWriter fileWriter = new StreamWriter(current_command.Filename, false))
                                        {
                                            fileWriter.WriteLine(command_output);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid file path");
                                    }

                                }
                                else if (current_command.Direction == Direction.Doublequote)
                                {
                                    try
                                    {
                                        using (StreamWriter fileWriter = new StreamWriter(current_command.Filename, true))
                                        {
                                            fileWriter.WriteLine(command_output);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid file path");
                                    }

                                }
                                else if (command_output != "" &&
                                    current_command.Direction == Direction.Backquote)
                                {
                                    Console.WriteLine(command_output);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid argument");
                            }
                        }
                    }
                }
            }
        }
        

        private string RunCommand(string[] commands)
        {
            string output = "";

            switch (commands[0].ToLower())
            {
                case "pwd":

                    string pwd = Directory.GetCurrentDirectory();

                    if (commands.Length == 1)
                    {
                        output += pwd;
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "cat":

                    if (commands.Length == 1)
                    {
                        output += "Invalid argument (File path required)";
                        LastRunCommandStatus = -1;
                    }
                    else if (commands.Length == 2)
                    {
                        try
                        {
                            using (var stream_reader = new StreamReader(commands[1]))
                            {
                                var filetext = stream_reader.ReadToEnd();
                                output += filetext;
                                LastRunCommandStatus = 0;
                            }
                        }
                        catch (Exception e)
                        {
                            output += "Invalid file path";
                            LastRunCommandStatus = -1;
                        }
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }
                    break;

                case "echo":

                    if (commands.Length == 1)
                    {
                        LastRunCommandStatus = 0;
                    }
                    else if (commands.Length == 2)
                    {
                        output += commands[1];
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "true":

                    if (commands.Length == 1)
                    {
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "false":

                    if (commands.Length == 1)
                    {
                        LastRunCommandStatus = -1;
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "$?":

                    if (commands.Length == 1)
                    {
                        output += LastRunCommandStatus.ToString();
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;
                    }

                    break;

                case "wc":

                    if (commands.Length == 1)
                    {
                        output += "Invalid argument (File path required)";
                        LastRunCommandStatus = -1;
                    }
                    else if (commands.Length == 2)
                    {
                        int lines_count = 0;
                        int words_count = 0;
                        long bytes_count = 0;
                        string filepath = commands[1];
                        try
                        {
                            using (var stream_reader = new StreamReader(filepath))
                            {
                                string str;
                                while ((str = stream_reader.ReadLine()) != null)
                                {
                                    lines_count++;
                                    string[] str_array = str.Split(' ');
                                    words_count += str_array.Length;
                                }
                            }

                            bytes_count = new FileInfo(filepath).Length;

                            output += $"{lines_count} lines, {words_count} words, {bytes_count} bytes.";
                            LastRunCommandStatus = 0;
                        }
                        catch (Exception e)
                        {
                            output += "Invalid file path";
                            LastRunCommandStatus = -1;
                        }
                    }
                    else
                    {
                        output += "Invalid argument (Excess of arguments)";
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                default:

                    output += "Unknown command";
                    LastRunCommandStatus = -1;

                    // todo

                    break;
            }

            return output;
        }
    }
}