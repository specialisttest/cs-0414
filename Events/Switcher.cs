
namespace Events
{
    //public delegate void Electricity(object sender, EventArgs args);
    public class Switcher
    {
        //public event Electricity ElectricityOn;
        public event Action<object, EventArgs> ElectricityOn;

        protected virtual void onElectricty(object sender, EventArgs args) {
            ElectricityOn?.Invoke(sender, args);
        }

        public void SwitchOn()
        {
            Console.WriteLine("Выключатель включен");
            //if(ElectricityOn !=null) ElectricityOn();
            
            ElectricityOn?.Invoke(this, new EventArgs());

            //Delegate[] dlg = ElectricityOn.GetInvocationList();

            // async call
            // only single method
            //ElectricityOn?.BeginInvoke(this, callback)
        }
    }
}
