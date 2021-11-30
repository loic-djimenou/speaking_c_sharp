using static System.Console;
using System.Text.RegularExpressions;



namespace Working.With.Regular.Expressions;
public class WorkingWithRegularExpressions
{

    public static void Run()
    {
        string input = "12";

        var ageChecker = new Regex(@"\d");

        if (ageChecker.IsMatch(input))
        {
            WriteLine("Thank you!");
        }
        else
        {
            WriteLine($"This is not a valid age: {input}");
        }
    }
}
