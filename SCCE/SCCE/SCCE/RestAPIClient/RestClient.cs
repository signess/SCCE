using System.Net.Http;
using System.Threading.Tasks;

namespace SCCE.RestAPIClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "http://coredata.sanesul.ms.gov.br/"; // Put your main host url here
        private const string LoginWebServiceUrl = MainWebServiceUrl + "api/funcionarios/"; // put your api extension url/uri here

        // This code matches the HTTP Request that we included in our api controller
        public async Task<bool> CheckLogin(string username, string password)
        {
            var httpClient = new HttpClient();
            
            var response = await httpClient.GetAsync(LoginWebServiceUrl  + username + "/autenticar/" + password);

            return response.IsSuccessStatusCode; // return either true or false
        }
    }
}
