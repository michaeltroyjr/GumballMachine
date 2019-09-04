using NUnit.Framework;

namespace ElectronicGumballMachine.UnitTests
{
    [TestFixture]
    public class SoldOutMachineTests
    {
        private GumballMachine TestMachine;
        private MockHardwareDevice TestDevice;

        [SetUp]
        public void Initialize()
        {
            TestDevice = new MockHardwareDevice();
            TestMachine = new GumballMachine(TestDevice);

        }

        [Test]
        public void GivenNewMachine_Then_MachineSoldOut()
        {

            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Sorry, the machine is sold out."));
        }

        [Test]
        public void GivenMachine_And_QuarterInserted_Then_DispenseQuarterAndChangeDisplayMessage()
        {
            TestMachine.InsertQuarter();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("There are no Gumballs, please pick up your Quarter."));
            Assert.IsTrue(TestDevice.WasQuarterDispensed());
        }

        [Test]
        public void GivenMachine_And_EjectQuarterHit_Then_NoQuarterEjectedAndChangeDisplayMessage()
        {
            TestMachine.EjectQuarter();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("This is not a Slot Machine."));
            Assert.IsFalse(TestDevice.WasQuarterDispensed());
        }

        [Test]
        public void GivenMachine_And_CrankTurned_Then_ChangeDisplayMessage()
        {
            TestMachine.TurnCrank();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("There are no Gumballs."));
        }

    }

    [TestFixture]
    public class NoQuarterMachineTests
    {
        private GumballMachine TestMachine;
        private MockHardwareDevice TestDevice;

        [SetUp]
        public void Initialize()
        {
            TestDevice = new MockHardwareDevice();
            TestMachine = new GumballMachine(TestDevice);
            TestMachine.FillGumballs();
        }

        [Test]
        public void GivenMachine_Then_DisplayAd()
        {
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Quarter for a Gumball!"));
        }

        [Test]
        public void GivenMachine_And_GumballsAdded_Then_DisplayAd()
        {
            TestDevice.fillGumballs();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Quarter for a Gumball!"));
        }

        [Test]
        public void GivenMachine_And_EjectQuarter_Then_ChangeDisplay()
        {
            TestMachine.EjectQuarter();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("No Quarter was Inserted."));
        }

        [Test]
        public void GivenMachine_And_CrankTurned_Then_ChangeDisplay()
        {
            TestMachine.TurnCrank();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("I need a Quarter."));
        }

    }

    [TestFixture]
    public class HasQuarterMachineTests
    {
        private GumballMachine TestMachine;
        private MockHardwareDevice TestDevice;

        [SetUp]
        public void Initialize()
        {
            TestDevice = new MockHardwareDevice();
            TestMachine = new GumballMachine(TestDevice);
            TestMachine.FillGumballs();
            TestMachine.InsertQuarter();
        }

        [Test]
        public void GivenMachine_Then_DisplayInstructions()
        {
            
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Turn the Crank for a Gumball!"));
        }

        [Test]
        public void GivenMachine_And_GumballsAdded_Then_DisplayInstructions()
        {
            TestDevice.fillGumballs();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Turn the Crank for a Gumball!"));
        }

        [Test]
        public void GivenMachine_And_QuarterInserted_Then_ChangeDisplay()
        {
            TestMachine.InsertQuarter();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("You can't insert another Quarter."));
            Assert.IsTrue(TestDevice.WasQuarterDispensed());
        }

        [Test]
        public void GivenMachine_And_QuarterEjected_Then_DisplayInstructions()
        {
            TestMachine.EjectQuarter();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Pick up your Quarter from the tray."));
            Assert.IsTrue(TestDevice.WasQuarterDispensed());
        }

        [Test]
        public void GivenMachine_And_CrankTurnedAndMoreGumballs_Then_DispenseGumballAndChangeDisplay()
        {
            TestMachine.TurnCrank();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Quarter for a Gumball!"));
            Assert.IsTrue(TestDevice.WasGumballDispensed());
        }

        [Test]
        public void GivenMachine_And_CrankTurnedAndNoMoreGumballs_Then_ChangeDisplay()
        {
            for (int gumballs = 5; gumballs > 0; gumballs--)
            {
                TestMachine.TurnCrank();
                TestMachine.InsertQuarter();
            }
            TestDevice.WasGumballDispensed();
            TestMachine.TurnCrank();
            Assert.That(TestDevice.DisplayMessage(), Is.EqualTo("Sorry, the machine is sold out."));
            Assert.IsFalse(TestDevice.WasGumballDispensed());
            Assert.IsTrue(TestDevice.WasQuarterDispensed());

        }
    }
}
