using System.Runtime.CompilerServices; 

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers

public class M {

    [ModuleInitializer]
    internal static void WhenAssemblyLoads()
    {
        System.Console.WriteLine("I'm in");
    }
}