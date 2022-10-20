using hot_demo.services;

namespace hot_demo.mutations;

public partial class Mutation
{
    private readonly Service _service;

    public Mutation(Service service)
    {
        _service = service;
    }
}