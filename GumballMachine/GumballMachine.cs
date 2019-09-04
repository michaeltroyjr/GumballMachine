using System;
using System.Runtime.CompilerServices;

namespace ElectronicGumballMachine
{
    internal class GumballMachine
    {
        public IHardwareDevice HardwareDevice;
        public IStateMachine StateMachine;

        public GumballMachine(IHardwareDevice hardwareDevice)
        {
            HardwareDevice = hardwareDevice;
            StateMachine = new SoldOutMachine(HardwareDevice, this);
        }
        
        internal void InsertQuarter()
        {
            StateMachine.InsertQuarter();
        }

        public void EjectQuarter()
        {
            StateMachine.EjectQuarter();
        }

        public void TurnCrank()
        {
            StateMachine.TurnCrank();
        }

        public void FillGumballs()
        {
            StateMachine.FillGumballs();
        }
    }
}