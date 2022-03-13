namespace Dealership.Models
{
    public class Entity
    {
        private readonly IDictionary<string, object> expando = null;
        public Entity()
        {
           expando = new Dictionary<string, object>();
        }
        
        public Entity(object o)
        {

        }

    }
}
