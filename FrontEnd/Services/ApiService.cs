using System.Net.Http.Headers;
using FrontEnd.Models;
using Newtonsoft.Json;
namespace FrontEnd.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string _ApiURLPath = "http://localhost:5087/";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_ApiURLPath);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<PageResult<Calle>> GetAllCalles(string token,int pagesize,int pagenumber)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Calle?pagesize={pagesize}&pagenumber={pagenumber}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<PageResult<Calle>>(contents);
            return APIResponse;
        }

        public async Task AddCalle(Calle calle, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Calle>($"api/Calle/AddCalle", calle);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Calle> GetCalleById(int id, string token) 
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Calle/GetCalleById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Calle>(contents);
            return APIResponse;
        }

        public async Task UpdateCalle(int id,Calle calle, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Calle>($"api/Calle/UpdateCalle?id={id}", calle);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteCalle(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Calle/DeleteCalle?id={id}",null);
            response.EnsureSuccessStatusCode();

        }

    }
}
