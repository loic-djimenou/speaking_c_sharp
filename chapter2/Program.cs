// See https://aka.ms/new-console-template for more information



namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Temperature on {0:D} is {1} C", DateTime.Today, 30.4);
            double heightInMeters = 1.88;
            Console.WriteLine($"The variable {nameof(heightInMeters)} has the value {heightInMeters}");
            string verbatim = @"\tverbatim";
            Console.WriteLine(verbatim);

            // unsigned integer means positive whole number
            // including 0
            uint naturalNumber = 23;
            // integer means negative or positive whole number
            // including 0
            int integerNumber = -23;
            // float means single-precision floating point
            // F suffix makes it a float literal
            float realNumber = 2.3F;
            // double means double-precision floating point
            double anotherRealNumber = 2.3; // double literal
            Console.WriteLine(naturalNumber);
            Console.WriteLine(integerNumber);
            Console.WriteLine(realNumber);
            Console.WriteLine(anotherRealNumber);

            // three variables that store the number 2 million
            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;
            // check the three variables have the same value
            // both statements output true
            Console.WriteLine($"{decimalNotation == binaryNotation}");
            Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            Console.WriteLine($"{name} is {height} metres tall.");
            // int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // tell compiler it is a string
            Console.WriteLine($"{name} has {length2} characters.");

            dynamic anotherName = "Amelie";
            int anotherLength = anotherName.Length;

            string[] list = new string[4];

            int? nullableIn = null ;

            Console.WriteLine(nullableIn);

            var adres = new Address();
            adres.Building = null;
            adres.City = null;


            int numberOfApples = 12;

            decimal pricePerApple = 0.35M;

            Console.WriteLine(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);

            string formatted = string.Format(
                format: "{0} apples costs {1:C}",
                arg0: numberOfApples,
                arg1: pricePerApple * numberOfApples);
            Console.WriteLine(formatted);

            string applesText = "Apples";

            int applesCount = 1234;

            string bananasText = "Bananas";

            int bananasCount = 56789;

            Console.WriteLine(
                format: "{0,-8} {1,16:N0}",
                arg0: "Name",
                arg1: "Count");

            Console.WriteLine(
                format: "{0,-8} {1,16:N0}",
                arg0: applesText,
                arg1: applesCount);

            Console.WriteLine(
                format: "{0,-8} {1,16:N0}",
                arg0: bananasText,
                arg1: bananasCount);

        }
    }
}