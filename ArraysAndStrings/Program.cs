using System.Text;
using System.Text.RegularExpressions;

namespace ArraysAndStrings
{
    internal class Program
    {

        /*Span<int>*/ void Test()
        {
            Span<int> s= stackalloc int[2] { 1, 2 };
            // return s; // compile
        
        }
        static void Main(string[] args)
        {
            int[] ab = null;

            //Console.WriteLine("Введите размер массива: ");
            //int k = int.Parse(Console.ReadLine());

            //const int k = 5;
            //int[] a = new int[k];
            //int[] a = new int[3] { 100, 200, 300 };
            //int[] a = new int[] { 100, 200, 300 };
            int[] a = { 100, 200, 300 }; // new int[]

            Console.WriteLine($"Количество элементов: {a.Length}"); // LongLength


            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);

            //for (int i = 0; i < a.Length; i++)
            //    a[i]++;
            //foreach (int k in a)
            //    k++; // compile error

            foreach (int k in a)
                Console.WriteLine(k);

            int[,] matrix = //new int[2, 3]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 }
                };
            // matrix.Rank
            //matrix.GetLength(0)
            //matrix.GetLongLength(0)

            Console.WriteLine($"Matrix Rank: {matrix.Rank}");
            Console.WriteLine($"Matrix Length: {matrix.Length}");
            
            for(int i = 0;i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                    Console.Write("{0, 4}", matrix[i,j]);
                Console.WriteLine();
            }

            int[][] jagged =
                {
                    new int[] { 1, 2, 3 },
                    new int[] { 4, 5 }
                };

            Console.WriteLine($"Jagged Rank: {jagged.Rank}");
            Console.WriteLine($"Jagged Length: {jagged.Length}");

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                    Console.Write("{0, 4}", jagged[i][j]);
                Console.WriteLine();
            }

            int[] d = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] dd = d; // copy ref
            int[] dd = d[..]; // copy array
            dd[0]++;

            d[..][2]++;
            Range r = 2..5; // индексы 2 3 4
            int[] d1 = d[r]; // извлекаем элементы с индексами из диапазона r
            d1[0]++;
            foreach (int k1 in d1) Console.WriteLine(k1); // 2 3 4
            
            int[] d2 = d[2..^2]; // от 2 с начала до 2 с конца
            foreach (int k2 in d2) Console.WriteLine(k2);

            foreach (int k1 in d) Console.WriteLine(k1);

            //Span<int> stackMassive = stackalloc int[5] { 100, 200, 3004, 4, 500 };
            Span<int> stackMassive = [100, 200, 3004, 4, 500];
            foreach (int element in stackMassive)
                Console.WriteLine(element);

            string n = string.Empty;
            string s = "Sergey";
            // s.Length
            string ss = "Привет, " + s + "!";
            // "Sergey"
            // "Привет, "
            // "!"
            // "Привет, Sergey"
            // "Привет, Sergey!"

            Program p =new Program();
            Console.WriteLine(p.ToString());

            string name = "Sergey,Andrey,Alex";
            string[] names = name.Split(',');
            Array.Sort(names);
            foreach (var nm in names) Console.WriteLine(nm);

            string numStr = "gsdf123";
            //int num = int.Parse(numStr); // Convert.ToInt32(numStr)
            // double.Parse(numStr)

            int num;
            if (int.TryParse(numStr, out num))
                Console.WriteLine($"Число: {num}");
            else
                Console.WriteLine("Не число");

            // 1 2 3 4 5 ... 100
            
            // BAD
            //string result = string.Empty;
            //for (int i = 1; i <= 100; i++)
            //    result += i.ToString() + " ";
            

            // "" " " "1" "1 " "1 2"

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 100; i++)
                sb.Append(i).Append(' ');

            string result = sb.ToString();

            Console.WriteLine(result);

            //string.Format("Hello {0}", name)
            //$"Hello, {name}"

            string phone = "499 023-56-67";
            Regex reg = new Regex(@"\d{3} [1..9]\d{2}-\d{2}-\d{2}");

            if (reg.IsMatch(phone))
                Console.WriteLine(phone);
            else
                Console.WriteLine("Wrong phone format");
        }

        public override string ToString()
        {
            return "My program";
        }
    }
}
