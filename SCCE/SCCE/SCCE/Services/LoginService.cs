using SCCE.Models;
using SCCE.RestAPIClient;
using System.Threading.Tasks;

namespace SCCE.Services
{
    public class LoginService
    {
        // fetch the RestClient<T>
        readonly RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();

        // Boolean function with the following parameters of username & password.
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.CheckLogin(username, password);

            return check;
        }
    }
}
