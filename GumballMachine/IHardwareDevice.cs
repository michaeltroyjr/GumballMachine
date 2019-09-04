namespace ElectronicGumballMachine
{
    public interface IHardwareDevice
    {

        void DispenseQuarter();

        void DispenseGumball();
        bool HasGumballs();
        
        void SetDisplayMessage(string message);

        void fillGumballs();

    }
}