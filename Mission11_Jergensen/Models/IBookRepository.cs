namespace Mission11_Jergensen.Models;

public interface IBookRepository
{
    public IQueryable<Book> Books { get;   }
}