﻿using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyService
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("CargoCompany", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("CargoCompany?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompany");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(jsonData);
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompany/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("CargoCompany", updateCargoCompanyDto);
        }
    }
}
