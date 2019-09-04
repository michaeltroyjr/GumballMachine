namespace ElectronicGumballMachine
{
    internal class HasQuarterMachine : IStateMachine
    {
        private IHardwareDevice HardwareDevice;
        private GumballMachine GumballMachine;

        public HasQuarterMachine(IHardwareDevice hardwareDevice, GumballMachine gumballMachine)
        {
            this.HardwareDevice = hardwareDevice;
            this.GumballMachine = gumballMachine;
            hardwareDevice.SetDisplayMessage("Turn the Crank for a Gumball!");
        }

        public void EjectQuarter()
        {
            HardwareDevice.DispenseQuarter();
            GumballMachine.StateMachine = new NoQuarterMachine(HardwareDevice, GumballMachine);
            HardwareDevice.SetDisplayMessage("Pick up your Quarter from the tray.");
        }

        public void FillGumballs()
        {
            HardwareDevice.fillGumballs();
        }

        public void InsertQuarter()
        {
            HardwareDevice.DispenseQuarter();
            HardwareDevice.SetDisplayMessage("You can't insert another Quarter.");
        }

        public void TurnCrank()
        {
            if (HardwareDevice.HasGumballs())
            {
                HardwareDevice.DispenseGumball();
                GumballMachine.StateMachine = new NoQuarterMachine(HardwareDevice, GumballMachine);
            }
            else
            {
                HardwareDevice.DispenseQuarter();
                GumballMachine.StateMachine = new SoldOutMachine(HardwareDevice, GumballMachine);
            }
        }
    }
}