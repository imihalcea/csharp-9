using System;
using System.Threading.Tasks;

    //Avant
    //namespace top-level-statements
    //{
    // class Program
    // {
    //     static async Task Main(string[] args)
    //     {
    //         await Task.Delay(100);
    //         Console.WriteLine("Hello World!");
    //     }
    // }
    //}

    //Aprés
    //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements


            await Task.Delay(100);
            Console.WriteLine("Hello World!");
            return 0;

    // pour les pointus : allez decompiler le source code et regardez le code genéré 
    // motivations :
    //    * rendre C# un langage plus concis
        