namespace Packt.Shared
{

    public class ThingOfDefaults
    {
        public int Population;

        public DateTime When;

        public string Name;

        public List<Person> People;

        public ThingOfDefaults()

        {

            Population = default(int); // C# 2.0 and later

            When = default(DateTime);

            Name = default(string);

            People = default(List<Person>);

            Population = default; // C# 7.1 and later

            When = default;

            Name = default;

            People = default;


        }

    }

    public class Person
    {
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

        private string temp;
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }

            set
            {
                temp = value;
            }
        }
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorldTow BucketList;
        public Person[] Children;

        public (string, int) GetFruit()
        {
            return ("Apples", 1);
        }

        public (string Name, int Num) GetFruitExplicit()
        {
            return (Name: "Apples", Num: 1);
        }

        public void Deconstruct()
        {
            // store return value in a tuple variable with two fields

            (string name, int age) tupleWithNamedFields = GetFruitExplicit();

            // tupleWithNamedFields.name

            // tupleWithNamedFields.age

            // deconstruct return value into two separate variables

            (string name, int age) = GetPerson();

            // name

            // age
        }
    }

    public enum WondersOfTheAncientWorld
    {
        GreatPyramidOfGiza,

        HangingGardensOfBabylon,

        StatueOfZeusAtOlympia,

        TempleOfArtemisAtEphesus,

        MausoleumAtHalicarnassus,

        ColossusOfRhodes,

        LighthouseOfAlexandria
    }

    [System.Flags]

    public enum WondersOfTheAncientWorldTow : byte

    {

        None = 0b_0000_0000, // i.e. 0

        GreatPyramidOfGiza = 0b_0000_0001, // i.e. 1

        HangingGardensOfBabylon = 0b_0000_0010, // i.e. 2

        StatueOfZeusAtOlympia = 0b_0000_0100, // i.e. 4

        TempleOfArtemisAtEphesus = 0b_0000_1000, // i.e. 8

        MausoleumAtHalicarnassus = 0b_0001_0000, // i.e. 16

        ColossusOfRhodes = 0b_0010_0000, // i.e. 32

        LighthouseOfAlexandria = 0b_0100_0000 // i.e. 64

    }
}
