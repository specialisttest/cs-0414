namespace Events
{
    internal class Program
    {
        static void Fire(object sender, EventArgs e)
        {
            Console.WriteLine("Пожар");
        }
        static void Main(string[] args)
        {
            Switcher sw = new Switcher();
            Lamp lamp = new Lamp();
            TvSet tv = new TvSet();

            // подписка на событие
            //sw.ElectricityOn += new Electricity(lamp.LightOn); // old version , c# 4.0
            sw.ElectricityOn += lamp.LightOn;
            sw.ElectricityOn += tv.TvOn;

            // отписка от события
            //sw.ElectricityOn -= lamp.LightOn;

            sw.ElectricityOn += Program.Fire;


            string message = "Всё сгорело";
            sw.ElectricityOn += delegate (object s, EventArgs args)
            {
                Console.WriteLine(message);
                message += "!";
            };

            //lambda
            sw.ElectricityOn += (s, args) => Console.WriteLine(message + " Пожарные приехали");

            // sw.ElectricityOn?.Invoke(sw, new EventArgs());
            sw.SwitchOn(); // user action

            //Func<double, double> Cube = x => x * x * x;
            double Cube(double x) => x * x * x;

            Console.WriteLine(Cube(3.5));
        }
    }
}
