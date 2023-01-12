namespace E_Commerce.core.ApplicationLayer.DTOModel.Order
{
    public class OrderListDTO
    {
        public int OderId { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SalesforceOrderId { get; set; }
    }
}
