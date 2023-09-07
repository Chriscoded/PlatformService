using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlatformService.Dtos;
// using Microsoft.Extensions.Configuration;
namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent
                (
                    JsonSerializer.Serialize(plat),
                    Encoding.UTF8,
                    "application/json"
                );
                //sending contents of platformservice to another service {CommandService} using the local base url stored in appsettings.developer.json
            var response = await  httpClient.PostAsync($"{configuration["CommandService"]}", httpContent);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to CommandService was OK");
            }
            else
            {
                 Console.WriteLine("--> Sync Post to CommandService was NOT OK");
            }
        }
    } 
}