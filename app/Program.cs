using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChuckNorrisJokes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press Enter to get a random Chuck Norris joke, or type 'exit' to quit.");

            while (true)
            {
                var input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                string joke = await GetRandomJokeAsync();
                Console.WriteLine(joke);
                Console.WriteLine("\nPress Enter for another joke or type 'exit' to quit.");
            }
        }

        private static async Task<string> GetRandomJokeAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://api.chucknorris.io/jokes/random");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic jokeObj = JsonConvert.DeserializeObject(content);
                    return jokeObj.value;
                }
                else
                {
                    return "Error: Failed to fetch a joke from the API.";
                }
            }
        }
    }
}
