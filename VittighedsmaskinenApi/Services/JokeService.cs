using Newtonsoft.Json.Linq;
using Vittighedsmaskinen.Models;
using Vittighedsmaskinen.Repository;

namespace Vittighedsmaskinen.Services
{
    public class JokeService
    {
        public JokeModel GetRandomJoke(List<JokeModel> jokes)
        {
            try
            {
                Random rnd = new Random();
                var randomJokeNumber = rnd.Next(jokes.Count);

                var randomJoke = jokes[randomJokeNumber];

                RemoveJoke(jokes, randomJoke);

                return randomJoke;
            }
            catch (ArgumentException e)
            {
                throw new Exception("Jokes out of stock", e);
            }
        }

        public JokeModel GetJokeBasedOnCategory(List<JokeModel> jokes, string category)
        {
            try
            {
                var categoryJokes = jokes.Where(j => j.Category.ToLowerInvariant() == category.ToLowerInvariant()).ToList();

                Random rnd = new Random();
                var randomJokeNumber = rnd.Next(categoryJokes.Count);

                var randomJoke = categoryJokes[randomJokeNumber];
                RemoveJoke(jokes, randomJoke);

                return randomJoke;
            }
            catch (ArgumentException e)
            {
                throw new Exception($"Jokes from this category: {category} is out of stock", e);
            }
        }

        private void RemoveJoke(List<JokeModel> jokes, JokeModel joke)
        {
            jokes.Remove(joke);
        }
    }
}
