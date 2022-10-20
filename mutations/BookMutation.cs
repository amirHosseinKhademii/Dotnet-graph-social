
using hot_demo.types;


namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<Book> CreateBook(string title) => await _bookService.CreateAsync(title);

        public async Task<string> DeleteBook(string id) => await _bookService.RemoveAsync(id);

        public async Task<Book> UpdateBook(Book book) => await _bookService.UpdateAsync(book);

        public async Task<string> UpdateAuthor(string id, string author) =>
            await _bookService.UpdateAuthorAsync(id, author);
    }
}