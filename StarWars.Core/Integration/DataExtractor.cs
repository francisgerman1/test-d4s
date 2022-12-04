using RestSharp;
using StarWars.Core.Data;
using System.Text.Json;

namespace StarWars.Core.Integration
{
    public class DataExtractor
    {
        public static IEnumerable<T> GetAll<T>(string uri)
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
                    data.AddRange(GetAll<T>(body.next));
                }
                else
                {
                    return data;
                }
            }
            else
            {
                throw new Exception();
            }

            return data;
        }
    }
}
