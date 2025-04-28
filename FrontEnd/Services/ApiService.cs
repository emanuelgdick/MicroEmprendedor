using System.Net.Http.Headers;
using System.Web.Mvc;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
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


        //CALLES
        public async  Task<List<Calle>> GetAllCalles(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Calle?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Calle>>(contents);
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

        //AUTORES
        public async Task<PageResult<Autor>> GetAllAutores(string token, int pagesize, int pagenumber)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Autor?pagesize={pagesize}&pagenumber={pagenumber}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<PageResult<Autor>>(contents);
            return APIResponse;
        }

        public async Task AddAutor(Autor autor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Autor>($"api/Autor/AddAutor", autor);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Autor> GetAutorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Autor/GetAutorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Autor>(contents);
            return APIResponse;
        }

        public async Task UpdateAutor(int id, Autor autor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Autor>($"api/Autor/UpdateAutor?id={id}", autor);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteAutor(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Autor/DeleteAutor?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

    }
}
