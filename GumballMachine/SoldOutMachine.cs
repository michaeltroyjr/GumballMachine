namespace ElectronicGumballMachine
{

    internal class SoldOutMachine : IStateMachine
    {
        
        private IHardwareDevice HardwareDevice;
        private GumballMachine GumballMachine;

        public SoldOutMachine(IHardwareDevice hardwareDevice, GumballMachine gumballMachine)
        {
            this.HardwareDevice = hardwareDevice;
            this.GumballMachine = gumballMachine;
            hardwareDevice.SetDisplayMessage("Sorry, the machine is sold out.");
        }

        public void EjectQuarter()
        {
            HardwareDevice.SetDisplayMessage("This is not a Slot Machine.");
        }

        public void InsertQuarter()
        {
            HardwareDevice.DispenseQuarter();
            HardwareDevice.SetDisplayMessage("There are no Gumballs, please pick up your Quarter.");
        }

        public void TurnCrank()
        {
            HardwareDevice.SetDisplayMessage("There are no Gumballs.");
        }

        public void FillGumballs()
        {
            HardwareDevice.fillGumballs();
            GumballMachine.StateMachine = new NoQuarterMachine(HardwareDevice, GumballMachine);
        }
    }
}