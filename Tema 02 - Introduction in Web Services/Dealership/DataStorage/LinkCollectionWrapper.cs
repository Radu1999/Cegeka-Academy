
namespace Dealership.Data
{
    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        public List<LinkWrapper<T>> Value { get; set; } = new List<LinkWrapper<T>>();
        public LinkCollectionWrapper()
        {
        }
        public LinkCollectionWrapper(List<LinkWrapper<T>> value)
        {
            Value = value;
        }
    }
}
