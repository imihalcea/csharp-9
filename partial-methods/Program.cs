using System;
using static System.Console;
using partial_methods;

//extensibilité
//meta-programmation
//source generators
//https://www.infoq.com/news/2020/06/CSharp-9-Partial-Methods/
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extending-partial-methods


var r = new Rectangle(3,6);
r.Display();

var c = new Circle(42);
c.Display();