// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();
var ts = new TraceSwitch(
    displayName: "PacktSwitch",
    description: "This switch is set via a JSON config.");

configuration.GetSection("PacktSwitch").Bind(ts);

Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));
Trace.AutoFlush = true;

Trace.WriteLineIf(ts.TraceError, "Trace error");

Trace.WriteLineIf(ts.TraceWarning, "Trace warning");

Trace.WriteLineIf(ts.TraceInfo, "Trace information");

Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");




//
// Summary:
//     Writes the text representation of the specified single-precision floating-point
//     value, followed by the current line terminator, to the standard output stream.
//
// Parameters:
//   value:
//     The value to write.
//
// Exceptions:
//   T:System.IO.IOException:
//     An I/O error occurred.
static void TimesTable(byte number)
{
    for (int i = 0; i <= 12; i++)
    {
        Console.WriteLine($" {i}x{number} = {i * number} ");
    }
}

/// <summary>
/// Returns factorial of a given number
/// </summary>
/// <param name="number"> Number to calculate the factorial from</param>
/// <returns>Calculated the factorial</returns>
static int Factorial(int number)
{
    if (number < 1)
    {
        return 0;
    }
    else if (number == 1)
    {
        return 1;
    }
    else
    {
        Console.WriteLine("eeeeee");
        return number * Factorial(number - 1);
    }
}

TimesTable(12);

Console.WriteLine($" Factorial is {Factorial(4)}");

Debug.WriteLine("Debugung");
Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");
