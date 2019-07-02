using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jasarsoft.AmadeusDev.Repo.Helper
{
    public static class Server
    {
        public static Token GetToken()
        {
            WebRequest request = WebRequest.Create("https://test.api.amadeus.com/v1/security/oauth2/token ");
            request.Method = "POST";

            string postData = "grant_type=client_credentials&client_id=e9TCUNGTyRoHvrA9fbT9zFhAEUzLlGA7&client_secret=1kK4cPy4DnQopE6d";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
#if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: TOKEN");
            System.Diagnostics.Debug.WriteLine(((HttpWebResponse)response).StatusDescription);
#endif
            string responseFromServer;
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
#if DEBUG
                System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: DATA");
                System.Diagnostics.Debug.WriteLine(responseFromServer);
#endif
            }

            return JsonConvert.DeserializeObject<Token>(responseFromServer);
        }

        public static async Task<Token> GetTokenAsync()
        {
            WebRequest request = WebRequest.Create("https://test.api.amadeus.com/v1/security/oauth2/token ");
            request.Method = "POST";

            string postData = "grant_type=client_credentials&client_id=e9TCUNGTyRoHvrA9fbT9zFhAEUzLlGA7&client_secret=1kK4cPy4DnQopE6d";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = await request.GetRequestStreamAsync();
            await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = await request.GetResponseAsync();

            string responseFromServer;
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = await reader.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<Token>(responseFromServer);
        }

        public static string Get(string uri, Token token)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers.Add("Authorization", String.Format("{0} {1}", token.Token_type, token.Access_token));

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string data = reader.ReadToEnd();
#if DEBUG
                        System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
                        System.Diagnostics.Debug.WriteLine(data);
#endif
                        return data; //return reader.ReadToEnd();
                    }
        }

        public static async Task<string> GetAsync(string uri, Token token)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers.Add("Authorization", String.Format("{0} {1}", token.Token_type, token.Access_token));

            using (HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync()))
                using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
        }
    }
}
