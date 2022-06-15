using Data;
using model;
using System.Linq;

Console.WriteLine("Hello, World!");

var dataset = Data.Serialization.LoadFromXML(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\personal_dataset\dataset.xml");

Console.WriteLine(dataset.Count());

//kolik lidi ma smlouvu

var result = dataset.Where(n => n.Contracts.Any()).Count();

Console.WriteLine($"počet lidi se smlouvou:{result}");

//kolik lidi bydlí v brně?
var result02 = dataset.Where(n => n.HomeAddress.City == "Brno").Count();
Console.WriteLine(result02);

//vypis jejich jmen

var result05 = dataset.Where(n => n.HomeAddress.City == "Brno");

foreach (var item in result05)
{
    Console.WriteLine($"{item.FullName}");
}

//jak se jmenuje nejstarší klient a kolik má let?

var result03 = dataset.OrderBy(n => n.DateOfBirth);
var nejmladsi = result03.Last();
var nejstarsi = result03.First();

Console.WriteLine($"nejmladší: {nejmladsi.FullName} a je starý: {nejmladsi.Age()}");
Console.WriteLine($"nejstarsi: {nejstarsi.FullName} a je starý: {nejstarsi.Age()}");