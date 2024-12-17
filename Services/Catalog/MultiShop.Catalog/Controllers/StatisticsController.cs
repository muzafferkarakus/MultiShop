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
        public IActionResult GetBrandCount()
        {
            var values = _statisticsService.GetBrandCount();
            return Ok(values);
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var values = _statisticsService.GetCategoryCount();
            return Ok(values);
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var values = _statisticsService.GetProductCount();
            return Ok(values);
        }
        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _statisticsService.GetProductAvgPrice();
            return Ok(values);
        }
        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var values = await _statisticsService.GetMaxPriceProductName();
            return Ok(values);
        }
        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var values = await _statisticsService.GetMinPriceProductName();
            return Ok(values);
        }
    }
}
