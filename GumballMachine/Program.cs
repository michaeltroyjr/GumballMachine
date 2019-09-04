using System;

namespace ElectronicGumballMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            MockHardwareDevice hardwareDevice = new MockHardwareDevice();
            GumballMachine gumballMachine = new GumballMachine(hardwareDevice);

            string input = String.Empty;
            while (!input.Contains("5"))
            {
                Console.WriteLine(hardwareDevice.DisplayMessage());
                Console.WriteLine("{0} (1) Insert Quarter{0} (2) Turn Crank{0} (3) Eject Quarter{0} (4) Fill Gumballs{0} (5) Exit", Environment.NewLine);

                input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1" :
                        gumballMachine.InsertQuarter();
                        break;
                    case "2":
                        gumballMachine.TurnCrank();
                        break;
                    case "3":
                        gumballMachine.EjectQuarter();
                        break;
                    case "4":
                        gumballMachine.FillGumballs();
                        break;
                }

                if (hardwareDevice.WasGumballDispensed())
                    Console.WriteLine("Gumball was Dispensed!");

                if (hardwareDevice.WasQuarterDispensed())
                    Console.WriteLine("Quarter was Returned!");

            }
        }
    }
}
