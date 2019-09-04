namespace ElectronicGumballMachine
{
    public class MockHardwareDevice : IHardwareDevice
    {
        private string Message;
        private bool QuarterEjected;
        private int NumberOfGumballs;
        private bool GumballDispensed;
        
        public void DispenseQuarter()
        {
            QuarterEjected = true;
        }

        public bool WasQuarterDispensed()
        {
            bool quarterEjected = QuarterEjected;
            QuarterEjected = false;
            return quarterEjected;
        }

        public bool WasGumballDispensed()
        {
            bool gumballDispensed = GumballDispensed;
            GumballDispensed = false;
            return gumballDispensed;
        }

        public void DispenseGumball()
        {
            NumberOfGumballs--;
            GumballDispensed = NumberOfGumballs >= 0;
        }

        public void SetDisplayMessage(string message)
        {
            this.Message = message;
        }


        public string DisplayMessage()
        {
            return Message;
        }

        public void fillGumballs()
        {
            NumberOfGumballs += 5;
        }

        public bool HasGumballs()
        {
            return NumberOfGumballs > 0;
        }
    }
}