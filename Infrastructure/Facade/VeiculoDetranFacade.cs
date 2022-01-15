using Domain;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetranFacade
    {
        private readonly IOptionsMonitor<VeiculoDetranFacade> optionsMonitor;
        private readonly DetranOptions detranOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor, 
            IHttpClientFactory httpClientFactory, 
            IVeiculoRepository veiculoRepository)
        {
            this.detranOptions = optionsMonitor.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.veiculoRepository = veiculoRepository;
        }
        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = veiculoRepository.GetById(veiculoId);
            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(detranOptions.QuantidadeDiasParaAgendamento)
            };
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.VistoriaUri, contentString);

            HttpResponseMessage response = client.PostAsync(detranOptions.VistoriaUri, contentString).Result;
            var customerJsonString = response.Content.ReadAsStringAsync().Result;

        }
    }
}
