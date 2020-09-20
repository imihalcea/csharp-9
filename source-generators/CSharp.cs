using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSharp 
{
    public static string WithBraces(string main, params string[] str) =>
        $"{main}{Environment.NewLine}{{{Environment.NewLine}{And(str)}{Environment.NewLine}}}";
    public static string And(params string[] strs) =>
        string.Join(Environment.NewLine,strs);

    public static string Namespace(string ns) => $"namespace {ns}";

    public static string PublicClass(string className) => $"public class {className}";

    public static string Source(string str) => str;
    public static string Using(string ns) => $"using {ns};";

    public static string Properties((string propName, string propType)[] ps) =>
      And(ps.Select(p=>$"public {p.propType} {p.propName} {{get;}}").ToArray());
          
     public static string Constructor(string className,(string propName, string propType)[] ps)
     {
          var ctorParams = String.Join(",",ps.Select(p=>$"{p.propType} arg_{p.propName}").ToArray());  
          var ctorDef = $"public {className}({ctorParams})";
          var ctorBody = ps.Select(p=>$"{p.propName}=arg_{p.propName};").ToArray();
          return WithBraces(ctorDef,ctorBody);
     }

     public static string AllProperty(string className, (string propName, string propType)[] ps,  IEnumerable<string[]> dataLines){
         var allPropDef = $"public static List<{className}> All {{get;}}=new List<{className}>()";
         return WithBraces(allPropDef,dataLines.Select(ds=> $"new {className}({ToParams(ps,ds)}),").ToArray())+";";
     }

     private static string ToParams((string propName, string propType)[] ps, string[] values)
     {
         var myparams = new string[values.Length]; 
         for(int i=0; i<values.Length;i++){
              if(ps[i].propType.Equals("string")){
                  myparams[i]= $"\"{values[i]}\"";
              }else{
                  myparams[i] = values[i];
              }  
         }
         return String.Join(",",myparams);
     }
}