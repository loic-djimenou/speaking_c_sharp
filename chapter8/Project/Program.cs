// See https://aka.ms/new-console-template for more information

using Working.With.Numbers;
using Working.With.Regular.Expressions;
using Working.With.Ranges;
using System.Linq;
using System.Reflection;
using static System.Console;


WorkingWithNumbers.Run();
WorkingWithRegularExpressions.Run();
WorkingWithRanges.Run();


[Coder("Mark Price", "22 August 2019")]
[Coder("Johnni Rasmussen", "13 September 2019")]
static void DoStuff()
{
    WriteLine("Assembly metadata:");

    Assembly assembly = Assembly.GetEntryAssembly();

    WriteLine($" Full name: {assembly.FullName}");

    WriteLine($" Location: {assembly.Location}");

    var attributes = assembly.GetCustomAttributes();

    WriteLine($" Attributes:");

    foreach (Attribute a in attributes)

    {

        WriteLine($" {a.GetType()}");

    }


    var version = assembly.GetCustomAttribute

    <AssemblyInformationalVersionAttribute>();

    WriteLine($" Version: {version.InformationalVersion}");

    var company = assembly.GetCustomAttribute

    <AssemblyCompanyAttribute>();

    WriteLine($" Company: {company.Company}");


    WriteLine("Hello, World!");
    WriteLine();

    WriteLine($"* Types:");

    Type[] types = assembly.GetTypes();

    foreach (Type type in types)

    {

        WriteLine();

        WriteLine($"Type: {type.FullName}");

        MemberInfo[] members = type.GetMembers();

        foreach (MemberInfo member in members)

        {

            WriteLine("{0}: {1} ({2})",

            arg0: member.MemberType,

            arg1: member.Name,

            arg2: member.DeclaringType.Name);

            var coders = member.GetCustomAttributes<CoderAttribute>()

            .OrderByDescending(c => c.LastModified);

            foreach (CoderAttribute coder in coders)

            {

                WriteLine("-> Modified by {0} on {1}",

                coder.Coder, coder.LastModified.ToShortDateString());

            }

        }

    }
}

DoStuff();