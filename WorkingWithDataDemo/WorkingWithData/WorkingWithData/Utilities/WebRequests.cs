using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithData.Utilities
{
    public static class WebRequests
    {
        private const string API_BASE_URL = "";

        // Use this to Handle a Web Request
        public static async Task<string> GetAsync(string controller, Dictionary<string, string> parameters = null)
        {
            StringBuilder uri = new StringBuilder($"{API_BASE_URL}/{controller}");
            if ((parameters != null) && (parameters.Count > 0))
            {
                uri.Append("?");
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    uri.Append($"{parameter.Key}={parameter.Value}&");
                }
                uri.Remove(uri.Length - 2, 1);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri.ToString());
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
