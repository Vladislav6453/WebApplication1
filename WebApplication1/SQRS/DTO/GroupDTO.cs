using WebApplication1.DB;

namespace WebApplication1.SQRS.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdSpecial { get; set; }

        public virtual Special? IdSpecialNavigation { get; set; }
    }
}
