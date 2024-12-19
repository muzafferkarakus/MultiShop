using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByICouponDto> GetByICouponAsync(int id);
        Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code);
        int GetDiscountCouponRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
