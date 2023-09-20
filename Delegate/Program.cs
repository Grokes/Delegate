using System.Timers;

namespace Program
{
    internal class Program
    {
        public delegate double Sum(double first, double second); 
        public delegate T[] Even<T>(T[] arr); 
        static void Main(string[] args)
        {
            //1
            Sum test = (first, second) => first + second;
            Console.WriteLine(test(1,4));
            //2
            Action<string> test2 = delegate (string message)
            {
                Console.WriteLine(message.ToUpper());
            };
            test2("stroka");
            //3
            Even<int> test3 = (int[] arr) => arr.Where(el => el % 2 == 0).ToArray();
            int[] array = new int[] {1,2,3,4,5,6 };
            foreach (var el in test3(array))
            {
                Console.Write($"{el}, ");
            }
            Console.WriteLine();
            //4
            string[] str = new string[] { "123", "456", "789" };
            Func<string[], int> test4 = delegate (string[] str)
            {
                return str.Sum(el => el.Length);
            }; 
            Console.WriteLine(test4(str));
            //5
            int[] array2 = new int[] { 1, 2, 3, 4, 5, 6 };
            Func<int[], double> test5 = delegate (int[] arr)
            {
                return arr.Average();
            };
            Console.WriteLine(test5(array2));
            //6
            Func<string[], string[]> test6 = strArr =>
            {
                for (int i = 0; i < strArr.Length; ++i)
                {
                    if (strArr[i].Length > 0)
                    {
                        string temp = strArr[i].Substring(0, 1).ToUpper();
                        if (strArr[i].Length > 1)
                        {
                            temp += strArr[i].Substring(1, strArr[i].Length - 1).ToLower();
                        }
                        strArr[i] = temp;
                    }
                }
                return strArr;
            };
            foreach (var el in test6(new string[] { "sdjfs","sdjf;sjdf;sjdf","erwd"}))
            {
                Console.WriteLine(el);
            }
            //7
            Func<string[], string[]> test7 = strArr => strArr.Where(el => el.All(char.IsUpper)).ToArray();
            foreach (var el in test7(new string[] { "ONE", "WO R", "three" }))
            {
                Console.WriteLine(el);
            }
        }
    }
}