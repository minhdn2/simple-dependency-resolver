using Simple_Dependency_Resolver.Interface;

namespace Simple_Dependency_Resolver
{
    public class Cart
    {
        private readonly IDatabase _db;

        public Cart(IDatabase db)
        {
            _db = db;
        }

        public void Checkout()
        {
            _db.Save("Checkout_DB");
        }
    }
}
