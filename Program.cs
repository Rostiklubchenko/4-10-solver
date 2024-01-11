using System.Data;
using System.Diagnostics;

namespace _4_10
{
    internal class Program
    {
        static int[] nums = new int[4];
        static char[,] op_comb =
        {
            {'+', '+', '+'},
            {'+', '+', '-'},
            {'+', '+', '*'},
            {'+', '+', '/'},
            {'+', '-', '+'},
            {'+', '-', '-'},
            {'+', '-', '*'},
            {'+', '-', '/'},
            {'+', '*', '+'},
            {'+', '*', '-'},
            {'+', '*', '*'},
            {'+', '*', '/'},
            {'+', '/', '+'},
            {'+', '/', '-'},
            {'+', '/', '*'},
            {'+', '/', '/'},
            {'-', '+', '+'},
            {'-', '+', '-'},
            {'-', '+', '*'},
            {'-', '+', '/'},
            {'-', '-', '+'},
            {'-', '-', '-'},
            {'-', '-', '*'},
            {'-', '-', '/'},
            {'-', '*', '+'},
            {'-', '*', '-'},
            {'-', '*', '*'},
            {'-', '*', '/'},
            {'-', '/', '+'},
            {'-', '/', '-'},
            {'-', '/', '*'},
            {'-', '/', '/'},
            {'*', '+', '+'},
            {'*', '+', '-'},
            {'*', '+', '*'},
            {'*', '+', '/'},
            {'*', '-', '+'},
            {'*', '-', '-'},
            {'*', '-', '*'},
            {'*', '-', '/'},
            {'*', '*', '+'},
            {'*', '*', '-'},
            {'*', '*', '*'},
            {'*', '*', '/'},
            {'*', '/', '+'},
            {'*', '/', '-'},
            {'*', '/', '*'},
            {'*', '/', '/'},
            {'/', '+', '+'},
            {'/', '+', '-'},
            {'/', '+', '*'},
            {'/', '+', '/'},
            {'/', '-', '+'},
            {'/', '-', '-'},
            {'/', '-', '*'},
            {'/', '-', '/'},
            {'/', '*', '+'},
            {'/', '*', '-'},
            {'/', '*', '*'},
            {'/', '*', '/'},
            {'/', '/', '+'},
            {'/', '/', '-'},
            {'/', '/', '*'},
            {'/', '/', '/'}
        };
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter nums:");
            int num = int.Parse(Console.ReadLine());
            nums[0] = num / 1000;
            nums[1] = (num % 1000) / 100;
            nums[2] = (num % 100) / 10;
            nums[3] = num % 10;
            Console.WriteLine(nums[0] + " " + nums[1] + " " + nums[2] + " " + nums[3]);

            GeneratePermutations(nums, 0, nums.Length - 1);
            Console.ReadLine();
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
        }

        static void Calculate(int[] combination, int comb)
        {
            string[] input = {
                combination[0].ToString() + op_comb[comb, 0] + combination[1].ToString() + op_comb[comb, 1] + combination[2].ToString() + op_comb[comb, 2] + combination[3].ToString(),
                "(" + combination[0].ToString() + op_comb[comb, 0] + combination[1].ToString() + ")" + op_comb[comb, 1] + "(" + combination[2].ToString() + op_comb[comb, 2] + combination[3].ToString() + ")",
                "(" + combination[0].ToString() + op_comb[comb, 0] + combination[1].ToString() + ")" + op_comb[comb, 1] + combination[2].ToString() + op_comb[comb, 2] + combination[3].ToString(),
                combination[0].ToString() + op_comb[comb, 0] + "(" + combination[1].ToString() + op_comb[comb, 1] + combination[2].ToString() + ")" + op_comb[comb, 2] + combination[3].ToString(),
                combination[0].ToString() + op_comb[comb, 0] + combination[1].ToString() + op_comb[comb, 1] + "(" + combination[2].ToString() + op_comb[comb, 2] + combination[3].ToString() + ")",
                "(" + combination[0].ToString() + op_comb[comb, 0] + combination[1].ToString() + op_comb[comb, 1] + combination[2].ToString() + ")" + op_comb[comb, 2] + combination[3].ToString(),
                combination[0].ToString() + op_comb[comb, 0] + "(" + combination[1].ToString() + op_comb[comb, 1] + combination[2].ToString() + op_comb[comb, 2] + combination[3].ToString() + ")"
            };
            for (int i = 0; i < 7; i++)
            {
                //Console.WriteLine(input[i]);
                try
                {
                    DataTable table = new DataTable();
                    var result = table.Compute(input[i], "");
                    //Console.WriteLine($"Результат: {result}");
                    //if (Object.Equals(result, 10))
                    string res_str = result.ToString();
                    if (res_str == "10")
                    Console.WriteLine(input[i] + "=" + result);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            
        }

        static void GeneratePermutations(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                Console.WriteLine();
                Console.WriteLine($"({string.Join(", ", numbers)})");
                for (int i = 0; i < 64; i++)
                {
                    Calculate(numbers, i);
                }
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Swap(ref numbers[startIndex], ref numbers[i]);
                    GeneratePermutations(numbers, startIndex + 1, endIndex);
                    Swap(ref numbers[startIndex], ref numbers[i]);
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}

