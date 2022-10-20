using hot_demo.services;

namespace hot_demo.queries;

public partial class Query
{
    private readonly UserService _userService;
    private readonly BookService _bookService;

    public Query(UserService userService, BookService bookService)
    {
        _userService = userService;
        _bookService = bookService;
    }
}