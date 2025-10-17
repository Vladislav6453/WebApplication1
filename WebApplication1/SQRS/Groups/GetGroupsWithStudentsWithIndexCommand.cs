using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;

namespace WebApplication1.SQRS.Groups
{
    public class GetGroupsWithStudentsWithIndexCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public int GroupSpecial { get; set; }
        public class GetGroupsWithStudentsWithIndexCommandHandler :
           IRequestHandler<GetGroupsWithStudentsWithIndexCommand, IEnumerable<GroupDTO>>
        {
            
            private readonly Db131025Context db;
            public GetGroupsWithStudentsWithIndexCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupsWithStudentsWithIndexCommand request,
                CancellationToken ct = default)
            {
                GroupDTO[] NoName = await db.Groups.Where(s => (s.Students.Count == 0) && (s.IdSpecial == request.GroupSpecial)).Select(s => new GroupDTO { Id = s.Id, Title = s.Title, IdSpecial = s.IdSpecial }).ToArrayAsync();
                return NoName;
            }
        }
    }
}
