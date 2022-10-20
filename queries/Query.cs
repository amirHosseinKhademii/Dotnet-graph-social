using hot_demo.services;

namespace hot_demo.queries;

public partial class Query
{
    private readonly Service _service;

    public Query(Service service)
    {
        _service = service;
    }
}