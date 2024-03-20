namespace Mission11_Jergensen.Models.ViewModels;

public class BooksList
{
    public IQueryable<Book> Books { get; set; }
    public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
}