
using Lecture_4;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        Book book = new Book()
        {
            Name = "Kitap",
            Author = "xxx"
        };

        Student student = new()
        {
            Name = "Oguzhan",
        };


        var s = student + book;


        Server server = new();

        if (server >> 5)
        {

        }
        if (server << 5)
        {

        }

        Database database = new Database();

        if (database + DatabaseType.SQLServer) { }


    }
}

class Student
{
    public string Name { get; set; }
    public List<Book> Books { get; set; } = new();

    public static Student operator +(Student s, Book b)
    {
        s.Books.Add(b);
        return s;
    }

}
class Book
{
    public string Name { get; set; }
    public string Author { get; set; }
}