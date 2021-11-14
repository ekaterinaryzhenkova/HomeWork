namespace WebService1.Entity3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Book(int id, string authorname, string bookname) { Id = id; BookName = bookname; AuthorName = authorname; }
    }
}
