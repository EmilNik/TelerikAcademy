namespace Phonebook.Command
{
    public interface IPhonebookCommand
    {
        void Execute(string[] arguments);
    }
}
