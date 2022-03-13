namespace Dealership.Wrappers.Linking
{
    public class LinkWrapper<T> : LinkResourceBase            
    {
        public T Object { get; set; }
        public LinkWrapper(T obj)
        {
            Object = obj;
        }
    }
}
