using System;
using init_only_setters;

    //un pas de plus vers Immutabilité
    //https://docs.microsoft.com/fr-fr/dotnet/csharp/language-reference/proposals/csharp-9.0/init
    
    var b = new Book("C# explained","Pim")
    {
        Price = 15f
    };
    //b.Price=17f; //boom c'est init only
    Console.WriteLine($"{b}");
