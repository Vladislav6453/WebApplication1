using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;

namespace WebApplication1.SQRS.Students
{
    public class GetListStudentByGroupCommand : IRequest<IEnumerable<StudentDTO>>
    {
        public int GroupId { get; set; }
        public class GetListStudentByGroupCommandHandler :
            IRequestHandler<GetListStudentByGroupCommand, IEnumerable<StudentDTO>>
        {

            private readonly Db131025Context db;
            public GetListStudentByGroupCommandHandler(Db131025Context db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<StudentDTO>> HandleAsync(GetListStudentByGroupCommand request,
                CancellationToken ct = default)
            {
                return db.Students.Where(s => s.IdGroup == request.GroupId).Select(s => new StudentDTO {FirstName = s.FirstName, Id = s.Id , LastName=s.LastName, Gender=s.Gender, Phone=s.Phone,IdGroup=s.IdGroup});
            }
        }
    }
}