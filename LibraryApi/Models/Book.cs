namespace LibraryApi.Models
{
    public class Book
    {
        public string Id { get; set; } 
        public string Title { get; set; }  
        public BookAuthor Author { get; set; }  
        public int PublishedYear { get; set; }  
        public string Genre { get; set; }  
    }
}
