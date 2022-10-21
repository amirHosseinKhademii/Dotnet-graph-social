using hot_demo.types;

namespace hot_demo.interfaces.services;

public interface IBookService
{
    public Task<List<Book>> GetBooksAsync();

    public Task<Book?> GetBookByIdAsync(string id);

    public Task<Book> CreateBookAsync(string title);

    public Task<string> RemoveBookAsync(string id);

    public Task<Book> UpdateBookAsync(Book book);

    public Task<string> UpdateBookAuthorAsync(string id, string name);
}