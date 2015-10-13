namespace Computers.UI
{
    using System;
    using Logic.ComputerType;
    using Logic.Manufactorers;

    public static class Computers
    {
        private const string ExitCommand = "Exit";
        private const string ChargeCommandName = "Charge";
        private const string ProcessCommandName = "Process";
        private const string PlayCommandName = "Play";

        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            CreateComputers();
            ProcessCommand();
        }

        private static void CreateComputers()
        {
            var manufactorerFactory = new ManufactorerFactory();
            var manufacturer = Console.ReadLine();

            IComputersFactory computerFactory =
                manufactorerFactory.GetManufactorer(manufacturer);
            
            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
        }

        private static void ProcessCommand()
        {
            while (true)
            {
                var userInput = Console.ReadLine();

                if (userInput == null)
                {
                    break;
                }

                if (userInput.StartsWith(ExitCommand))
                {
                    break;
                }

                var commandParts = userInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandParts[0];
                var commandArgument = int.Parse(commandParts[1]);

                if (commandName == ChargeCommandName)
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommandName)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommandName)
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}
