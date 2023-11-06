using ProFolder.Handlers.Interfaces;

namespace ProFolder.Handlers
{
    public class CreateProjectHandler : ICommandHandler
    {
        private readonly TraceHandler _traceHandler;

        public CreateProjectHandler(TraceHandler traceHandler)
        {
            _traceHandler = traceHandler;
        }

        public void Execute(string[] args)
        {
            _traceHandler.PrintMessage("Create Project");
        }

        public void Help()
        {
            _traceHandler.PrintMessage("Help Create Project");
        }
    }
}
