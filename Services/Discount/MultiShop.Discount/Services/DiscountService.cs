using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupons (CouponCode,Rate,IsActive,ValidDate) VALUES (@code,@rate,@isactive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.CouponCode);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isactive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connections = _dapperContext.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connections = _dapperContext.CreateConnection())
            {
                var values = await connections.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByICouponDto> GetByICouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connections = _dapperContext.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByICouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE CouponCode = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "SELECT COUNT(*) FROM Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public int GetDiscountCouponRate(string code)
        {
            string query = "SELECT Rate FROM Coupons WHERE CouponCode = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET CouponCode=@code, Rate = @rate, IsActive=@isactive, ValidDate=@validDate WHERE CouponId =@id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.CouponCode);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isactive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@id", updateCouponDto.CouponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
