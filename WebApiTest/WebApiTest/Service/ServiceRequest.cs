using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiTest.Service
{
    public class ServiceRequest : IServiceRequest
    {
        private readonly HttpClient _httpClient;

        public ServiceRequest(HttpClient httpClient)
        {
          httpClient.BaseAddress = new Uri("http://deckofcardsapi.com/");
            _httpClient = httpClient;
        }

        public async Task<object> GetDeckOfCards(int cards)
        {
            var call = await _httpClient.GetAsync($"/api/deck/new/shuffle/?deck_count={cards}");
            var response = await call.Content.ReadAsStringAsync();

            return response;
        }


        public async Task<object> PostDeckOfCards(int cards)
        {
            var body = new { deck_count = cards };
            var bodyToSend = new StringContent(
               content: JsonSerializer.Serialize(body),
               encoding: Encoding.UTF8,
               mediaType: "application/json");

            var call = await _httpClient.PostAsync($"/api/deck/new/shuffle/", bodyToSend);
            var response = await call.Content.ReadAsStringAsync();

            return response;
        }
    }
}
