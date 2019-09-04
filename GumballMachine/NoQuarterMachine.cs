namespace ElectronicGumballMachine
{
    internal class NoQuarterMachine : IStateMachine
    {
        private IHardwareDevice HardwareDevice;
        private GumballMachine GumballMachine;

        public NoQuarterMachine(IHardwareDevice hardwareDevice, GumballMachine gumballMachine)
        {
            this.HardwareDevice = hardwareDevice;
            this.GumballMachine = gumballMachine;
            HardwareDevice.SetDisplayMessage("Quarter for a Gumball!");
        }

        public void EjectQuarter()
        {
            HardwareDevice.SetDisplayMessage("No Quarter was Inserted.");
        }

        public void FillGumballs()
        {
            HardwareDevice.fillGumballs();
        }

        public void InsertQuarter()
        {
            GumballMachine.StateMachine = new HasQuarterMachine(HardwareDevice, GumballMachine);
        }

        public void TurnCrank()
        {
            HardwareDevice.SetDisplayMessage("I need a Quarter.");
        }
    }
}