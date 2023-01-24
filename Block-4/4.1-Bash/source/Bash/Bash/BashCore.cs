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
            List<(string Command, Priorities Priority)> commands_list;
            CurrentCommand? current_command;

            while (true)
            {
                Console.Write(": ");

                //commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                InputParser parser = new InputParser();

                commands_list = parser.InputParse(Console.ReadLine());

                CommandParser commandParser = new CommandParser();
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
                                RunCommand(current_command.Command.Split(' '));
                            }
                            else
                            {
                                Console.WriteLine("Invalid argument");
                            }
                            
                        }
                        
                    }
                }

                //int commands_length = commands.Length;

                //if (commands.Length != 0)
                //{
                //    RunCommand(commands);
                //}


                //foreach (string el in commands)
                //{
                //    Console.WriteLine(el);
                //}
            }


        }

        private void RunCommand(string[] commands)
        {
            switch (commands[0].ToLower())
            {
                case "pwd":

                    string pwd = Directory.GetCurrentDirectory();

                    if (commands.Length == 1)
                    {
                        Console.WriteLine(pwd);
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument (Excess of arguments)");
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "cat":

                    if (commands.Length == 1)
                    {
                        Console.WriteLine("Invalid argument (File path required)");
                        LastRunCommandStatus = -1;
                    }
                    else if (commands.Length == 2)
                    {
                        try
                        {
                            using (var stream_reader = new StreamReader(commands[1]))
                            {
                                var filetext = stream_reader.ReadToEnd();
                                Console.WriteLine(filetext);
                                LastRunCommandStatus = 0;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid file path");
                            LastRunCommandStatus = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument (Excess of arguments)");
                        LastRunCommandStatus = -1;

                        // todo
                    }
                    break;

                case "echo":

                    if (commands.Length == 1)
                    {
                        Console.WriteLine();
                        LastRunCommandStatus = 0;
                    }
                    else if (commands.Length == 2)
                    {
                        Console.WriteLine(commands[1]);
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument (Excess of arguments)");
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
                        Console.WriteLine("Invalid argument (Excess of arguments)");
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
                        Console.WriteLine("Invalid argument (Excess of arguments)");
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                case "wc":

                    if (commands.Length == 1)
                    {
                        Console.WriteLine("Invalid argument (File path required)");
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

                            bytes_count = new FileInfo(filepath).Length; //Считаем количество байт в файле

                            Console.WriteLine($"{lines_count} lines, {words_count} words, {bytes_count} bytes.");
                            LastRunCommandStatus = 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid file path");
                            LastRunCommandStatus = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument (Excess of arguments)");
                        LastRunCommandStatus = -1;

                        // todo
                    }

                    break;

                default:

                    Console.WriteLine("Unknown command");
                    LastRunCommandStatus = -1;

                    // todo

                    break;
            }
        }
    }
}