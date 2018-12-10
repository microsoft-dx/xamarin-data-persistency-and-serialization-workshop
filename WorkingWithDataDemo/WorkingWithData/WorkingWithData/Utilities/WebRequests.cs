using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithData.Utilities
{
    public static class WebRequests
    {
        private const string API_BASE_URL = "https://transportbwebapi.azurewebsites.net/api";

        // Use this to Handle a Web Request
        public static async Task<string> GetAsync(string controller, Dictionary<string, string> parameters = null)
        {
            StringBuilder uri = new StringBuilder($"{API_BASE_URL}/{controller}"); // construct url for web request
            if ((parameters != null) && (parameters.Count > 0)) // if request has 1 or more parameters ...
            {
                // iterate over all parameters and append them to url in accordance with url specific syntax
                uri.Append("?");
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    uri.Append($"{parameter.Key}={parameter.Value}&");
                }
                uri.Remove(uri.Length - 1, 1); // as the last ampersand is not needed because the last parameter
                                               // is not followed by any other parameters, remove it
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            // return request response
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
