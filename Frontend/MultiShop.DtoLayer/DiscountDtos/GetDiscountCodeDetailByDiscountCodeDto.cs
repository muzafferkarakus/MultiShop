﻿namespace MultiShop.DtoLayer.DiscountDtos
{
    public class GetDiscountCodeDetailByDiscountCodeDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
