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
//var result02 = dataset.Where(n => n.HomeAddress.City == "Brno").Count();
//Console.WriteLine(result02);

//vypis jejich jmen

//var result05 = dataset.Where(n => n.HomeAddress.City == "Brno");

//foreach (var item in result05)
//{
//    Console.WriteLine($"{item.FullName}");
//}

//jak se jmenuje nejstarší klient a kolik má let?

//var result03 = dataset.OrderBy(n => n.DateOfBirth);
//var nejmladsi = result03.Last();
//var nejstarsi = result03.First();

//Console.WriteLine($"nejmladší: {nejmladsi.FullName} a je starý: {nejmladsi.Age()}");
//Console.WriteLine($"nejstarsi: {nejstarsi.FullName} a je starý: {nejstarsi.Age()}");
//Console.WriteLine("---------------------");

//anonymní typy:

//var person = dataset.Select(p => new { p.FullName, Age = p.Age() });

//foreach (var item in person)
//{
//    Console.WriteLine(item.FullName+ " "+item.Age);
//}

//vypsání do n-tice
//var person_tuple = dataset.Select(p => ( Name :p.FullName, Age : p.Age() ));

//foreach (var item in person_tuple)
//{
//    Console.WriteLine(item.Name + " " + item.Age);
//}

//druhá možnost:
//var person_tuple_02 = dataset.Select(p => (p.FullName, Age: p.Age()));

//foreach (var item in person_tuple_02)
//{
//    Console.WriteLine(item.FullName + " " + item.Age);
//}

//seskupení lidí podle měst
//var groups = dataset.GroupBy(p => p.HomeAddress.City);

//foreach (var group in groups)
//{
//    Console.WriteLine($"grupa: {group.Key} počet: {group.Count()}");
//    Console.WriteLine("--------------");
//}

//výpis lidí podle skupin
//foreach (var group in groups)
//{
//    Console.WriteLine($"grupa: {group.Key}");
//    foreach (var people in group)
//    {
//        Console.WriteLine(people);
//    }
//    Console.WriteLine("--------------");
//}

//SELECT MANY - todo- získat všechny smlouvy

var contract = dataset.SelectMany(p => p.Contracts);
Console.WriteLine($"celkem smluv: { contract.Count()}");

//která osoba uzavřela jako poslední smlouvu
//nejdřív musím dostat osoby, které mají na sobě smlouvu. 
var one = dataset.Where(p => p.Contracts.Any());

var withContract = 
    one.OrderByDescending(p => p.Contracts.OrderByDescending(c => c.Signed).First().Signed).First();
Console.WriteLine(withContract);

//alternativa:

Contract con = dataset.SelectMany(c => c.Contracts).OrderBy(c => c.Signed).Last();
var per = dataset.Where(p => p.Contracts.Contains(con));
foreach (var item in per)
{
    Console.WriteLine(item);
}