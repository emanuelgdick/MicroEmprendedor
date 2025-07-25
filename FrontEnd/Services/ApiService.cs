using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web.Mvc;
using System.Xml.Linq;
using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        //LOCALIDAD
        #region
        public async Task<List<Localidad>> GetAllLocalidades(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Localidad?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Localidad>>(contents);
            return APIResponse;
        }

        public async Task<Localidad> AddLocalidad(Localidad localidad, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Localidad>($"api/Localidad/AddLocalidad", localidad);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Localidad>(contents);
            return APIResponse;
        }

        public async Task<Localidad> GetLocalidadById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Localidad/GetLocalidadById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Localidad>(contents);
            return APIResponse;
        }

        public async Task UpdateLocalidad(int id, Localidad localidad, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Localidad>($"api/Localidad/UpdateLocalidad?id={id}", localidad);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteLocalidad(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Localidad/DeleteLocalidad?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion



        //RUBRO
        #region
        public async Task<List<Rubro>> GetAllRubros(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Rubro?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Rubro>>(contents);
            return APIResponse;
        }

        public async Task<Rubro> AddRubro(Rubro rubro, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Rubro>($"api/Rubro/AddRubro", rubro);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Rubro>(contents);
            return APIResponse;
        }

        public async Task<Rubro> GetRubroById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Rubro/GetRubroById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Rubro>(contents);
            return APIResponse;
        }

        public async Task UpdateRubro(int id, Rubro rubro, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Rubro>($"api/Rubro/UpdateRubro?id={id}", rubro);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteRubro(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Rubro/DeleteRubro?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion




        //MICROEMPRENDEDOR
        #region
        public async Task<List<MicroEmprendedor>> GetAllMicroEmprendedores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/MicroEmprendedor?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();

            var APIResponse = JsonConvert.DeserializeObject<List<MicroEmprendedor>>(contents);
            return APIResponse;
        }

        public async Task<List<MicroEmprendedor>> GetMicroEmprendedoresFiltrados(int localidad, int rubro, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/MicroEmprendedor/GetMicroEmprendedoresFiltrados?localidad={localidad}&rubro={rubro}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<MicroEmprendedor>>(contents);
            return APIResponse;
        }

        public async Task<MicroEmprendedor> AddMicroEmprendedor(MicroEmprendedor microEmprendedor, string token)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<MicroEmprendedor>($"api/MicroEmprendedor/AddMicroEmprendedor", microEmprendedor);
            response.EnsureSuccessStatusCode();
          
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<MicroEmprendedor>(contents);
            return APIResponse;
        }

        public async Task<MicroEmprendedor> GetMicroEmprendedorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/MicroEmprendedor/GetMicroEmprendedorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<MicroEmprendedor>(contents);
            return APIResponse;
        }

        public async Task UpdateMicroEmprendedor(int id, MicroEmprendedor microEmprendedor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<MicroEmprendedor>($"api/MicroEmprendedor/UpdateMicroEmprendedor?id={id}", microEmprendedor);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteMicroEmprendedor(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/MicroEmprendedor/DeleteMicroEmprendedor?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //TIPO DE DOCUMENTO
        #region
        public async Task<List<TipoDocumento>> GetAllTipoDocumentos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoDocumento?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoDocumento>>(contents);
            return APIResponse;
        }

        public async Task<TipoDocumento> AddTipoDocumento(TipoDocumento tipoDocumento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoDocumento>($"api/TipoDocumento/AddTipoDocumento", tipoDocumento);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoDocumento>(contents);
            return APIResponse;
        }

        public async Task<TipoDocumento> GetTipoDocumentoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoDocumento/GetTipoDocumentoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoDocumento>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoDocumento(int id, TipoDocumento tipoDocumento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoDocumento>($"api/TipoDocumento/UpdateTipoDocumento?id={id}", tipoDocumento);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoDocumento(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoDocumento/DeleteTipoDocumento?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

     

        //TOTALES
        public async Task<Models.DTOs.TotalesDTO> GetTotales(int id,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Home?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TotalesDTO>(contents);
            return APIResponse;
        }

    }
}
