using ProFolder.Handlers;

namespace ProFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProcessCommands(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void ProcessCommands(string[] args)
        {
            var command = GetCommand(args);
            var traceHandler = new TraceHandler();
            var commandHandler = CommandFactory.CreateCommmandHandler(command, traceHandler);

            commandHandler.Execute(args);
        }


        private static Command GetCommand(IReadOnlyList<string> args)
        {
            if (0 == args.Count)
            {
                return Command.Invalid;
            }
            return
                !Enum.TryParse(args[0], true, out Command commandValue) ? Command.Invalid : commandValue;
        }

    }
}