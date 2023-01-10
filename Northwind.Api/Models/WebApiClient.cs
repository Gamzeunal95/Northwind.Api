using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Northwind.Api.Models
{
    public class WebApiClient<T> where T : class //abstract olarak yapıldı. Base olarak kullanıp kod tekrarı yapmamak için abstact olarak seçtik.
    {                                      // ve generic olacak  T tipinden ne gönderildiyse 
        public string BaseUrl { get; } = @"https://northwind.vercel.app/";
        public HttpClient Client { get; }

        public WebApiClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUrl);
        }
        public async Task<T> Get(string url)
        {
            HttpResponseMessage response = await Client.GetAsync(url);
            var resultstring = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(resultstring);
            return result;

        }

        public async Task<List<T>> GetAll(string url)
        {
            HttpResponseMessage response = await Client.GetAsync(url);
            var resultstring = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(resultstring);
            return result;
        }

        public async Task<bool> Post(string url, T model)  // create ettik Homecontroller içine index kısmına yazdıklarımızı
        {
            var serilizeObject = System.Text.Json.JsonSerializer.Serialize(model);
            var stringContext = new StringContent(serilizeObject, Encoding.UTF8, "application/json");

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.PostAsync(url, stringContext);
            //var resultstring = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)  // Status success ise true dön
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            string deleteUrl = url + id.ToString();
            HttpResponseMessage response = await Client.DeleteAsync(deleteUrl);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public async Task<T> Put(string url, T model) // Put güncellemek için kullanılır.
        {
            var serilizeObject = System.Text.Json.JsonSerializer.Serialize(model);
            var stringContext = new StringContent(serilizeObject, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PutAsync(url, stringContext);
            var resultstring = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(resultstring);
            return result;

        }

    }
}
