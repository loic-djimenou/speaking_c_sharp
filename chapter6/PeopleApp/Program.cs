// See https://aka.ms/new-console-template for more information
using Packt.Shared;
using static System.Console;


var harry = new Person { Name = "Harry" };

var mary = new Person { Name = "Mary" };

var jill = new Person { Name = "Jill" };

// call static method

var baby = Person.Procreate(harry, jill);
var baby2 = harry * mary;
var baby3 = jill.ProcreateWith(mary);

WriteLine($"{harry.Name} has {harry.Children.Count} children.");

WriteLine($"{mary.Name} has {mary.Children.Count} children.");

WriteLine($"{jill.Name} has {jill.Children.Count} children.");

foreach (Person child in harry.Children)
{
    WriteLine(
        format: "{0}'s child is named \"{1}\".",
        arg0: harry.Name,
        arg1: child.Name
    );
}

foreach (Person child in mary.Children)
{
    WriteLine(
        format: "{0}'s child is named \"{1}\".",
        arg0: mary.Name,
        arg1: child.Name
    );
}

foreach (Person child in jill.Children)
{
    WriteLine(
        format: "{0}'s child is named \"{1}\".",
        arg0: jill.Name,
        arg1: child.Name
    );
}

void Harry_Shout(object sender, EventArgs e)
{
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

harry.Shout += Harry_Shout;
harry.Shout += Harry_Shout;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();


var control = harry as IControl;
control.Paint();

using (Animal a = new Animal())
{
    WriteLine(a.Name);

}

var employee = new Employee { Name = "Employee", HireDate = DateTime.Now, DateOfBirth = DateTime.Now };
employee.WriteToConsole();
WriteLine(employee);


string email1 = "pamela@test.com";

string email2 = "ian&test.com";
WriteLine(email1);

WriteLine(
    "{0} is a valid e-mail address: {1}",
    arg0: email1,
    arg1: StringExtensions.IsValidEmail(email1)
);

WriteLine(
    "{0} is a valid e-mail address: {1}",
    arg0: email2,
    arg1: StringExtensions.IsValidEmail(email2)
);

WriteLine(
    "{0} is a valid e-mail address: {1}",
    arg0: email1,
    arg1: email1.IsValidEmail()
);

WriteLine(
    "{0} is a valid e-mail address: {1}",
    arg0: email2,
    arg1: email2.IsValidEmail()
);