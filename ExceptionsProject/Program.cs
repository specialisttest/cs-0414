using System.Diagnostics;
using System.Numerics;

namespace ExceptionsProject
{
    internal class Program
    {
        static void Test(string s1, string s2) 
        {
            try
            {
                int n1 = int.Parse(s1);
                int n2 = int.Parse(s2);

                if (n1 < 0 || n1 > 100)
                    //throw new ArgumentOutOfRangeException("n1 out of [0..100]");
                    throw new MyException(n1, "n1 out of [0..100]");

                int n = n1 / n2;

                Console.WriteLine(n);
            }
            catch (MyException e) when (e.InvalidData >= 0)
            {
                Console.WriteLine($"{e.Message} Invalid data: {e.InvalidData}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
                //throw; // throw ex;
                throw new Exception("Error", ex);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Не число");
            }
            finally 
            {
                Console.WriteLine("Test() finally");
            }


            Console.WriteLine("продолжение Test()");
        }
        static void Main(string[] args)
        {
            try
            {
                Test("23", "4");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                // Debug.WriteLine(e.ToString()); // при запуске под отладчиком
                Trace.WriteLine(e.ToString());
            }


            Console.WriteLine("продолжение Main()");

            try { }
            finally { }

            checked
            {
                int m = int.MaxValue;
                Console.WriteLine(m);
                //int k = checked(m + 1); // unchecked
                int k = m + 1;
                Console.WriteLine(k);
            }
            
        }
    }
}
