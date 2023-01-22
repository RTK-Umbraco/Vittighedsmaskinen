namespace Vittighedsmaskinen.Models
{
    public class JokeModel
    {
        public string Joke { get; set; }
        public string? Answer { get; set; }
        public string Category { get; set; }
        public JokeModel(string joke, string? answer, JokeCategoryModel category)
        {
            Joke = joke;
            Answer = answer;
            Category = category.ToString();
        }
    }
}
