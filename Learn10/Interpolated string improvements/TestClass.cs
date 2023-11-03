using System.Runtime.CompilerServices;
using System.Text;

namespace Learn10.Interpolated_string_improvements;

public class Interpolated_string_improvements
{
    [InterpolatedStringHandler] // C# 10.0
    public readonly ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        readonly StringBuilder _builder;
        private readonly bool _enabled;
        public LogInterpolatedStringHandler(int literalLength, int formattedCount, Logger logger, LogLevel logLevel)
        {
            _enabled = logger.EnabledLevel >= logLevel;
            _builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
            if (!_enabled) return;

            _builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }
        
        //In this example remove those method:
        public void AppendFormatted<T>(T t) where T : IFormattable
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
            if (!_enabled) return;

            _builder.Append(t);
            Console.WriteLine($"\tAppended the formatted object");
        }
        public void AppendFormatted<T>(T t, string format) where T : IFormattable
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
            if (!_enabled) return;

            _builder.Append(t?.ToString(format, null));
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => _builder.ToString();
    }
    public enum LogLevel
    {
        Off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }
    public class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Trace;

        public void LogMessage(LogLevel level,[InterpolatedStringHandlerArgument("", "level")] LogInterpolatedStringHandler builder
        //public void LogMessage(LogLevel level, string msg
        ) //C# 10.0
        {
            if (EnabledLevel < level) return;
            //Console.WriteLine(msg);
            Console.WriteLine(builder.GetFormattedText());;
        }
    }
    public  static void Test()
    {
        var logger = new Logger() { EnabledLevel = LogLevel.Information };
        var time = DateTime.Now;

        //logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
        //logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time:t}. This won't be printed.");
        //logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");
        
        
        logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. The time doesn't use formatting.");
        logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time:t}. This is an error. It will be printed.");
        logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time:t}. This won't be printed.");
        
        int index = 0;
        int numberOfIncrements = 0;
        for (var level = LogLevel.Critical; level <= LogLevel.Trace; level++)
        {
            Console.WriteLine(level);
            //logger.LogMessage(level, $"{level}: Increment index a few times {index++}, {index++}, {index++}, {index++}, {index++}");
            logger.LogMessage(level, $"{level:F}: Increment index a few times {index++:F}, {index++:F}, {index++:F}, {index++:F}, {index++:F}");
            numberOfIncrements += 5;
        }
        Console.WriteLine($"Value of index {index}, value of numberOfIncrements: {numberOfIncrements}");
        
        var myNumber = 42;
        var myString = $"{myNumber:0000}";
        Console.WriteLine(myString); // outputs "0042"
    }
}