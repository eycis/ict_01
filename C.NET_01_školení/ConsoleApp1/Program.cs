using Data;
using model;
using System.Linq;

Console.WriteLine("Hello, World!");

int[] numbers = { 11, 2, 13, 44, -5, 6, 127, -99, 0, 256};
//linq WHERE
//var result = numbers.Where(n => n > 0) //využívání linqu k filtraci podle zadaných podmínek v závorkách
//                    .Where(n => n < 99);

//linq ORDERBY
//var result = numbers.OrderBy(n => n); //pouze řadí od nejmenšího po největší

//linq AGREGACE-
//pro výpis max, min, avg, count, length a dalších
//var number = numbers.Max();

//linq TAKE SKIP+while
//take bere čísla dokud je splněna podmínka, skip přeskakuje dokud platí podmínka
//var result = numbers.TakeWhile(n => n > 0);

//linq SELECT-transformace (v tomto případě převede negativní čísla do absolutní hodnoty
//var result = numbers.Select(n => Math.Abs(n));

//string.join je opak splitu, dá mi dohromady elementy z result a oddělí je čárkou
//první parametr je jak to chceme oddělit a druhý je jaký seznam teda máme zpracovat

//Console.WriteLine(string.Join(",", result));
//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}


static void FreqWords()
{
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
}