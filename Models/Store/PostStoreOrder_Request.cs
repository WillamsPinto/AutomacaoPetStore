namespace AutomacaoPetStore.Models
{
    public class PostStoreOrder_Request
    {
        public long id { get; set; }
        public long petId { get; set; }
        public int quantity { get; set; }
        public string shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }

    }
}
