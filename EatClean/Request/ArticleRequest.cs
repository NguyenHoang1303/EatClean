namespace EatClean.Request
{
    public class ArticleRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public int tagId { get; set; }
        public string contents { get; set; }
        public string thumbnail { get; set; }

        public bool validation()
        {
            if (string.IsNullOrEmpty(this.title)) return false;
            if (string.IsNullOrEmpty(this.description)) return false;
            if (string.IsNullOrEmpty(this.contents)) return false;
            if (this.categoryId <= 0) return false;
            return true;
        }
    }
}