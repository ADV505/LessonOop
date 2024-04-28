
//Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
//Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.


namespace LessonOop
{
    public class Lesson4
    {
        readonly int targetSum;
        readonly int[] array;

        public Lesson4(int target, int[] arr)
        {
            this.targetSum = target;
            this.array = arr;
        }


        public void PrintNumbersResult()
        {
            Array.Sort(array);

            int leftIndex = 0;
            int middleIndex = 1; 
            int rightIndex = array.Length - 1; 

            while (leftIndex < rightIndex - 1)
            {
                int sum = array[leftIndex] + array[middleIndex] + array[rightIndex];
                if (sum == targetSum)
                {
                    Console.WriteLine($"Найдено три числа: {array[leftIndex]}, {array[middleIndex]}, {array[rightIndex]}");
                    break;
                }
                else if (sum < targetSum)
                {
                    middleIndex++;
                }
                else
                {
                    rightIndex--;
                }

            }
            if (leftIndex >= rightIndex - 1)
                Console.WriteLine("В массиве нет таких чисел");
        }
    }
}
