using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.StudentsOutGroups;

namespace WebApplication1.SQRS.GroupsWithStudents
{
    public class GetCountGroupAndCountStudentCommand : IRequest<IEnumerable<GroupDTO>>
    {
        public class GetCountGroupAndCountStudentCommandHandler :
           IRequestHandler<GetCountGroupAndCountStudentCommand, IEnumerable<GroupDTO>>
        {

            private readonly Db131025Context db;
            public GetCountGroupAndCountStudentCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<GroupDTO>> HandleAsync(GetCountGroupAndCountStudentCommand request,
                CancellationToken ct = default)
            {
                GroupDTO[] groups = await db.Groups.Select(s => new GroupDTO { Title = s.Title, Id = s.Id, IdSpecial = s.IdSpecial, StudentCount = s.Students.Count }).ToArrayAsync();
                return groups;
            }
        }
    }
}
