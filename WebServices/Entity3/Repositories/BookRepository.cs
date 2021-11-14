using System;
using WebService1.Entity3.Models;
using System.Data.SqlClient;

namespace WebService1.Entity3.Repositories
{
    public class BookRepository : IBookRepository
    {
        SqlConnection connect = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=HomeWbase;Trusted_Connection=True;");
        public void Post(Book book)
        {
            if (book.BookName != "" && book.AuthorName != "")
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("insert into Books(Bookname, Authorname) values(@namebook,@nameauthor)", connect);
                //connect.Open();
                cmd.Parameters.AddWithValue("@namebook",book.BookName);
                cmd.Parameters.AddWithValue("@nameauthor", book.AuthorName);
                connect.Close();
            }
        }

        public void Put(Book book)
        {
            SqlCommand cmd = new SqlCommand("update Books set Bookname=@namebook, Authorname=@nameauthor where ID=@Id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@Id", book.Id);
            cmd.Parameters.AddWithValue("@namebook", book.BookName);
            cmd.Parameters.AddWithValue("@nameauthor", book.AuthorName);
            connect.Close();
        }

        public void Delete(int Id)
        {
            if (Id > 0)
            {   connect.Open();
                SqlCommand cmd = new SqlCommand("delete from Books where ID=@Id", connect);
                cmd.Parameters.AddWithValue("@Id", Id);
                connect.Close();

            }
            else
            {
                Console.WriteLine("Book with this Id not found");
            }
        }
    }
}
