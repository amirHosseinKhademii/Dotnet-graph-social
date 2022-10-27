using hot_demo.types;

namespace hot_demo.subscriptions
{
    public partial class Subscription
    {
        [Subscribe]
        public Todo TodoAdded([EventMessage] Todo todo) => todo;
    }
}