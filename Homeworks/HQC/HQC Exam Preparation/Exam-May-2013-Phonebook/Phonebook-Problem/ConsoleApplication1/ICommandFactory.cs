namespace Phonebook
{
    using Command;

    public interface ICommandFactory
    {
        IPhonebookCommand CreateCommand(string commandName, int argumentsCount);
    }
}
