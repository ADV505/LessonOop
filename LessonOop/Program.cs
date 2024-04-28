using System.Reflection;

namespace LessonOop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Labirynth.Start();

            int targetSum = 1;
            int[] array = new int[] { 1, 2, 5, 10, 2, 6, 7, 5, 3, 5 };

            Lesson4 l4 = new(targetSum, array);

            l4.PrintNumbersResult();

        }

    }
}