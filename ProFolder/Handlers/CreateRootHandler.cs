using ProFolder.Handlers.Interfaces;

namespace ProFolder.Handlers
{
    public class CreateRootHandler : CreateFoldersHandler, ICommandHandler
    {

        public CreateRootHandler(TraceHandler traceHandler) : base(traceHandler) { }

        public void Execute(string[] args)
        {
            CreateFolders(FolderType.RootFolders, args);
            _traceHandler.PrintMessage("Root folders successfully created!");
        }

        public void Help()
        {
            _traceHandler.PrintMessage("Help Create Root");
        }
    }
}
