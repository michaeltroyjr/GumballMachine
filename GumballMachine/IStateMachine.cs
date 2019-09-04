namespace ElectronicGumballMachine
{
    
    internal interface IStateMachine
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void FillGumballs();
    }
}