namespace partial_methods
{
    public partial class Rectangle
    {
       public partial void Display()
        => System.Console.WriteLine($"Rectangle: {Width}m x {Height}m");
    }
}