using System.Drawing;
using System.Net.Http.Headers;
using System.Text.Json;
using testWorkForSpeedBox.Models;

namespace testWorkForSpeedBox.Methods
{
    public class GetToken
    {
        public static AuthenticationHeaderValue auth;
        public async Task Get()
        {
            try
            {
                var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", "EMscd6r9JnFiQ3bLoyjJY6eM78JrJceI"),
                    new KeyValuePair<string, string>("client_secret", "PjLZkKBHEiLK3YsjtNrt3TGNG0ahs3kG")
                };
                var client = new HttpClient();
                var response = await client.PostAsync("https://api.edu.cdek.ru/v2/oauth/token?parameters", new FormUrlEncodedContent(values));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<GetAccessDTO>(responseString);
                auth = new AuthenticationHeaderValue(json.token_type, json.access_token);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return;
            }
        }
    }
}
