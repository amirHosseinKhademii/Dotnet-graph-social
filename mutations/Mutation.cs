using hot_demo.services;

namespace hot_demo.mutations;

public partial class Mutation
{
    private readonly UserService _userService;
    private readonly BookService _bookService;

    public Mutation(UserService userService, BookService bookService)
    {
        _userService = userService;
        _bookService = bookService;
    }
}