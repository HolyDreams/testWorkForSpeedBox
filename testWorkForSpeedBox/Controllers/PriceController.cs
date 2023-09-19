using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using testWorkForSpeedBox.Methods;
using testWorkForSpeedBox.Models.Main;
using testWorkForSpeedBox.Models.Tariff.GetTariff;
using testWorkForSpeedBox.Models.Tariff.SendTariff;

namespace testWorkForSpeedBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        //06c915aa-7511-4b24-acfa-c99638405217 - Питер
        //0c5b2444-70a0-4932-980c-b4dc0d3f02b5 - Москва
        [HttpPost]
        [Route("check")]
        public async Task<ActionResult<float>> Check(PriceCheck item)
        {
            try
            {
                var getToken = new GetToken();
                await getToken.Get();

                var getAddress = new GetAddressFromFias();
                var fromAddress = await getAddress.Get(item.Sender);
                var intoAddress = await getAddress.Get(item.Accepter);
                if (fromAddress == null || intoAddress == null)
                    return BadRequest("Не найдено города по данному коду ФИАС");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = GetToken.auth;

                var value = JsonSerializer.Serialize(new SendTariff()
                {
                    from_location = new LocationTariff()
                    {
                        code = fromAddress
                    },
                    to_location = new LocationTariff()
                    {
                        code = intoAddress
                    },
                    packages = new PackageTariff[]
                    {
                        new PackageTariff()
                        {
                            weight = item.Weight,
                            height = item.size.Height / 10,
                            width = item.size.Width / 10,
                            length = item.size.Length / 10
                        }
                    }
                });
                var response = await client.PostAsync("https://api.edu.cdek.ru/v2/calculator/tarifflist",
                    new StringContent(value, Encoding.UTF8, "application/json"
                    ));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<GetTariffDTO>(responseString);
                if (json.tariff_codes.Count() == 0)
                    return BadRequest("Для такого груза не найдено подходящего тариффа");

                return json.tariff_codes.Min(a => a.delivery_sum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
