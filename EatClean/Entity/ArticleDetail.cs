namespace EatClean.Entity
{
    public class ArticleDetail
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public int State { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
    }
}