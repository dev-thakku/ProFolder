using ProFolder.Handlers.Interfaces;
using ProFolder.Utils;

namespace ProFolder.Handlers
{
    public class CreateProjectHandler : CreateFoldersHandler, ICommandHandler
    {

        public CreateProjectHandler(TraceHandler traceHandler) : base(traceHandler) { }

        public void Execute(string[] args)
        {
            CreateFolders(FolderType.ProjectFolders, args);
            _traceHandler.PrintMessage("Project folders successfully created!");
        }

        public void Help()
        {
            _traceHandler.PrintMessage("Help Create Project");
        }
    }
}
