using Data;
using model;
using System.Linq;

Console.WriteLine("Hello, World!");

var dataset = Data.Serialization.LoadFromXML(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\personal_dataset\dataset.xml");



using var db = new People_context();

//db.Persons.AddRange(dataset);
//db.SaveChanges();

//db.RemoveRange(db.Persons);
//db.SaveChanges();

Console.WriteLine(db.Persons.Count());
Console.WriteLine("ok");