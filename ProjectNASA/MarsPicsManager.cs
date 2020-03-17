using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace ProjectNASA
{
    class MarsPicsManager
    {
        private readonly string url = "https://api.nasa.gov/mars-photos/api/v1/rovers/"; 
        private HttpClient connection = new HttpClient();

        public MarsPicsManager() { }
        //public async Task<APOD> getAPOD(DateTime selectedDate)
        //{
        //    string requestUrl = url + GlobalKeys.NASApiKey;
        //    requestUrl += "&date=" + selectedDate.ToString("yyyy-MM-dd");

        //    var response = await connection.GetAsync(requestUrl);
        //    System.Diagnostics.Debug.WriteLine("response: " + response);

        //    var content = await response.Content.ReadAsStringAsync();
        //    System.Diagnostics.Debug.WriteLine("content: " + content);

        //    return JsonConvert.DeserializeObject<APOD>(content);
        //}
    }
}
