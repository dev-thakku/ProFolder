using ProFolder.Handlers;
using ProFolder.Handlers.Interfaces;

namespace ProFolder
{
    public class CommandFactory
    {
        public static ICommandHandler CreateCommmandHandler(Command command, TraceHandler traceHandler)
        {
            switch (command)
            {
                case Command.CreateRoot:
                    return new CreateRootHandler(traceHandler);

                case Command.CreateProject:
                    return new CreateProjectHandler(traceHandler);

                case Command.Help:
                    return new PrintHelpHandler(traceHandler);

                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}
