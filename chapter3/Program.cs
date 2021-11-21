// See https://aka.ms/new-console-template for more information
using static System.Console;

WriteLine("Hello, World!");

bool a = true;

bool b = false;

WriteLine($"AND | a | b ");

WriteLine($"a | {a & a,-5} | {a & b,-5} ");

WriteLine($"b | {b & a,-5} | {b & b,-5} ");

WriteLine();

WriteLine($"OR | a | b ");

WriteLine($"a | {a | a,-5} | {a | b,-5} ");

WriteLine($"b | {b | a,-5} | {b | b,-5} ");

WriteLine();

WriteLine($"XOR | a | b ");

WriteLine($"a | {a ^ a,-5} | {a ^ b,-5} ");

WriteLine($"b | {b ^ a,-5} | {b ^ b,-5} ");

int aa = 10; // 0000 1010

int ab = 6; // 0000 0110

WriteLine($"aa = {aa}");

WriteLine($"ab = {ab}");

WriteLine($"aa & ab = {aa & ab}"); // 2-bit column only

WriteLine($"aa | ab = {aa | ab}"); // 8, 4, and 2-bit columns

WriteLine($"aa ^ ab = {aa ^ ab}"); // 8 and 4-bit columns

// 0101 0000 left-shift a by three bit columns

WriteLine($"aa << 3 = {aa << 3}");

// multiply a by 8

WriteLine($"aa * 8 = {aa * 8}");

// 0000 0011 right-shift b by one bit column

WriteLine($"ab >> 1 = {ab >> 1}");



object o = "3";

int j = 4;

if(o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else if(o is string k)
{
    WriteLine($"o is a string of {k.Length} characters");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}



A_label:

var number = (new Random()).Next(1, 7);

WriteLine($"My random number is {number}");

switch (number)
{
    case 1:
    WriteLine("One");
    break; // jumps to end of switch statement
    case 2:
    WriteLine("Two");
    goto case 1;
    case 3:
    case 4:
    WriteLine("Three or four");
    goto case 1;
    case 5:
    // go to sleep for half a second
    System.Threading.Thread.Sleep(500);
    goto A_label;
    default:
    WriteLine("Default");
    break;
} // end of switch statement



// string path = "/Users/user/Code/Chapter03";

//string path = @"C:\Code\Chapter03";

Stream s = File.Open(

Path.Combine("", "file.txt"), FileMode.OpenOrCreate);

string message = string.Empty;

switch (s)

{

case FileStream writeableFile when s.CanWrite:

message = "The stream is a file that I can write to.";

break;

case FileStream readOnlyFile:

message = "The stream is a read-only file.";

break;

case MemoryStream ms:

message = "The stream is a memory address.";

break;

default: // always evaluated last despite its current position

message = "The stream is some other type.";

break;

case null:

message = "The stream is null.";

break;

}

WriteLine(message);



message = s switch

{

FileStream writeableFile when s.CanWrite

=> "The stream is a file that I can write to.",

FileStream readOnlyFile

=> "The stream is a read-only file.",

MemoryStream ms

=> "The stream is a memory address.",

null

=> "The stream is null.",

_

=> "The stream is some other type."

};

WriteLine(message);


double g = 9.8;

int h = Convert.ToInt32(g);

WriteLine($"g is {g} and h is {h}");

double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };

foreach (double n in doubles)
{
    WriteLine($"ToInt({n}) is {Convert.ToInt32(n)}");
    WriteLine(
        format:"Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
        arg0: n,
        arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero)
    );
}


// allocate array of 128 bytes

byte[] binaryObject = new byte[128];

// populate array with random bytes

(new Random()).NextBytes(binaryObject);

WriteLine("Binary Object as bytes:");

for(int index = 0; index < binaryObject.Length; index++)

{

Write($"{binaryObject[index]:X} ");

}

WriteLine();

// convert to Base64 string and output as text

string encoded = Convert.ToBase64String(binaryObject);

WriteLine($"Binary Object as Base64: {encoded}");

int age = int.Parse("127");

DateTime birthday = DateTime.Parse("4 July 1980");

WriteLine($"I was born {age} years ago.");

WriteLine($"My birthday is {birthday}.");

WriteLine($"My birthday is {birthday:D}.");

try
{
    int count = int.Parse("abc");
    WriteLine($"Count {count} .");
}
catch (System.FormatException ex)
{
    WriteLine($"Cannot convert to int {ex.Message} === {ex.GetType()}");
}


/*
Write("How many eggs are there? ");

int counter;

string input = Console.ReadLine();

if (int.TryParse(input, out counter))
{
    WriteLine($"There are {counter} eggs.");
}
else
{
    WriteLine("I could not parse the input.");
}

*/


int x = int.MaxValue - 1;

WriteLine($"Initial value: {x}");

x++;

WriteLine($"After incrementing: {x}");

x++;

WriteLine($"After incrementing: {x}");

x++;

WriteLine($"After incrementing: {x}");
/*

Throws an OverflowException

checked

{

int xx = int.MaxValue - 1;

WriteLine($"Initial value: {xx}");

xx++;

WriteLine($"After incrementing: {xx}");

xx++;

WriteLine($"After incrementing: {xx}");

xx++;

WriteLine($"After incrementing: {xx}");

}

*/


unchecked

{

int y = int.MaxValue + 1;

WriteLine($"Initial value: {y}");

y--;

WriteLine($"After decrementing: {y}");

y--;

WriteLine($"After decrementing: {y}");


double willBeDivided = 99;

WriteLine($"{willBeDivided/0}");

int maxx = (int)9999999999999999999;

WriteLine($"Maxxx {maxx}");
}

var manox = 3 << 2;
var manoy = 10 >> 1;

WriteLine($"manox {manox} ===== manoy {manoy}");