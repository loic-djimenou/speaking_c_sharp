// See https://aka.ms/new-console-template for more information
using Packt.Shared;

var jack = new Person
{
    Name = "Sam",

};

jack.BucketList = WondersOfTheAncientWorldTow.HangingGardensOfBabylon | WondersOfTheAncientWorldTow.MausoleumAtHalicarnassus;

Console.WriteLine($"Hello, World!  {jack.BucketList}");

