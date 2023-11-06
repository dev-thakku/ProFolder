using System.Text;

namespace ProFolder.Handlers
{
    public class TraceHandler
    {
        public void PrintMessage(string? message, int indentation = 0)
        {
            var builder = new StringBuilder("## ");
            for (var index = 0; index < indentation; index++)
            {
                builder.Append("  ");
            }
            builder.Append(message);
            Console.WriteLine(builder.ToString());
        }
    }
}
