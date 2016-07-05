using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = new[] { 1, 5, 7, 3, 8, 10, 34, 12 };
            for (int outer = 0; outer < numbers.Length - 1; outer++)
            {
                var minNumberIndex = outer;
                for (int inner = outer + 1; inner < numbers.Length; inner++)
                {
                    if (numbers[inner] < numbers[minNumberIndex])
                    {
                        minNumberIndex = inner;
                    }
                }

                var temp = numbers[minNumberIndex];
                numbers[minNumberIndex] = numbers[outer];
                numbers[outer] = temp;
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
