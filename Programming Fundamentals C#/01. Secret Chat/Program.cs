using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //На първия ред на входа ще получите скритото съобщение.След това, докато не бъде дадена командата "Разкриване", ще получите низове с инструкции за различни операции, които трябва да бъдат извършени върху скритото съобщение, за да го интерпретирате и разкриете действителното му съдържание.Има няколко типа инструкции, разделени от ":|:"
            //• "InsertSpace:|:{index}":
            //o Вмъква единичен интервал в дадения индекс.Посоченият индекс винаги ще бъде валиден.
            //• "Обратно:|:{подниз}":
            //o Ако съобщението съдържа дадения подниз, изрежете го, обърнете го и го добавете в края на съобщението.
            //o Ако не, отпечатайте "error".
            //o Тази операция трябва да замени само първото появяване на дадения подниз, ако има две или повече поява.
            //• "Промяна на всички:|:{подниз}:|:{замяна}":
            //o Променя всички срещания на дадения подниз със заместващия текст.
            //Вход / Ограничения
            //• На първия ред ще получите низ със съобщение.
            //• На следните редове ще получавате команди, разделени от ":|:".
            //Изход
            //• След всеки набор от инструкции отпечатайте получения низ.
            //• След като бъде получена командата "Разкриване", отпечатайте това съобщение:
            //„Имате ново текстово съобщение: { message}“
            string input = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] arg = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = arg[0];
                if (action == "InsertSpace")
                {
                    int index = int.Parse(arg[1]);
                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                }

                else if (action == "Reverse")
                {
                    if (!input.Contains(arg[1]))
                    {
                        Console.WriteLine("error");

                    }
                    else
                    {
                        string search = arg[1];
                        var reversedSubstr = string.Empty;
                        var index = input.IndexOf(search);

                        input = input.Remove(index, search.Length);

                        for (int i = search.Length - 1; i >= 0; i--)
                        {
                            reversedSubstr += search[i];
                        }

                        input = input.Insert(input.Length, reversedSubstr);
                        Console.WriteLine(input);
                    }
                }
                else if (action == "ChangeAll")
                {
                    string oldsymbol = arg[1];
                    string newsymbol = arg[2];
                    input = input.Replace(oldsymbol, newsymbol);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
        }
    }
}
