using System.Text;
using static System.Math;

namespace OOP
{
    public partial class Course
    { 
        public string Teacher { get; set; }

        partial void Validate()
        {
            Console.WriteLine("Validation...");
        }

        public class ResetCounter // nested class - нарушает инкапсуляцию
        {
            public void Reset()
            {
                Course.counter = 0;
            }
        }
    }




    public static class StringExt 
    {
        // extension method
        public static string Capitalize(this string s)
        {
            string[] words = s.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Length > 0)
                    stringBuilder.Append(char.ToUpper(word[0]))
                        .Append(word.Substring(1).ToLower())
                        .Append(' ');
            }
            return stringBuilder.ToString();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string s = "hello sergey"; // Capitalize(s) == "Hello Sergey"
            Console.WriteLine(StringExt.Capitalize(s));
            Console.WriteLine(s.Capitalize());

            Course.ShowCoursesCounter();
            
            Course c1 = new Course() { Description = "Введение в программирование под .net языке C#"};
            //var c1 = new Course();
            //Course c1 = new ();
            //c1.Title = "Язык C#";
            //c1.Length = 140;
            c1.Length = 40; // call set
            Console.WriteLine(c1.Length); // call get
            //c1.Title = "abc";

            //Course c2 = new Course() { Title = "OOP Patterns", Length = 24 };
            Course c2 = new Course("OOP Patterns", 24) 
                { Description = "Шаблоны объектно-ориентированного программирования"};
            //c2.Title = "OOP Patterns";
            //c2.Length = 24;

            

            c1.Show(); // this == c1
            c2.Show(); // this == c2

            Console.WriteLine(c1.ToString());

            Course.ShowCoursesCounter();
            //c1 = null;
            //GC.Collect();

            // y = sin(log(x*PI));
            double x = 5;
            //double y = Math.Sin(Math.Log(x * Math.PI));
            double y = Sin(Log(x * PI));

            //new Course.ResetCounter().Reset();
            var rc = new Course.ResetCounter();
            rc.Reset();

            Course.ShowCoursesCounter();

            var person = new { Name = "Sergey", Age = 47 };
            
            Console.WriteLine(person);
            Console.WriteLine($"{person.Name} - {person.Age}");

        }
    }
}
