using System;

namespace records
{
    class Program
    {
        //RECORDS == Immutabilité par defaut
        //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/records
        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9

        static void Main(string[] args)
        {
            var b0 = new Book("C# 9","Plop",40);
            Console.WriteLine($"{b0}");
            
            var bp = b0 with {Likes=b0.Likes+2};
            Console.WriteLine($"{bp}");

            var b1 = new Book("C# 10","Plop",0);    
            var b2 = new Book("C# 10","Plop",0);    
            var b3 = new Book("C# 10","Plop",1);    

            
            
            Console.WriteLine($"b0 == bp {StructuralEquality(b0,bp)}");
            Console.WriteLine($"b1 == b2 {StructuralEquality(b1,b2)}");
            Console.WriteLine($"b1 == b3 {StructuralEquality(b1,b3)}");

            //deconstruct
            var (title,author,likes) = bp;
            Console.WriteLine($"Title : {title}; Author:{author}; Likes:{likes}");    


            // va dans le bon sens mais
            // on aurait pu avoir un constucteur de facon implicite avec toutes les props à la F#
            // pareil pour le deconstruct
            
            //Movie m = new("Batman begins",4500000);

            var m = new Movie(){Title="Batman begins",Budget=42};

        }

        public static bool StructuralEquality(Book x, Book y)=>
            x==y;
    }
}
