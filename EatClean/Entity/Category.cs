using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatClean.Entity
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public long ?CreatedAt { get; set; }
        public long ?UpdatedAt { get; set; }
        public long ?DeletedAt { get; set; }

        public bool validation()
        {
            if (string.IsNullOrEmpty(this.Name)) return false;
            if (string.IsNullOrEmpty(this.Description)) return false;
            return true;
        }
    }
}