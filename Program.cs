using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DadJokeApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            ConsoleKeyInfo consoleKeyInfo;

            do
            {

                Console.WriteLine("Press Enter key to get a random Chuck Norris joke.");
                 consoleKeyInfo = Console.ReadKey();

                Console.WriteLine(GetRandomChuckNorrisJoke());

                Thread.Sleep(5000);
                Console.Clear();
            } while (consoleKeyInfo.KeyChar == (int) ConsoleKey.Enter);


        }

        public static string GetRandomChuckNorrisJoke()
        {
            var webRequest = WebRequest.Create("http://api.icndb.com/jokes/random") as HttpWebRequest;
            string oneJoke = "";

            webRequest.ContentType = "application/json";


            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    string jokesAsJson = sr.ReadToEnd();

                    JObject jokes = JObject.Parse(jokesAsJson);

                    oneJoke = jokes["value"]["joke"].ToString();

                }
            }

            return oneJoke;
        }
    }
}
