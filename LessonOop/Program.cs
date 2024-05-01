using System.Reflection;

namespace LessonOop
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Labirynth.Start();
            //------------------------------------------------------------------------------

            //int targetSum = 1;
            //int[] array = new int[] { 1, 2, 5, 10, 2, 6, 7, 5, 3, 5 };

            //Lesson4 l4 = new(targetSum, array);

            //l4.PrintNumbersResult();
            //------------------------------------------------------------------------------

            ConsoleKeyInfo key = new();
            double input = 0;

            Calculator calculator = new();
            calculator.Result += Calculator_Result;
            PrintConsole($"Результат: {input}");

            while (true)
            {
                
                key = Console.ReadKey();

                if(key.Key == ConsoleKey.Escape)
                    return;

                string? str = Console.ReadLine();
                if (str == string.Empty)
                    return;
                double.TryParse(str, out input);

                switch(key.Key)
                {
                    case ConsoleKey.OemPlus:
                        calculator.Add(input);
                        break;
                    case ConsoleKey.OemMinus:
                        calculator.Sub(input);
                        break;
                    case ConsoleKey.D8:
                        calculator.Mul(input);
                        break;
                    case ConsoleKey.Oem2:
                        calculator.Div(input);
                        break;
                }

            }

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
    }
}