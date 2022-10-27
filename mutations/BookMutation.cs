
namespace hot_demo.mutations
{
    public partial class Mutation
    {
        public async Task<Book> CreateBook([Service] Service service, string title) =>
            await service.CreateBookAsync(title);

        public async Task<string> DeleteBook([Service] Service service, string id) => await service.RemoveBookAsync(id);

        public async Task<Book> UpdateBook([Service] Service service, Book book) => await service.UpdateBookAsync(book);

        public async Task<string> UpdateAuthor([Service] Service service, string id, string author) =>
            await service.UpdateBookAuthorAsync(id, author);
    }
}