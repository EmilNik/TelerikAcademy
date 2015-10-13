namespace Computers.Logic.Manufactorers
{
    using ComputerType;

    public interface IComputersFactory
    {
        PersonalComputer CreatePersonalComputer();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}
