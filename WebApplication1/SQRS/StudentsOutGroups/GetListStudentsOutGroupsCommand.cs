using Microsoft.EntityFrameworkCore;
using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.CountStudent;
using WebApplication1.SQRS.DTO;

namespace WebApplication1.SQRS.StudentsOutGroups
{
    public class GetListStudentsOutGroupsCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public class GetListStudentsOutGroupsCommandHandler :
            IRequestHandler<GetListStudentsOutGroupsCommand, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public GetListStudentsOutGroupsCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<StudentDTO>> HandleAsync(GetListStudentsOutGroupsCommand request,
                CancellationToken ct = default)
            {
                StudentDTO[] NoName = await db.Students.Where(s => s.IdGroup == null).Select(s => new StudentDTO { FirstName = s.FirstName, Id = s.Id, LastName = s.LastName, Gender = s.Gender, Phone = s.Phone, IdGroup = s.IdGroup }).ToArrayAsync();
                return NoName;
            }
        }
    }
}
