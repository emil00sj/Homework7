using System;
using System.IO;

namespace Tumakov
{
    internal class Program
    {
        private static bool IsIFormattable(object obj)
        {
            return obj is IFormattable && ((IFormattable)obj).ToString(null, null) != null;
        }
        static string ReverseString(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
        static void Main(string[] args)
        {
            /* Упражнение 8.2) Реализовать метод, который в качестве входного параметра принимает
            строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            Протестировать метод */
            Console.Write("Упражнение 8.3) \nВведите строку: ");
            Console.WriteLine(ReverseString(Console.ReadLine()));

            /* Упражнение 8.3) Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами */
            Console.WriteLine("Упражнение 8.3)");
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл {fileName} не найден.");
                return;
            }
            StreamReader reader = new StreamReader(fileName);
            string content = reader.ReadToEnd();
            reader.Close();
            content = content.ToUpper();
            File.WriteAllText("output.txt", content);
            Console.WriteLine($"{fileName} записан заглавными буквами в output.txt");

            /* Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр
            метода интерфейс System.IFormattable. Использовать оператор is и as */
            // Пример использования метода IsIFormattable
            Console.WriteLine("Введите объект для проверки:");
            object obj = Console.ReadLine();
            if (IsIFormattable(obj))
            {
                Console.WriteLine("{0} реализует интерфейс IFormattable", obj);
            }
            else
            {
                Console.WriteLine("{0} не реализует интерфейс IFormattable", obj);
            }
            Console.ReadKey();
        }
    }
}
