using System.Text.RegularExpressions;

namespace RegularExpressionProject
{
    internal class Program
    {
        static double PowerBinReq(double x, int n)
        {
            if (n == 0) return 1;
            if (n % 2 == 1)
                return PowerBinReq(x, n - 1) * x;
            else
            {
                double temp = PowerBinReq(x, n / 2);
                return temp * temp;
            }
        }

        static double PowerBinLoop(double x, int n)
        {
            double result = 1;
            while( n > 0)
            {
                if(n % 2 == 1)
                {
                    result *= x;
                    n--;
                }
                else
                {
                    x *= x;
                    n /= 2; // n >>= 1
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            string[] data = { "привет", "море", "причал", "сказка", "иииооо",
                            "горе", "пример тире", "указка", "молоко" };

            string text = "привет пуск причал упреждение запрет пристав";


            string regstr = @"^пр\w*"; // ищем "пр" в начале строки
            regstr = @"оре$";

            regstr = @"[^ио]";

            Regex regex = new Regex(regstr);
            
            List<string> dataResult = new();

            foreach (string s in data)
                if (regex.IsMatch(s))
                    dataResult.Add(s);

            foreach (string s in dataResult)
                Console.WriteLine($"{s}");

            //var matchesColl = regex.Matches(text);
            //foreach(Match s in matchesColl)
            //    Console.WriteLine($"{s.Index} -> {s.Value}");



            int a = 10;
            int b = 20;

            //int temp = a;
            //a = b;
            //b = temp;

            int N = 20;
            int[] array = new int[N];
            Random random = new();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next() % 100;

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();

            int key = Int32.Parse(Console.ReadLine());
            int index = -1;

            for (int i = 0; i < array.Length; i++)
                if(key == array[i])
                {
                    index = i;
                    break;
                }
            //for(int i = 0; i < array.Length; i++)
            //{
            //    for(int j = array.Length - 1; j > i; j--)
            //        if (array[j] < array[j - 1])
            //        {
            //            int temp = array[j];
            //            array[j] = array[j - 1];
            //            array[j - 1] = temp;
            //        }    
            //}

            int top = 0;
            int bottom = array.Length - 1;
            bool isSort;
            while(top <= bottom)
            {
                isSort = true;
                for (int i = bottom; i > top; i--)
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        isSort = false;
                    }
                if (isSort) break;
                top++;

                isSort = true;
                for (int i = top; i < bottom; i++)
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSort = false;
                    }
                if (isSort) break;
                bottom--;
            }

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();

            double x = 4.5;
            int n = 10;
            double power = 1;
            for (int i = 0; i < n; i++)
                power *= x;
            Console.WriteLine($"{x}^{n} = {power}");


            Console.WriteLine($"{x}^{n} = {PowerBinReq(x, n)}");
            Console.WriteLine($"{x}^{n} = {PowerBinLoop(x, n)}");


        }
    }
}