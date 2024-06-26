﻿using System.Globalization;
using System.Reflection;
using System.Text;

namespace LessonOop
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //byte b = 5;
            //long l = 10;
            //int i = -4;

            //Bits b1 = (Bits)b; //явное

            //Bits bits = b; //неявное
            //Bits bits1 = l;
            //Bits bits2 = i;


            //Labirynth.Start();
            //Lesson4-----------------------------------------------------------start

            //int targetSum = 1;
            //int[] array = new int[] { 1, 2, 5, 10, 2, 6, 7, 5, 3, 5 };

            //Lesson4 l4 = new(targetSum, array);

            //l4.PrintNumbersResult();
            //Lesson4-------------------------------------------------------------end

            //Calculator-----------------------------------------------------------start
            //ConsoleKeyInfo key = new();
            //double input = 0;

            //Calculator calculator = new();
            //calculator.Result += Calculator_Result;
            //PrintConsole($"Результат: {input}");

            //while (true)
            //{

            //    key = Console.ReadKey();

            //    if (key.Key == ConsoleKey.Escape)
            //        return;

            //    string? str = Console.ReadLine();
            //    if (str == string.Empty)
            //        return;
            //    double.TryParse(str, out input);

            //    switch (key.Key)
            //    {
            //        case ConsoleKey.OemPlus:
            //            calculator.Add(input);
            //            break;
            //        case ConsoleKey.OemMinus:
            //            calculator.Sub(input);
            //            break;
            //        case ConsoleKey.D8:
            //            calculator.Mul(input);
            //            break;
            //        case ConsoleKey.Oem2:
            //            calculator.Div(input);
            //            break;
            //        case ConsoleKey.Backspace:
            //            calculator.Cancel();
            //            break;
            //    }
            //}
            //Calculator-----------------------------------------------------------end



            //Lesson-----------------------------------------------------start
            //Lesson7 ls7 = new Lesson7(1, "hi", 2.0m, '$');
            //string str = ObjectToString(ls7);
            //Console.WriteLine(str);

            //var obj = StringToObject(str);

            //Console.WriteLine(ObjectToString(obj));
            //Lesson7-----------------------------------------------------end

            //Lesson8-----------------------------------------------------start
            string path = "D:\\Projekt\\Lection";
            string fileMaskFormat = "*.txt";
            string findText = "Hello";

            Lesson9 l9 = new(path, fileMaskFormat, findText);

            new Thread(Lesson9.FindFile).Start(l9);

            Console.ReadKey();

            //string[] allFiles = Lesson8.FindFile(path, fileMaskFormat);

            //if (allFiles.Length != 0)
            //{
            //    List<string> file = Lesson8.ReaderFile(allFiles, findText);

            //    if (file.Count > 0)
            //    {
            //        foreach (string n in file)
            //        {
            //            Console.WriteLine($"Найден файл - {n} (который содержит искомое слово ({findText}))");
            //        }
            //    }
            //}
            //else
            //    Console.WriteLine($"Файлы с таким расширением ({fileMaskFormat}) не обнаруженны!");

            //Lesson8-----------------------------------------------------end
        }

        public static void PrintConsole(string str)
        {
            // Console.Clear();    
            Console.WriteLine(str);
            Console.WriteLine();

        }
        private static void Calculator_Result(object? sender, CalculatorEventArgs e)
        {
            PrintConsole($"Результат: {e.answer}");
        }

        static string ObjectToString(object obj)
        {
            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();

            sb.Append(type.AssemblyQualifiedName + "\n");
            sb.Append(type.Name + "\n");

            var fields = type.GetProperties();

            foreach (var field in fields)
            {
                sb.Append($"{field.Name}|{field.GetValue(obj)}|{field.PropertyType} \n");
            }
            sb.Length--;

            return sb.ToString();
        }

        static object StringToObject(string str)
        {
            string[] strings = str.Split(new char[] { '\n' });

            var obj = Activator.CreateInstance(null, strings[1])?.Unwrap();

            Type type = obj.GetType();

            for (int i = 2; i < strings.Length; i++)
            {
                string[] prop = strings[i].Split(new char[] { '|' });

                var pi = type.GetProperty(prop[0]);

                if (pi == null)
                    continue;
                else if (pi.PropertyType == typeof(int))
                    pi.SetValue(obj, int.Parse(prop[1]));
                else if (pi.PropertyType == typeof(string))
                    pi.SetValue(obj, prop[1]);
                else if (pi.PropertyType == typeof(decimal))
                    pi.SetValue(obj, decimal.Parse(prop[1]));
                else if (pi.PropertyType == typeof(char))
                    pi.SetValue(obj, char.Parse(prop[1]));


            }

            return obj;
        }
    }
}