using Vittighedsmaskinen.Models;

namespace Vittighedsmaskinen.Repository
{
    public class JokeRepository
    {
        public List<JokeModel> CreateJokes()
        {
            var jokes = new List<JokeModel>
            {
                //Dad jokes
                new JokeModel("Hvad er forskellen på en løve og en giraf?", "En giraf kan løve men en løve kan ikke giraf.", JokeCategoryModel.Dad),
                new JokeModel("Hvorfor griner dværgene når de spiller fodbold?", "Fordi græsset kilder dem i røven.", JokeCategoryModel.Dad),

                //Mom jokes
                new JokeModel("Din mor så fed at hvis hun ikke var blevet født, havde fedme ikke været et globalt sundhedsproblem.", null, JokeCategoryModel.Mom),
                new JokeModel("Din mor er så fed at når hun spiser behøver hun ikke vaske op, for hun spiser også tallerknen.", null, JokeCategoryModel.Mom),
            };

            return jokes;
        }
    }
}
