namespace PortfolioServer.Models
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class CollectionName : Attribute
    {
        public CollectionName(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Name cannot be null or empty string");

            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
