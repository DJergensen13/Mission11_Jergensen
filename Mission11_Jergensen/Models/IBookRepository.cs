namespace Mission11_Jergensen.Models;

public class IBookRepository
{
    public IQueryable<Book> Books { get;   }
}