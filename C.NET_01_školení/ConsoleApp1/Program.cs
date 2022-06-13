using Data;
using model;

Console.WriteLine("Hello, World!");
//nalezení cesty k souborům
var booksdir = @"C:\Users\marie\source\repos\NewRepo\C.NET_01_školení\books";
//načtení všech textových souborů
var files = Directory.EnumerateFiles(booksdir, "*.txt");

foreach (var file in files)
{
    var result = FreqAnalysis.FreqAnalysisFromFile(file);

    var fileInfo = new FileInfo(file);
    Console.WriteLine(fileInfo.Name);

    //tisk deseti nejčastějších slov:
    var ordered = result.Words.OrderByDescending(kv => kv.Value).Take(10);
    //pomocí linq může využít metodu orderbydescending, která dokáže seřadit result podle počtu výskytů. 
    //následně metoda take vezme prvních deset.


    //metoda pro výpis
    foreach (var item in ordered)
    {
        Console.WriteLine($"{item.Key}\t{item.Value}");
    }
}