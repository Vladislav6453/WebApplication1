using MyMediator.Interfaces;
using System.Collections;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.StudentsOutGroups;

namespace WebApplication1.SQRS.Students
{
    public class GetPovtorStudentToGroupCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public class GetPovtorStudentToGroupCommandHandler :
            IRequestHandler<GetPovtorStudentToGroupCommand,IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public GetPovtorStudentToGroupCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<StudentDTO>> HandleAsync(GetPovtorStudentToGroupCommand request,
                CancellationToken ct = default)
            {
                var duplicates = db.Groups.SelectMany(g => g.Students)
                     .GroupBy(g => g.Id)
                     .Where(g => g.Count() > 1)
                     .Select(g => g.First()).ToList()
                     .Select(s => new StudentDTO{ FirstName = s.FirstName, Id = s.Id, LastName = s.LastName, Gender = s.Gender, Phone = s.Phone, IdGroup = s.IdGroup });
                return duplicates;
            }
        }
    }
}
