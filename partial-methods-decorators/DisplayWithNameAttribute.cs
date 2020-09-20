
namespace partial_methods_decorators
{

[System.AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = true)]

public sealed class DisplayWithAttribute : System.Attribute
{
    public DisplayWithAttribute()
    {

    }
    
    public string Name
    {
        get; set;
    }
    

}
}