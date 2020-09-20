using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using static CSharp;
using System.Diagnostics;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

#nullable enable

namespace source_generators
{
    [Generator]
    public class CsvGenerator: ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
           foreach(var file in FilesFromDisk(context,"csv"))
           {
              var (className, classCode) = GenerateClassFromCsv(file); 
              context.AddSource($"Csv_{className}",classCode); 
           }
          //context.AddSource("toto.cs",SourceText.From($"[assembly: System.Reflection.AssemblyMetadata(\"alert\",\"yoyo\")]", Encoding.UTF8));

        }
 
        public void Initialize(GeneratorInitializationContext context)
        {
            //do nothing
        }

        private string[] FilesFromDisk(GeneratorExecutionContext context, string fileExtension)
        {
            //pour une raison que j'ignore Roslyn ne charge pas les additional files specifies dans le csproj
            //la bonne façon de faire est d'utiliser FilesFromContext
            return new DirectoryInfo("/home/ionut/Code/Learn/csharp-9/source-generators_consumer/")
            .GetFiles($"*.{fileExtension}").Select(f=>f.FullName).ToArray();
        }
        private AdditionalText[] FilesFromContext(GeneratorExecutionContext context, string fileExtension) =>
            context.AdditionalFiles
            .Where(f=>Path.GetExtension(f.Path).Equals(fileExtension, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        
        
        private (string className, string classCode) GenerateClassFromCsv(string filePath)
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            return (className, GenerateCode(className, filePath));

        }

        private string GenerateCode(string className, string csvFilePath)
        {
            var csvData = ParseCsvFile(csvFilePath);
            var objectPoperties =GetObjectProperties(csvData);
            return Source(
                    And(
                        Using("System.Collections.Generic"),
                        WithBraces(
                            Namespace("CSV"),
                            WithBraces(
                                PublicClass(className),
                                Constructor(className, objectPoperties),
                                Properties(objectPoperties),
                                AllProperty(className, objectPoperties, csvData.Skip(1))
                            )
                        )
                    ));
        }

        public string[][] ParseCsvFile(string csvFilePath)
        {
            var data = File.ReadAllText(csvFilePath)
            .Split(Environment.NewLine)
            .Select(l=>l.Split(",").Select(f=>f.Trim()).ToArray())
            .ToArray();
            Contract.Requires(data.Length>0);
            Contract.Requires(data.All(line=>line.Length==data[0].Length));
            return data;    

        }

        private (string propName, string propType)[] GetObjectProperties(string[][] csvLines)
        {
           var headerLine = csvLines[0];
           var firstDataLine = csvLines[1];
           var types = firstDataLine.Select(d=>GetCsvFieldType(d)).ToArray();
           return headerLine.Zip(types).ToArray();
        }

        public static string GetCsvFieldType(string exemplar) => 
            exemplar switch
            {
                _ when bool.TryParse(exemplar, out _) => "bool",
                _ when int.TryParse(exemplar, out _) => "int",
                _ when double.TryParse(exemplar, out _) => "double",
                _ => "string"
            };
    }
}
