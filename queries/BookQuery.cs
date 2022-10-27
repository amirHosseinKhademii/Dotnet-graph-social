using hot_demo.services;
using hot_demo.types;

namespace hot_demo.queries
{
    public partial class Query
    {
        public async Task<Book?> GetBook([Service] Service service, string id) =>
            await service.GetBookByIdAsync(id);

        public async Task<List<Book>> GetBooks([Service] Service service) =>
            await service.GetBooksAsync();
    }
}