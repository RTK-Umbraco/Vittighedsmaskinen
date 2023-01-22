using Microsoft.AspNetCore.Mvc;
using Milk_and_Cookies.Models.Extensions;
using Vittighedsmaskinen.Models;
using Vittighedsmaskinen.Repository;
using Vittighedsmaskinen.Services;

namespace Vittighedsmaskinen.Controllers
{
    [Route("api/joke/")]
    public class JokeController : Controller
    {

        [HttpGet("get-joke")]
        public JokeModel GetJoke()
        {
            CreateSession();

            var jokes = HttpContext.Session.GetObjectFromJson<List<JokeModel>>("Jokes");

            var jokesService = new JokeService();

            var joke = jokesService.GetRandomJoke(jokes);

            HttpContext.Session.SetObjectAsJson("Jokes", jokes);

            return joke;
        }

        [HttpGet("choose-joke-category")]
        public JokeModel GetJokeBasedOnCategory(string category)
        {
            CreateSession(); 

            var jokes = HttpContext.Session.GetObjectFromJson<List<JokeModel>>("Jokes");

            var jokesService = new JokeService();

            var joke = jokesService.GetJokeBasedOnCategory(jokes, category);

            HttpContext.Session.SetObjectAsJson("Jokes", jokes);

            return joke;
        }

        private void CreateSession()
        {
            var jokeRepository = new JokeRepository();

            var jokes = jokeRepository.CreateJokes();

            var session = HttpContext.Session.GetObjectFromJson<List<JokeModel>>("Jokes");

            if (session is null)
            {
                HttpContext.Session.SetObjectAsJson("Jokes", jokes);
            }
        }
    }
}
