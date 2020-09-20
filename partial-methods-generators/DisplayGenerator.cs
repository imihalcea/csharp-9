using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace partial_methods_generators
{

    [Generator]
    public class DisplayGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
          //context.AddSource("toto.cs",SourceText.From($"[assembly: System.Reflection.AssemblyMetadata(\"alert\",\"yoyo\")]", Encoding.UTF8));
           context.AddSource("Circle.Impl.cs",GenerateCode());
        }
 
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        //juste pour la demo
        //imaginer un code qui explore dynamiquement pour trouver la methode avec l'attribut en question
        public string GenerateCode()
        {
            return  @"
            namespace partial_methods
            {
                public partial class Circle
                {
                    public partial void Display() =>
                        System.Console.WriteLine(""Cercle Toto de rayon "" + Radius +  "" cm"");     
                }
            }";
        }

    }
}
