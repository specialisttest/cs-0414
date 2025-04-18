using System.Transactions;

namespace ExcelProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            dynamic excel = new Microsoft.Office.Interop.Excel.Application();
            
            excel.Visible = true;
            excel.Workbooks.Add();
            Console.ReadLine();

            excel.Quit();
            excel = null;
        }
    }
}
