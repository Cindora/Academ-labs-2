using static Bash.InputParser;

namespace Bash
{
    internal class BashStart
    {
        public void Start()
        {
            Console.WriteLine("Доступные команды:\n\n" +

                              "pwd - отобразить текущий рабочий каталог\n" +
                              "cat [FILENAME] - вывести содержимое файла по станд. каналу вывода\n" +
                              "echo [INPUT]   - вывести свои аргументы по станд. каналу вывода\n\n" +

                              "true  - возврат нуля (успех)\n" +
                              "false - возврат не-ноля (неудача)\n\n" +

                              "$? - переменная, содержащая код возврата последней запущенной команды\n" +
                              "(not implemented) $  - присваивание и использование локальных переменных сессии\n\n" +

                              "&& – Первая команда исполняется всегда, вторая — в случае успешного завершения первой\n" +
                              "|| – Первая команда исполняется всегда, вторая — в случае неудачного завершения первой\n" +
                              ";  – Команды исполняются всегда\n\n" +

                              "[OUTPUT] > [FILENAME]  – создаёт файл и записывает в него вывод\n" +
                              "[OUTPUT] >> [FILENAME] – дописывает вывод в конец файла\n" +
                              "[OUTPUT] < [FILENAME]  – стандартное перенаправления вывода\n\n" +

                              "wc [FILENAME] – показывает на экране количество строк, слов и байт в файле\n\n");

            BashCore BashCore = new BashCore();
            BashCore.RunBash();
        }
    }

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
                                command_output = RunCommand(current_command.Command);

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
        

        private string RunCommand(string command)
        {
            string[] commands = command.Split(' ');
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
                    }

                    break;

                case "echo":

                    if (commands.Length == 1)
                    {
                        LastRunCommandStatus = 0;
                    }
                    else
                    {
                        output += command.Substring(5);

                        LastRunCommandStatus = 0;
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
                    }

                    break;

                default:

                    output += "Unknown command";
                    LastRunCommandStatus = -1;

                    break;
            }

            return output;
        }
    }
}