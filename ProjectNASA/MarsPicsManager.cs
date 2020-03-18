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
        public async Task<MarsPicsObject> getMarsPicsRover(string roverName)
        {
            string requestUrl = url + roverName + "/latest_photos?" + GlobalKeys.NASApiKey;
            var response = await connection.GetAsync(requestUrl);
            System.Diagnostics.Debug.WriteLine("response: " + response);

            var content = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("content: " + content);

            return JsonConvert.DeserializeObject<MarsPicsObject>(content);
        }

        public async Task<MarsPicsObject> getMarsPiscRoverCam(string roverName, string cameraName)
        {
            if (cameraName.Equals("Front Hazard Avoidance Camera")) cameraName = "FHAZ";
            else if (cameraName.Equals("Rear Hazard Avoidance Camera")) cameraName = "RHAZ";
            else if (cameraName.Equals("Mast Camera")) cameraName = "MAST";
            else if (cameraName.Equals("Chemistry and Camera Complex")) cameraName = "CHEMCAM";
            else if (cameraName.Equals("Mars Hand Lens Imager")) cameraName = "MAHLI";
            else if (cameraName.Equals("Mars Descent Imager")) cameraName = "MARDI";
            else if (cameraName.Equals("Navigation Camera")) cameraName = "NAVCAM";
            else if (cameraName.Equals("Panoramic Camera")) cameraName = "PANCAM";
            else if (cameraName.Equals("Miniature Thermal Emission Spectrometer (Mini-TES)")) cameraName = "MINITES";

            string requestUrl = url + roverName + "/latest_photos?" + "&camera=" + cameraName + GlobalKeys.NASApiKey;
            var response = await connection.GetAsync(requestUrl);
            System.Diagnostics.Debug.WriteLine("response: " + response);

            var content = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("content: " + content);

            return JsonConvert.DeserializeObject<MarsPicsObject>(content);
        }
    }
}
