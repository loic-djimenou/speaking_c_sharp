using System;
using System.Collections.Generic;
using static System.Console;
using System.Text.RegularExpressions;



namespace Packt.Shared
{
    public interface IControl
    {
        void Paint() => Console.WriteLine("Default Paint method");
    }

    public class Person : IControl
    {
        public event EventHandler Shout;
        public int AngerLevel = default;
        public string? Name;
        public DateTime? DateOfBirth;
        public List<Person> Children = new List<Person>();

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel > 3)
            {
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }
        public virtual void WriteToConsole()
        {
            WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{Name} was born on a {DateOfBirth:dddd}.";
        }

        // indexers
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }

            set
            {
                Children[index] = value;
            }
        }

        public override bool Equals(object obj) => this.Equals(obj as Person);

        public bool Equals(Person obj)
        {
            if (obj is null)
            {
                return false;
            }
            // If run-time types are not exactly the same, return false.
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            return Name.Equals(obj.Name) && DateOfBirth == obj.DateOfBirth;
        }
        public static bool operator ==(Person lhs, Person rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Person lhs, Person rhs) => !(lhs == rhs);

        public static Person Procreate(Person lhs, Person rhs)
        {
            var baby = new Person
            {
                Name = $"Baby of {lhs.Name} and {rhs.Name}"
            };
            lhs.Children.Add(baby);
            rhs.Children.Add(baby);
            return baby;
        }

        public static Person operator *(Person lhs, Person rhs) => Procreate(lhs, rhs);

        public Person ProcreateWith(Person person)
        {
            return Procreate(this, person);
        }
    }

    public class Employee : Person
    {
        public string? EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }
        public override void WriteToConsole()
        {
            WriteLine(
                format: "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
                arg0: Name,
                arg1: DateOfBirth,
                arg2: HireDate
            );
        }
    }

    public class PersonException : Exception
    {
        public PersonException() : base() { }
        public PersonException(string message) : base(message) { }
        public PersonException(string message, Exception innerException) : base(message, innerException) { }
    }

    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // use simple regular expression to check
            // that the input string is a valid email
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}
