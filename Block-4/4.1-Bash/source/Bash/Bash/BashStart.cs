﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
