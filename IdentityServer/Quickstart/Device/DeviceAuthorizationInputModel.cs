using IdentityServer.Quickstart;

namespace IdentityServer.Quickstart
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}