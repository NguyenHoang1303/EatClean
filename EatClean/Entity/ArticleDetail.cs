using System.ComponentModel.DataAnnotations.Schema;

namespace EatClean.Entity
{
    public class ArticleDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}