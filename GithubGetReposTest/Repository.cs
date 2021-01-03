using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubGetReposTest
{
    public class Repository
    {
        [JsonProperty("name")] 
        public string Name { get; private set; }

        [JsonProperty("html_url")]
        public string Url { get; private set; }

        public static async Task<List<Repository>> GetRepositories(string url)
        {
            string responseBody;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                using var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            var kek = JsonConvert.DeserializeObject<List<Repository>>(responseBody);
            return kek;
        }
    }
}