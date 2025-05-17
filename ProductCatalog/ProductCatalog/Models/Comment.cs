namespace ProductCatalog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}