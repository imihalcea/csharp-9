using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;


//ne pas specifier le type du contructeur quand il est connu
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new

WriteLine(Display(new("foo", 12)));
//vs 
WriteLine(Display(new Foo("foo", 12)));

//WriteLine(DisplayMany(new []{new("foo",42),new("fizz",44)}));  //compile pas
WriteLine(DisplayMany(new Foo[] { new("foo", 42), new("fizz", 44) }));  //compile
                                                                        //vs 
WriteLine(DisplayMany(new Foo[] { new Foo("foo", 12) }));
//vs 
WriteLine(DisplayMany(new[] { new Foo("foo", 12) }));

WriteLine(DisplayBig(new()
{
    { "A", new() { 1, 2, 3 } },
    { "B", new() { 4, 5, 6 } }
}));
//vs
WriteLine(DisplayBig(new Dictionary<string, List<int>>(){
                                        {"A",new List<int>(){1,2,3}},
                                        {"B",new List<int>(){4,5,6}}
                                       }));



static string DisplayBig(Dictionary<string, List<int>> d)
{
    return "i'm lazy :)";
}

static string Display(Foo foo) =>
     $"{foo.Str};{foo.N}";

static string DisplayMany(Foo[] foos) =>
    String.Join(" ^^ ", foos.Select(Display).ToArray());

public class Foo
{
    public Foo(string foo, int n)
    {
        Str = foo;
        N = n;
    }

    public string Str { get; }
    public int N { get; }
}

