using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using PFLOrderApp.Data.Order;

namespace PFLOrderApp
{
    // Client utilizes the Singleton Pattern
    public class Client
    {

        private HttpClient httpClient;
        private static Client client;

        private const string apiKey = "136085";
        private const string username = "miniproject";
        private const string password = "Pr!nt123";

        private const string baseUri = "https://testapi.pfl.com/";

        // Returns the singleton client
        public static Client GetInstance()
        {
            if(client == null)
            {
                client = new Client();
            }
            return client;
        }

        // Private constructor
        private Client()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUri);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Encode(username, password));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Encode the user:password combo
        private string base64Encode(string user, string pass)
        {
            string credentials = String.Format("{0}:{1}", user, pass);
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
        }

        // Retrieve a list of all products associated with this api
        public List<Product> GetProducts()
        {
            string fullUri = String.Format("products?apikey={0}", apiKey);
            HttpResponseMessage response = httpClient.GetAsync(fullUri).Result;
            var productResults = response.Content.ReadAsAsync<ProductListResponse>().Result;
            return productResults.results.data;
        }

        // Post a new order
        public HttpResponseMessage CreateOrder(Order o)
        {
            string fullUri = String.Format("orders?apikey={0}", apiKey);
            HttpResponseMessage response = httpClient.PostAsJsonAsync(fullUri, o).Result;
            System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync().Result);
            return response;
        }

    }
}