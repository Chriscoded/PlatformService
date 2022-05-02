using System.Threading.Tasks;
using PlatformService.Dtos;
namespace PlatformService.SyncDataServices.Http
{
    public interface HttpCommandDataClient : ICommandDataClient
    {
        public Task SendPlatformToCommand(PlatformReadDto plat)
        {
            throw new System.NotImplementedException();
        }
    } 
}