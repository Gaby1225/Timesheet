using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Timesheet.IT.Models;

namespace Timesheet.IT.Steps
{
    [Binding]
    public class AcoesCategorias : BaseStep
    {
        public AcoesCategorias(WebApplicationFactory<Startup> factory) : base(factory)
        {
            httpClient = factory.CreateClient();
        }

        private List<Categoria> listaCategorias = new List<Categoria>();
        private List<Categoria> listaId = new List<Categoria>();
        private readonly HttpClient httpClient;
        private HttpResponseMessage retornoGetById;

        [Given(@"as seguintes informações para cadastro de categoria:")]

        public void DadoAsSeguintesInformacoesParaCadastroDeCategoria(Table table)
        {
            DeleteAll();

            listaCategorias = table.CreateSet<Categoria>().ToList();//testar com o if aqui
        }

        [When(@"cadastrar a categoria")]
        public async Task QuandoCadastrarACategoria()
        {
            for (int n = 0; n < listaCategorias.Count(); n++)
            {
                var content = new StringContent(JsonSerializer.Serialize(listaCategorias[n]), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("api/V1/categorias", content);
            }
        }

        [Then(@"devem existir as categorias cadastradas")]
        public async Task EntaoDevemExistirAsCategoriasCadastradas(Table table)
        {
            var result = await httpClient.GetAsync("api/V1/categorias");
            var content = await result.Content.ReadAsStringAsync();
            var categoriasResult = JsonSerializer.Deserialize<IEnumerable<Categoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            table.CreateSet<Categoria>().Should().BeEquivalentTo(categoriasResult);
        }

        [Given(@"as seguintes informações para a consulta de todas as categorias:")]
        public void DadoAsSeguintesInformacoesParaAConsultaDeTodasAsCategorias(Table table)
        {
            DeleteAll();

            listaCategorias = table.CreateSet<Categoria>().ToList();
        }

        [When(@"consultar todas as categorias cadastradas")]
        public async Task QuandoConsultarTodasAsCategoriasCadastradas()
        {
            for (int n = 0; n < listaCategorias.Count(); n++)
            {
                var content = new StringContent(JsonSerializer.Serialize(listaCategorias[n]), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("api/V1/categorias", content);
            }
        }

        [Then(@"devem existir as categorias consultadas")]
        public async Task EntaoDevemExistirAsCategoriasConsultadas(Table table)
        {
            var result = await httpClient.GetAsync("api/V1/categorias");
            var content = await result.Content.ReadAsStringAsync();
            var categoriasResult = JsonSerializer.Deserialize<IEnumerable<Categoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            table.CreateSet<Categoria>().Should().BeEquivalentTo(categoriasResult);
        }

        [Given(@"as seguintes informações para a consulta de categoria por id:")]
        public async Task DadoAsSeguintesInformacoesParaAConsultaDeCategoriaPorId(Table table)
        {
            DeleteAll();

            listaCategorias = table.CreateSet<Categoria>().ToList();

            for (int n = 0; n < listaCategorias.Count(); n++)
            {
                var content = new StringContent(JsonSerializer.Serialize(listaCategorias[n]), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("api/V1/categorias", content);
            }
        }

        [When(@"consultar categoria cadastrada por id")]
        public async Task QuandoConsultarCategoriaCadastradaPorId(Table table)
        {
            listaId = table.CreateSet<Categoria>().ToList();
            var retornoId = await httpClient.GetAsync($"api/V1/categorias/{listaId[0].Id}");
            retornoGetById = retornoId;

        }

        [Then(@"deve existir a categoria consultada por id")]
        public async Task EntaoDeveExistirACategoriaConsultadaPorId(Table table)
        {
            var content = await retornoGetById.Content.ReadAsStringAsync();
            var categoriasResult = JsonSerializer.Deserialize<Categoria>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            table.CreateSet<Categoria>().FirstOrDefault().Should().BeEquivalentTo(categoriasResult);
        }

        [Given(@"as seguintes informações para exclusao por id:")]
        public async Task DadoAsSeguintesInformacoesParaExclusaoPorId(Table table)
        {
            DeleteAll();

            listaCategorias = table.CreateSet<Categoria>().ToList();

            for (int n = 0; n < listaCategorias.Count(); n++)
            {
                var content = new StringContent(JsonSerializer.Serialize(listaCategorias[n]), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("api/V1/categorias", content);
            }
        }

        [When(@"excluir a categoria por id")]
        public async Task QuandoExcluirACategoriaPorId(Table table)
        {
            listaId = table.CreateSet<Categoria>().ToList();
            var retornoId = await httpClient.DeleteAsync($"api/V1/categorias/{listaId[0].Id}");
            listaCategorias.Remove(listaId[0]);
        }

        [Then(@"devem existir apenas os seguintes retornos")]
        public async Task EntaoDevemExistirApenasOsSeguintesRetornos(Table table)
        {

            var result = await httpClient.GetAsync("api/V1/categorias");
            var content = await result.Content.ReadAsStringAsync();
            var categoriasResult = JsonSerializer.Deserialize<IEnumerable<Categoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            table.CreateSet<Categoria>().Should().BeEquivalentTo(categoriasResult);
        }

        [Given(@"as seguintes informações para edição por id:")]
        public async Task DadoAsSeguintesInformacoesParaEdicaoPorId(Table table)
        {
            DeleteAll();

            listaCategorias = table.CreateSet<Categoria>().ToList();

            for (int n = 0; n < listaCategorias.Count(); n++)
            {
                var content = new StringContent(JsonSerializer.Serialize(listaCategorias[n]), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync("api/V1/categorias", content);
            }
        }

        [When(@"editar a categoria por id")]
        public async Task QuandoEditarACategoriaPorId(Table table)
        {
            listaId = table.CreateSet<Categoria>().ToList();

            var id = listaId[0].Id;

            //ver se existe para só depois alterar
            var retornoId = await httpClient.GetAsync($"api/V1/categorias/{id}");
            var content = new StringContent(JsonSerializer.Serialize(listaId[0]), Encoding.UTF8, "application/json");
            var result = await httpClient.PutAsync($"api/V1/categorias/{id}", content);

        }

        //editar na lista
        [Then(@"devem existir todas as categorias e a editada")]
        public async Task EntaoDevemExistirTodasAsCategoriasEAEditada(Table table)
        {
            var result = await httpClient.GetAsync("api/V1/categorias");
            var content = await result.Content.ReadAsStringAsync();
            var categoriasResult = JsonSerializer.Deserialize<IEnumerable<Categoria>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            table.CreateSet<Categoria>().Should().BeEquivalentTo(categoriasResult);
        }


    }
}
