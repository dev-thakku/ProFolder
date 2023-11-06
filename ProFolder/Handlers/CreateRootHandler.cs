using ProFolder.Handlers.Interfaces;

namespace ProFolder.Handlers
{
    public class CreateRootHandler : ICommandHandler
    {
        private readonly TraceHandler _traceHandler;

        public CreateRootHandler(TraceHandler traceHandler)
        {
            _traceHandler = traceHandler;
        }

        public void Execute(string[] args)
        {
            _traceHandler.PrintMessage("Create Root");
        }

        public void Help()
        {
            _traceHandler.PrintMessage("Help Create Root");
        }
    }
}
