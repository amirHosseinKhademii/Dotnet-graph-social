
using hot_demo.types;


namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<Book> CreateBook(string title) => await _service.CreateBookAsync(title);

        public async Task<string> DeleteBook(string id) => await _service.RemoveBookAsync(id);

        public async Task<Book> UpdateBook(Book book) => await _service.UpdateBookAsync(book);

        public async Task<string> UpdateAuthor(string id, string author) =>
            await _service.UpdateBookAuthorAsync(id, author);
    }
}