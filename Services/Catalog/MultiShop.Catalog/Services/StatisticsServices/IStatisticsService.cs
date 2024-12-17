namespace MultiShop.Catalog.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        long GetCategoryCount();
        long GetProductCount();
        long GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
