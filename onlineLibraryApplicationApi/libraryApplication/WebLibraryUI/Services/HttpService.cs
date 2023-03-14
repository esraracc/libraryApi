using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebLibraryUI.Dtos;

namespace WebLibraryUI.Services
{
    public class HttpService
    {
        static string url = "http://localhost:5000/api/";
        static HttpClient client = new HttpClient();

        public static async Task<List<BookDto>> Get(string method)
        {
            string serviceUrl = $"{url}{method}";
            using (var response = await client.GetAsync(new Uri(serviceUrl)))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BookDto>>(apiResponse);
            }
        }
        //public static async Task<string> Post(string method, Personel personel)
        //{
        //    string serviceUrl = $"{url}{method}";
        //    StringContent httpContent = new StringContent(JsonConvert.SerializeObject(personel), Encoding.UTF8, "application/json");
        //    using (HttpResponseMessage response = await client.PostAsync(serviceUrl, httpContent))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //}
        //public static async Task<string> Put(string method, Personel personel)
        //{
        //    string serviceUrl = $"{url}{method}";
        //    StringContent httpContent = new StringContent(JsonConvert.SerializeObject(personel), Encoding.UTF8, "application/json");
        //    using (HttpResponseMessage response = await client.PutAsync(serviceUrl, httpContent))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //}
        //public static async Task<string> Delete(string method)
        //{
        //    string serviceUrl = $"{url}{method}";
        //    using (HttpResponseMessage response = await client.DeleteAsync(serviceUrl))
        //    {
        //        return await response.Content.ReadAsStringAsync();
        //    }
        //}

    }
}
