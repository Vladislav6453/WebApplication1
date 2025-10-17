using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.StudentsOutGroups;

namespace WebApplication1.SQRS.Groups
{
    public class GetGroupsOutOfStudentsCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public class GetGroupsOutOfStudentsCommandHandler :
           IRequestHandler<GetGroupsOutOfStudentsCommand, IEnumerable<GroupDTO>>
        {

            private readonly Db131025Context db;
            public GetGroupsOutOfStudentsCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetGroupsOutOfStudentsCommand request,
                CancellationToken ct = default)
            {
                GroupDTO[] NoName = await db.Groups.Where(s => s.Students.Count == 0).Select(s => new GroupDTO { Id = s.Id, Title = s.Title, IdSpecial = s.IdSpecial}).ToArrayAsync();
                return NoName;
            }
        }
    }
}
