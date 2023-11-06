using ProFolder.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFolder.Handlers
{
    public class PrintHelpHandler : ICommandHandler
    {
        private readonly TraceHandler _traceHandler;

        public PrintHelpHandler(TraceHandler traceHandler)
        {
            _traceHandler = traceHandler;
        }

        public void Execute(string[] args)
        {
            Help();
        }

        public void Help()
        {
            Help(_traceHandler);
        }

        private static void Help(TraceHandler traceHandler)
        {
            traceHandler.PrintMessage("From PrintHelpHandler!");
        }
    }
}
