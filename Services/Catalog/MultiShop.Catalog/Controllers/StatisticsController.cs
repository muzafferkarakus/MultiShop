using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticsServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _statisticsService.GetBrandCount();
            return Ok(value);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await _statisticsService.GetCategoryCount();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await _statisticsService.GetProductCount();
            return Ok(value);
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var value = await _statisticsService.GetProductAvgPrice();
            return Ok(value);
        }


        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var value = await _statisticsService.GetMaxPriceProductName();
            return Ok(value);
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var value = await _statisticsService.GetMinPriceProductName();
            return Ok(value);
        }

    }
}
