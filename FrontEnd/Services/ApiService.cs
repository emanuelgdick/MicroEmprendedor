using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web.Mvc;
using Frontend.Models;
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

        //ANEXOS
        #region

        public async Task<List<Anexo>> GetAllAnexos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Anexo?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Anexo>>(contents);
            return APIResponse;
        }

        public async Task<Anexo> AddAnexo(Anexo anexo, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Anexo>($"api/Anexo/AddAnexo", anexo);
            response.EnsureSuccessStatusCode();

            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Anexo>(contents);
            return APIResponse;
        }

        public async Task<Anexo> GetAnexoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Anexo/GetAnexoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Anexo>(contents);
            return APIResponse;
        }

        public async Task UpdateAnexo(int id, Anexo anexo, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Anexo>($"api/Anexo/UpdateAnexo?id={id}", anexo);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteAnexo(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Anexo/DeleteAnexo?id={id}", null);
            response.EnsureSuccessStatusCode();

        }
        #endregion

        //AUTORES
        #region
        public async Task<List<Autor>> GetAllAutores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Autor?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Autor>>(contents);
            return APIResponse;
        }

        public async Task<Autor> AddAutor(Autor autor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Autor>($"api/Autor/AddAutor", autor);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Autor>(contents);
            return APIResponse;
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
        #endregion

        //CALLES
        #region

        public async Task<List<Calle>> GetAllCalles(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Calle?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Calle>>(contents);
            return APIResponse;
        }

        public async Task<Calle> AddCalle(Calle calle, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Calle>($"api/Calle/AddCalle", calle);
            response.EnsureSuccessStatusCode();

            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Calle>(contents);
            return APIResponse;
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

        public async Task UpdateCalle(int id, Calle calle, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Calle>($"api/Calle/UpdateCalle?id={id}", calle);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteCalle(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Calle/DeleteCalle?id={id}", null);
            response.EnsureSuccessStatusCode();

        }
        #endregion

        //CATEGORIAS SOCIOS
        #region

        public async Task<List<CategoriaSocio>> GetAllCategoriasSocios(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CategoriaSocio?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<CategoriaSocio>>(contents);
            return APIResponse;
        }

        public async Task<CategoriaSocio> AddCategoriaSocio(CategoriaSocio categoriaSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CategoriaSocio>($"api/CategoriaSocio/AddCategoriaSocio", categoriaSocio);
            response.EnsureSuccessStatusCode();

            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CategoriaSocio>(contents);
            return APIResponse;
        }

        public async Task<CategoriaSocio> GetCategoriaSocioById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CategoriaSocio/GetCategoriaSocioById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<CategoriaSocio>(contents);
            return APIResponse;
        }

        public async Task UpdateCategoriaSocio(int id, CategoriaSocio categoriaSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<CategoriaSocio>($"api/CategoriaSocio/UpdateCategoriaSocio?id={id}", categoriaSocio);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteCategoriaSocio(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/CategoriaSocio/DeleteCategoriaSocio?id={id}", null);
            response.EnsureSuccessStatusCode();

        }
        #endregion

        //COBRADORES
        #region
        public async Task<List<Cobrador>> GetAllCobradores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Cobrador?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Cobrador>>(contents);
            return APIResponse;
        }

        public async Task<Cobrador> AddCobrador(Cobrador cobrador, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Cobrador>($"api/Cobrador/AddCobrador", cobrador);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Cobrador>(contents);
            return APIResponse;
        }

        public async Task<Cobrador> GetCobradorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Cobrador/GetCobradorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Cobrador>(contents);
            return APIResponse;
        }

        public async Task UpdateCobrador(int id, Cobrador cobrador, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Cobrador>($"api/Cobrador/UpdateCobrador?id={id}", cobrador);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteCobrador(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Cobrador/DeleteCobrador?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //COLECCIONES
        #region
        public async Task<List<Coleccion>> GetAllColecciones(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Coleccion?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Coleccion>>(contents);
            return APIResponse;
        }

        public async Task<Coleccion> AddColeccion(Coleccion coleccion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Coleccion>($"api/Coleccion/AddColeccion", coleccion);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Coleccion>(contents);
            return APIResponse;
        }

        public async Task<Coleccion> GetColeccionById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Coleccion/GetColeccionById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Coleccion>(contents);
            return APIResponse;
        }

        public async Task UpdateColeccion(int id, Coleccion coleccion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Coleccion>($"api/Coleccion/UpdateColeccion?id={id}", coleccion);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteColeccion(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Coleccion/DeleteColeccion?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //DIRECTORES
        #region
        public async Task<List<Director>> GetAllDirectores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Director?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Director>>(contents);
            return APIResponse;
        }

        public async Task<Director> AddDirector(Director director, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Director>($"api/Director/AddDirector", director);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Director>(contents);
            return APIResponse;
        }

        public async Task<Director> GetDirectorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Director/GetDirectorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Director>(contents);
            return APIResponse;
        }

        public async Task UpdateDirector(int id, Director director, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Director>($"api/Director/UpdateDirector?id={id}", director);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteDirector(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Director/DeleteDirector?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //EDITOR
        #region
        public async Task<List<Editor>> GetAllEditores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Editor?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Editor>>(contents);
            return APIResponse;
        }

        public async Task<Editor> AddEditor(Editor Editor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Editor>($"api/Editor/AddEditor", Editor);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Editor>(contents);
            return APIResponse;
        }

        public async Task<Editor> GetEditorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Coleccion/GetEditorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Editor>(contents);
            return APIResponse;
        }

        public async Task UpdateEditor(int id, Editor Editor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Editor>($"api/Editor/UpdateEditor?id={id}", Editor);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteEditor(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Editor/DeleteEditor?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //EDITORIAL
        #region
        public async Task<List<Editorial>> GetAllEditoriales(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Editorial?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Editorial>>(contents);
            return APIResponse;
        }

        public async Task<Editorial> AddEditorial(Editorial editorial, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Editorial>($"api/Editorial/AddEditorial", editorial);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Editorial>(contents);
            return APIResponse;
        }

        public async Task<Editorial> GetEditorialById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Editorial/GetEditorialById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Editorial>(contents);
            return APIResponse;
        }

        public async Task UpdateEditorial(int id, Editorial editorial, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Editorial>($"api/Editorial/UpdateEditorial?id={id}", editorial);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteEditorial(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Editorial/DeleteEditorial?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //ENCUADERNACION
        #region
        public async Task<List<Encuadernacion>> GetAllEncuadernaciones(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Encuadernacion?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Encuadernacion>>(contents);
            return APIResponse;
        }

        public async Task<Encuadernacion> AddEncuadernacion(Encuadernacion encuadernacion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Encuadernacion>($"api/Encuadernacion/AddEditorial", encuadernacion);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Encuadernacion>(contents);
            return APIResponse;
        }

        public async Task<Encuadernacion> GetEncuadernacionById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Encuadernacion/GetEncuadernacionById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Encuadernacion>(contents);
            return APIResponse;
        }

        public async Task UpdateEncuadernacion(int id, Encuadernacion encuadernacion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Encuadernacion>($"api/Encuadernacion/Updateencuadernacion?id={id}", encuadernacion);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteEncuadernacion(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Encuadernacion/DeleteEncuadernacion?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //ESTADO SOCIO
        #region
        public async Task<List<EstadoSocio>> GetAllEstadoSocios(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/EstadoSocio?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<EstadoSocio>>(contents);
            return APIResponse;
        }

        public async Task<EstadoSocio> AddEstadoSocio(EstadoSocio estadoSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EstadoSocio>($"api/EstadoSocio/AddEstadoSocio", estadoSocio);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<EstadoSocio>(contents);
            return APIResponse;
        }

        public async Task<EstadoSocio> GetEstadoSocioById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/EstadoSocio/GetEstadoSocioById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<EstadoSocio>(contents);
            return APIResponse;
        }

        public async Task UpdateEstadoSocio(int id, EstadoSocio estadoSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<EstadoSocio>($"api/EstadoSocio/UpdateEstadoSocio?id={id}", estadoSocio);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEstadoSocio(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/EstadoSocio/DeleteEstadoSocio?id={id}", null);
            response.EnsureSuccessStatusCode();
        }
        #endregion

        //GENERO
        #region
        public async Task<List<Genero>> GetAllGeneros(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Genero?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Genero>>(contents);
            return APIResponse;
        }

        public async Task<Genero> AddGenero(Genero genero, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Genero>($"api/Genero/AddGenero", genero);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Genero>(contents);
            return APIResponse;
        }

        public async Task<Genero> GetGeneroById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Genero/GetGeneroById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Genero>(contents);
            return APIResponse;
        }

        public async Task UpdateGenero(int id, Genero genero, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Genero>($"api/Genero/UpdateGenero?id={id}", genero);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteGenero(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Genero/DeleteGenero?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //GUIONISTA
        #region
        public async Task<List<Guionista>> GetAllGuionistas(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Guionista?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Guionista>>(contents);
            return APIResponse;
        }

        public async Task<Guionista> AddGuionista(Guionista guionista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Guionista>($"api/Guionista/AddGuionista", guionista);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Guionista>(contents);
            return APIResponse;
        }

        public async Task<Guionista> GetGuionistaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Guionista/GetGuionistaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Guionista>(contents);
            return APIResponse;
        }

        public async Task UpdateGuionista(int id, Guionista guionista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Guionista>($"api/Guionista/UpdateGuionista?id={id}", guionista);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteGuionista(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Guionista/DeleteGuionista?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //IDIOMA
        #region
        public async Task<List<Idioma>> GetAllIdiomas(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Idioma?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Idioma>>(contents);
            return APIResponse;
        }

        public async Task<Idioma> AddIdioma(Idioma idioma, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Idioma>($"api/Idioma/AddIdioma", idioma);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Idioma>(contents);
            return APIResponse;
        }

        public async Task<Idioma> GetIdiomaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Idioma/GetIdiomaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Idioma>(contents);
            return APIResponse;
        }

        public async Task UpdateIdioma(int id, Idioma idioma, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Idioma>($"api/Idioma/UpdateIdioma?id={id}", idioma);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteIdioma(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Idioma/DeleteIdioma?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //INTERPRETE
        #region
        public async Task<List<Interprete>> GetAllInterpretes(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Interprete?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Interprete>>(contents);
            return APIResponse;
        }

        public async Task<Interprete> AddInterprete(Interprete interprete, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Interprete>($"api/Interprete/AddInterprete", interprete);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Interprete>(contents);
            return APIResponse;
        }

        public async Task<Interprete> GetInterpreteById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Interprete/GetInterpreteById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Interprete>(contents);
            return APIResponse;
        }

        public async Task UpdateInterprete(int id, Interprete interprete, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Interprete>($"api/Interprete/UpdateInterprete?id={id}", interprete);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteInterprete(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Interprete/DeleteInterprete?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

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

        //LUGAR
        #region
        public async Task<List<Lugar>> GetAllLugares(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Lugar?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Lugar>>(contents);
            return APIResponse;
        }

        public async Task<Lugar> AddLugar(Lugar lugar, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Lugar>($"api/Lugar/AddLugar", lugar);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Lugar>(contents);
            return APIResponse;
        }

        public async Task<Lugar> GetLugarById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Lugar/GetLugarById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Lugar>(contents);
            return APIResponse;
        }

        public async Task UpdateLugar(int id, Lugar lugar, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Lugar>($"api/Lugar/UpdateLugar?id={id}", lugar);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteLugar(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Lugar/DeleteLugar?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //MATERIA
        #region
        public async Task<List<Materia>> GetAllMaterias(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Materia?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Materia>>(contents);
            return APIResponse;
        }

        public async Task<Materia> AddMateria(Materia materia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Materia>($"api/Materia/AddMateria", materia);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Materia>(contents);
            return APIResponse;
        }

        public async Task<Materia> GetMateriaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Materia/GetMateriaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Materia>(contents);
            return APIResponse;
        }

        public async Task UpdateMateria(int id, Materia materia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Materia>($"api/Materia/UpdateMateria?id={id}", materia);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteMateria(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Materia/DeleteMateria?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PAIS
        #region
        public async Task<List<Pais>> GetAllPaises(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Pais?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Pais>>(contents);
            return APIResponse;
        }

        public async Task<Pais> AddPais(Pais pais, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Pais>($"api/Pais/AddPais", pais);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Pais>(contents);
            return APIResponse;
        }

        public async Task<Pais> GetPaisById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Pais/GetPaisById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Pais>(contents);
            return APIResponse;
        }

        public async Task UpdatePais(int id, Pais pais, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Pais>($"api/Pais/UpdatePais?id={id}", pais);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeletePais(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Pais/DeletePais?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PRESTAMO
        #region
        public async Task<List<Prestamo>> GetAllPrestamos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Prestamo?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Prestamo>>(contents);
            return APIResponse;
        }

        public async Task<Prestamo> AddPrestamo(Prestamo prestamo, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Prestamo>($"api/Prestamo/AddPrestamo", prestamo);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Prestamo>(contents);
            return APIResponse;
        }

        public async Task<Prestamo> GetPrestamoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Pais/GetPrestamoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Prestamo>(contents);
            return APIResponse;
        }

        public async Task UpdatePrestamo(int id, Prestamo prestamo, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Prestamo>($"api/Prestamo/UpdatePrestamo?id={id}", prestamo);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePrestamo(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Prestamo/DeletePrestamo?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PROCEDENCIA
        #region
        public async Task<List<Procedencia>> GetAllProcedencias(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Procedencia?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Procedencia>>(contents);
            return APIResponse;
        }

        public async Task<Procedencia> AddProcedencia(Procedencia procedencia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Procedencia>($"api/Procedencia/AddProcedencia", procedencia);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Procedencia>(contents);
            return APIResponse;
        }

        public async Task<Procedencia> GetProcedenciaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Procedencia/GetProcedenciaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Procedencia>(contents);
            return APIResponse;
        }

        public async Task UpdateProcedencia(int id, Procedencia procedencia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Procedencia>($"api/Procedencia/UpdateProcedencia?id={id}", procedencia);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProcedencia(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Procedencia/DeleteProcedencia?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PRODUCTOR
        #region
        public async Task<List<Productor>> GetAllProductores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productor?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Productor>>(contents);
            return APIResponse;
        }

        public async Task<Productor> AddProductor(Productor productor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Productor>($"api/Productor/AddProductor", productor);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Productor>(contents);
            return APIResponse;
        }

        public async Task<Productor> GetProductorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Productor/GetProductorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Productor>(contents);
            return APIResponse;
        }

        public async Task UpdateProductor(int id, Productor productor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Productor>($"api/Productor/UpdateProductor?id={id}", productor);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductor(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Productor/DeleteProductor?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PROFESION
        #region
        public async Task<List<Profesion>> GetAllProfesiones(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Profesion?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Profesion>>(contents);
            return APIResponse;
        }

        public async Task<Profesion> AddProfesion(Profesion profesion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Profesion>($"api/Profesion/AddProfesion", profesion);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Profesion>(contents);
            return APIResponse;
        }

        public async Task<Profesion> GetProfesionById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Profesion/GetProfesionById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Profesion>(contents);
            return APIResponse;
        }

        public async Task UpdateProfesion(int id, Profesion profesion, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Profesion>($"api/Profesion/UpdateProfesion?id={id}", profesion);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProfesion(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Profesion/DeleteProfesion?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PROVINCIA
        #region
        public async Task<List<Provincia>> GetAllProvincias(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Provincia?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Provincia>>(contents);
            return APIResponse;
        }

        public async Task<Provincia> AddProvincia(Provincia provincia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Provincia>($"api/Provincia/AddProvincia", provincia);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Provincia>(contents);
            return APIResponse;
        }

        public async Task<Provincia> GetProvinciaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Provincia/GetProvinciaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Provincia>(contents);
            return APIResponse;
        }

        public async Task UpdateProvincia(int id, Provincia provincia, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Provincia>($"api/Provincia/UpdateProfesion?id={id}", provincia);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProvincia(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Provincia/DeleteProvincia?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //SOCIOS
        #region
        public async Task<List<Socio>> GetAllSocios(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Socio?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Socio>>(contents);
            return APIResponse;
        }

        public async Task<Socio> AddSocio(Socio socio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Socio>($"api/Socio/AddSocio", socio);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Socio>(contents);
            return APIResponse;
        }

        public async Task<Socio> GetSocioById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Socio/GetSocioById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Socio>(contents);
            return APIResponse;
        }

        public async Task UpdateSocio(int id, Socio socio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Socio>($"api/Socio/UpdateSocio?id={id}", socio);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteSocio(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Socio/DeleteSocio?id={id}", null);
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

        //TIPO DE MATERIAL
        #region
        public async Task<List<TipoMaterial>> GetAllTipoMateriales(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoMaterial?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoMaterial>>(contents);
            return APIResponse;
        }

        public async Task<TipoMaterial> AddTipoMaterial(TipoMaterial tipoMaterial, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoMaterial>($"api/TipoMaterial/AddTipoMaterial", tipoMaterial);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoMaterial>(contents);
            return APIResponse;
        }

        public async Task<TipoMaterial> GetTipoMaterialById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoMaterial/GetTipoMaterialById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoMaterial>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoMaterial(int id, TipoMaterial tipoMaterial, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoMaterial>($"api/TipoMaterial/UpdateTipoMaterial?id={id}", tipoMaterial);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoMaterial(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoMaterial/DeleteTipoMaterial?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion


        //TIPO DE MOVIMIENTO
        #region
        public async Task<List<TipoMovimiento>> GetAllTipoMovimientos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoMovimiento?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoMovimiento>>(contents);
            return APIResponse;
        }

        public async Task<TipoMovimiento> AddTipoMovimiento(TipoMovimiento tipoMovimiento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoMovimiento>($"api/TipoMovimiento/AddTipoMovimiento", tipoMovimiento);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoMovimiento>(contents);
            return APIResponse;
        }

        public async Task<TipoMovimiento> GetTipoMovimientoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoMaterial/GetTipoMovimientoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoMovimiento>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoMovimiento(int id, TipoMovimiento tipoMovimiento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoMovimiento>($"api/TipoMovimiento/UpdateTipoMovimiento?id={id}", tipoMovimiento);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoMovimiento(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoMovimiento/DeleteTipoMovimiento?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion


        //MATERIAL MOVIMIENTO
        #region
        public async Task<List<MaterialMovimiento>> GetAllMaterialMovimientos(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/MaterialMovimiento?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<MaterialMovimiento>>(contents);
            return APIResponse;
        }

        public async Task<MaterialMovimiento> AddMaterialMovimiento(MaterialMovimiento materialMovimiento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<MaterialMovimiento>($"api/MaterialMovimiento/AddMaterialMovimiento", materialMovimiento);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<MaterialMovimiento>(contents);
            return APIResponse;
        }

        public async Task<MaterialMovimiento> GetMaterialMovimientoById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoMaterial/GetMaterialMovimientoById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<MaterialMovimiento>(contents);
            return APIResponse;
        }

        public async Task<List<MaterialMovimiento>> GetMaterialMovimientoBySocio(int socio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/MaterialMovimiento/GetMaterialMovimientoBySocio?socio={socio}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<MaterialMovimiento>>(contents);
            return APIResponse;
        }

        public async Task UpdateMaterialMovimiento(int id, MaterialMovimiento materialMovimiento, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<MaterialMovimiento>($"api/MaterialMovimiento/UpdateMaterialMovimiento?id={id}", materialMovimiento);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMaterialMovimiento(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/MaterialMovimiento/DeleteMaterialMovimiento?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion




        //TIPO DE SOCIO
        #region
        public async Task<List<TipoSocio>> GetAllTipoSocios(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSocio?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoSocio>>(contents);
            return APIResponse;
        }

        public async Task<TipoSocio> AddTipoSocio(TipoSocio tipoSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSocio>($"api/TipoSocio/AddTipoSocio", tipoSocio);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSocio>(contents);
            return APIResponse;
        }

        public async Task<TipoSocio> GetTipoSocioById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSocio/GetTipoSocioById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSocio>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoSocio(int id, TipoSocio tipoSocio, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSocio>($"api/TipoSocio/UpdateTipoSocio?id={id}", tipoSocio);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoSocio(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoSocio/DeleteTipoSocio?id={id}", null);
            response.EnsureSuccessStatusCode();

        }

        #endregion

        //TIPO DE SOPORTE
        #region
        public async Task<List<TipoSoporte>> GetAllTipoSoportes(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSoporte?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoSoporte>>(contents);
            return APIResponse;
        }

        public async Task<TipoSoporte> AddTipoSoporte(TipoSoporte tipoSoporte, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSoporte>($"api/TipoSoporte/AddTipoSoporte", tipoSoporte);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSoporte>(contents);
            return APIResponse;
        }

        public async Task<TipoSoporte> GetTipoSoporteById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSoporte/GetTipoSoporteById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSoporte>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoSoporte(int id, TipoSoporte tipoSoporte, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSoporte>($"api/TipoSoporte/UpdateTipoSoporte?id={id}", tipoSoporte);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoSoporte(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoSoporte/DeleteTipoSoporte?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //TIPO DE SUSPENSION
        #region
        public async Task<List<TipoSuspension>> GetAllTipoSuspensiones(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSuspension?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<TipoSuspension>>(contents);
            return APIResponse;
        }

        public async Task<TipoSuspension> AddTipoSuspension(TipoSuspension tipoSuspension, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSuspension>($"api/TipoSuspension/AddTipoSuspension", tipoSuspension);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSuspension>(contents);
            return APIResponse;
        }

        public async Task<TipoSuspension> GetTipoSuspensionById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/TipoSuspension/GetTipoSuspensionById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TipoSuspension>(contents);
            return APIResponse;
        }

        public async Task UpdateTipoSuspension(int id, TipoSuspension tipoSuspension, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TipoSuspension>($"api/TipoSuspension/UpdateTipoSuspension?id={id}", tipoSuspension);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTipoSuspension(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/TipoSuspension/DeleteTipoSuspension?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //TRADUCTOR
        #region
        public async Task<List<Traductor>> GetAllTraductores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Traductor?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Traductor>>(contents);
            return APIResponse;
        }

        public async Task<Traductor> AddTraductor(Traductor traductor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Traductor>($"api/Traductor/AddTraductor", traductor);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Traductor>(contents);
            return APIResponse;
        }

        public async Task<Traductor> GetTraductorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Traductor/GetTraductorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Traductor>(contents);
            return APIResponse;
        }

        public async Task UpdateTraductor(int id, Traductor traductor, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Traductor>($"api/Traductor/UpdateTraductor?id={id}", traductor);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteTraductor(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Traductor/DeleteTraductor?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //PROLOGUISTA
        #region
        public async Task<List<Prologuista>> GetAllProloguistas(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Prologuista?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Prologuista>>(contents);
            return APIResponse;
        }

        public async Task<Prologuista> AddProloguista(Prologuista prologuista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Prologuista>($"api/Prologuista/AddProloguista", prologuista);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Prologuista>(contents);
            return APIResponse;
        }

        public async Task<Prologuista> GetProloguistaById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Prologuista/GetProloguistaById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Prologuista>(contents);
            return APIResponse;
        }

        public async Task UpdateProloguista(int id, Prologuista prologuista, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Prologuista>($"api/Prologuista/UpdateProloguista?id={id}", prologuista);
            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteProloguista(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Prologuista/DeleteProloguista?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        //ILUSTRADOR
        #region
        public async Task<List<Ilustrador>> GetAllIlustradores(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Ilustrador?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<List<Ilustrador>>(contents);
            return APIResponse;
        }

        public async Task<Ilustrador> AddIlustrador(Ilustrador ilustrador, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Ilustrador>($"api/Ilustrador/AddIlustrador", ilustrador);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Ilustrador>(contents);
            return APIResponse;
        }

        public async Task<Ilustrador> GetIlustradorById(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Ilustrador/GetIlustradorById?id={id}");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<Ilustrador>(contents);
            return APIResponse;
        }

        public async Task UpdateIlustrador(int id, Ilustrador ilustrador, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Ilustrador>($"api/Ilustrador/UpdateIlustrador?id={id}", ilustrador);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteIlustrador(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.PutAsync($"api/Ilustrador/DeleteIlustrador?id={id}", null);
            response.EnsureSuccessStatusCode();
        }

        #endregion



        //TOTALES
        public async Task<TotalesDTO> GetTotales(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Home?");
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            var APIResponse = JsonConvert.DeserializeObject<TotalesDTO>(contents);
            return APIResponse;
        }

    }
}
