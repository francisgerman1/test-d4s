using RestSharp;
using StarWars.Core.Api;
using System.Text.Json;

namespace StarWars.Core.Integration
{
    public class DataExtractor
    {
        public static Task<IEnumerable<T>> GetAll<T>(string uri)
        {
            return Task.Run(async () =>
            {
                RestRequest request = new RestRequest(uri, Method.Get);
                RestClient restClient = new();
                List<T> data = new();

                var response = restClient.Get(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var body = JsonSerializer.Deserialize<Model<T>>(response.Content);
                    data.AddRange(body.results);

                    if (body.next != null)
                    {
                        data.AddRange(await GetAll<T>(body.next));
                    }
                    else
                    {
                        return data.AsEnumerable();
                    }
                }
                else
                {
                    throw new Exception();
                }

                return data.AsEnumerable();
            });

        }

        public static Task<IEnumerable<T>> GetAllFromJson<T>()
        {
            using (StreamReader r = new StreamReader($"{Directory.GetCurrentDirectory()}/Json/{typeof(T).Name}.json"))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonSerializer.Deserialize<List<T>>(json);
                return Task.FromResult(items.AsEnumerable());
            }
        }
    }
}
