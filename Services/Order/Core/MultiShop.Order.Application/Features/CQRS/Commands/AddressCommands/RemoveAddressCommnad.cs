namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommnad
    {
        public int Id { get; set; }

        public RemoveAddressCommnad(int id)
        {
            Id = id;
        }
    }
}
