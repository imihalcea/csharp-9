namespace records
{
    public record Book
    {

        public Book(string title, string author, int likes) =>
           (Title,Author,Likes) = (title,author,likes);

        public void Deconstruct(out string title, out string author, out int likes) =>
            (title,author,likes)=(Title,Author,Likes);

        public string Title {get; init;}
        public string Author {get; init;}
        public int Likes {get; init;}

           

        public override string ToString() =>
            $"{Title} by {Author} | {Likes} likes";   
    }
}