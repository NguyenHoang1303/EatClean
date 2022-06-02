using Microsoft.AspNet.Identity.EntityFramework;

namespace EatClean.Entity
{
    public class Role: IdentityRole
    {
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
    }
}