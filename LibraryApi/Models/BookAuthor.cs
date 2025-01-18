using Newtonsoft.Json.Linq;

namespace LibraryApi.Models
{
    public class BookAuthor : IComparable<BookAuthor>
    {
        public string Id { get; set; }  
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }

        public int CompareTo(BookAuthor? other)
        {
            if (other == null) 
                return 1;

            return FullName.CompareTo(other.FullName);
        }
    }
}
