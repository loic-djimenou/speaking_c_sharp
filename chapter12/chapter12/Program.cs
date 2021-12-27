using static System.Console;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}

*/
static void LinqWithArrayOfExceptions()
{
    var errors = new Exception[]
    {
        new ArgumentException(),
        new SystemException(),
        new IndexOutOfRangeException(),
        new InvalidOperationException(),
        new NullReferenceException(),
        new InvalidCastException(),
        new OverflowException(),
        new DivideByZeroException(),
        new ApplicationException()
    };

    var numberErrors = errors.OfType<OverflowException>();

    foreach (var error in numberErrors)
    {
        WriteLine(error);
    }
}



static void LinqWithArrayOfStrings()
{
    var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

    var query = names.Where(name => name.Length > 5);

    foreach (string name in query)
    {
        WriteLine(name);
    }
}

LinqWithArrayOfStrings();

LinqWithArrayOfExceptions();