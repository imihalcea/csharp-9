namespace init_only_setters{

    public class Book
    {

        public Book(string title, string author)
        {
            Title = title;
            Author = author;    
        }
        public string Title {get;}
        public string Author {get;}

        public float Price {get; init;}

        public override string ToString() =>
            $"{Title} by {Author} | {Price:c}";

    }

}