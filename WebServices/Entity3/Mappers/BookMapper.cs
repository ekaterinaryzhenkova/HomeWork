using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebService1.Entity3.Models;


namespace WebService1.Entity3.Mappers
{
    public class BookMapper : IBookMapper
    {
        static List<Book> _book = new List<Book>();

        public Book GetBook(int Id)
        {
            using (SqlConnection connect = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=HomeWbase;Trusted_Connection=True;"))
            {
                connect.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Books where ID=@id", connect);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = command.ExecuteReader();
                int id = 0;
                string bookname = ""; string authorname = "";
                while (reader.Read())
                {
                    id = Convert.ToInt32((reader.GetValue(0)).ToString());
                    bookname = Convert.ToString(reader.GetValue(2));
                    authorname = Convert.ToString(reader.GetValue(1));
                }
                Book book = new Book(id, bookname, authorname);
                return book;
            }
        }
        public List<Book> GetAllBooks()
        {

            using (SqlConnection connect = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=HomeWbase;Trusted_Connection=True;"))
            {
                connect.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Books", connect);
                SqlDataReader reader = command.ExecuteReader();
                int id = 0;
                string bookname = ""; string authorname = "";

                while (reader.Read())
                {

                    id = Convert.ToInt32((reader.GetValue(0)).ToString());
                    bookname = Convert.ToString(reader.GetValue(2));
                    authorname = Convert.ToString(reader.GetValue(1));
                    Book newbook = new Book(id, bookname, authorname);
                    _book.Add(newbook);

                }

                connect.Close();
            }

            return _book;
        }
    }
}
