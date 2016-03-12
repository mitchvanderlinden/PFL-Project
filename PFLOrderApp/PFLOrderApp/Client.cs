using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace PFLOrderApp
{
    public class Client
    {

        private HttpClient client;

        private const string apiKey = "136085";
        private const string username = "miniproject";
        private const string password = "Pr!nt123";

        private const string baseUri = "https://testapi.pfl.com/";

        public Client()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Encode(username, password));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string base64Encode(string user, string pass)
        {
            string credentials = String.Format("{0}:{1}", user, pass);
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
        }

        public List<Product> GetProducts()
        {
            string fullUri = String.Format("products?apikey={0}", apiKey);
            HttpResponseMessage response = client.GetAsync(fullUri).Result;
            var productResults = response.Content.ReadAsAsync<ProductListResponse>().Result;
            return productResults.results.data;
        }

    }
}