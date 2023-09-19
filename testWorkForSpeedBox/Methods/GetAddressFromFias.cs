using System.Net.Http.Headers;
using System.Text.Json;
using testWorkForSpeedBox.Models;

namespace testWorkForSpeedBox.Methods
{
    public class GetAddressFromFias
    {
        public async Task<int?> Get(Guid fias)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = GetToken.auth;
                var response = await client.GetAsync("https://api.edu.cdek.ru/v2/location/cities/?fias_guid=" + fias);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<GetAddressFromFiasDTO[]>(responseString);
                return json[0].code;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
    }
}
