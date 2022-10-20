using hot_demo.types;

namespace hot_demo.queries
{
    public partial class Query
    {
        public async Task<Book?> GetBook(string id) =>
            await _service.GetBookByIdAsync(id);

        public async Task<List<Book>> GetBooks() =>
            await _service.GetBooksAsync();
    }
}