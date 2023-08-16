namespace P03_Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < numberOfArticles; i++)
            {
                List<string> input = Console.ReadLine().Split(", ").ToList();
                articles.Add(new Article(input[0], input[1], input[2]));
            }
            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}