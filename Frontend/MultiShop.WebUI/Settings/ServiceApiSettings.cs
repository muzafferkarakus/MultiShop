namespace MultiShop.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public ServisApi Catalog { get; set; }
        public ServisApi Image { get; set; }
        public ServisApi Discount { get; set; }
        public ServisApi Order { get; set; }
        public ServisApi Cargo { get; set; }
        public ServisApi Basket { get; set; }
        public ServisApi Payment { get; set; }
        public ServisApi Comment { get; set; }
        public ServisApi Message { get; set; }
    }
    public class ServisApi
    {
        public string Path { get; set; }
    }
}
