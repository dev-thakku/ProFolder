namespace ProFolder.Handlers.Interfaces
{
    public interface ICommandHandler
    {
        void Execute(string[] args);

        void Help();
    }
}
