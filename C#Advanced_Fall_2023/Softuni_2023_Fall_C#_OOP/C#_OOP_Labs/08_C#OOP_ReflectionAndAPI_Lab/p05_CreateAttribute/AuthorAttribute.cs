


namespace AuthorProblem
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {

        public AuthorAttribute(string authorName)
        {
            Name = authorName;
        }
        public string Name { get; set; }
    }
}
