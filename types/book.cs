namespace hot_demo.types;
public record Book(Guid Id, string Title, Author Author);

public record Author(string Name);


