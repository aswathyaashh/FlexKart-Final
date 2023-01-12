namespace E_Commerce.core.ApplicationLayer.BuyerModuleDTO
{
    public class ProductDTORes
    {
        public string id { get; set; }
        public bool success { get; set; }
        public List<object> errors { get; set; }
    }
}
