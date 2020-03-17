using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//This class is responsible for the asynchronous request to the APOD API
namespace ProjectNASA
{
    class APODManager
    {
        private readonly string url = "https://api.nasa.gov/planetary/apod?"; 
        private HttpClient connection = new HttpClient();

        public APODManager() { }
        public async Task<APOD> getAPOD(DateTime selectedDate)
        {
            string requestUrl = url + GlobalKeys.NASApiKey;
            requestUrl += "&date=" + selectedDate.ToString("yyyy-MM-dd");

            var response = await connection.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<APOD>(content);
        }
    }
}

/*Learner's note:
 * You can convert the string data you read from http stream to json:
 *      var obj = JObject.Parse(content);
 * And then access the specific fields you need w/o a class:
 *      System.Diagnostics.Debug.WriteLine("obj: " + obj["copyright"]);
 */
