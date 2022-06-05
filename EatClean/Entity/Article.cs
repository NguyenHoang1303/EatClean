using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Model;

namespace EatClean.Entity
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public ArticleDetail ArticleDetail { get; set; }
        public Tag Tags { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Status { get; set; }
        public long ?CreatedAt { get; set; }
        public long ?UpdatedAt { get; set; }
        public long ?DeletedAt { get; set; }
    }
}