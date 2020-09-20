using partial_methods_decorators;

namespace partial_methods
{
    public partial class Circle
    {
       public Circle(int radius){
            Radius = radius;
        }

        public int Radius { get; }

        [DisplayWith(Name="Toto")]    
        public partial void Display();
    }
}