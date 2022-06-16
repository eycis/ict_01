using Data;
using Microsoft.EntityFrameworkCore;
using model;
using System.Linq;

Console.WriteLine("Hello, World!");

var dataset = Data.Serialization.LoadFromXML(@"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\personal_dataset\dataset.xml");



using var db = new People_context();

//db.Persons.AddRange(dataset);
//db.SaveChanges();

//db.Persons.RemoveRange(dataset);
//db.SaveChanges();


var contract = db.Contracts.Include(x => x.Company).First();
var company = contract.Company;

Console.WriteLine($"contract-company: {company.Name}");

contract.Company = null;
db.Companies.Remove(company);

//person.Contracts.First().Company = new Company() { Name = "Test Company" };
db.SaveChanges();

Console.WriteLine("ok");