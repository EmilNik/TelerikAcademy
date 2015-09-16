namespace Phonebook
{
    using System;

    public class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string text)
        {
            int indexOfTheParentesis = text.IndexOf('(');

            if (indexOfTheParentesis == -1)
            {
                throw new ArgumentException("Invalid command format");
            }

            string commandName = text.Substring(0, indexOfTheParentesis);

            if (!text.EndsWith(")"))
            {
                throw new ArgumentException("Invalid command format");
            }

            string listOfArgumentsAsString = text.Substring(indexOfTheParentesis + 1, text.Length - indexOfTheParentesis - 2);

            var arguments = listOfArgumentsAsString.Split(',');

            for (int j = 0; j < arguments.Length; j++)
            {
                arguments[j] = arguments[j].Trim();
            }

            var commandInfo = new CommandInfo
            {
                CommandName = commandName,
                Arguments = arguments
            };

            return commandInfo;
        }
    }
}
