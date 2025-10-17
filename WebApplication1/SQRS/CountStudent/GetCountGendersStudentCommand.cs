using MyMediator.Interfaces;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;
using WebApplication1.SQRS.Students;

namespace WebApplication1.SQRS.CountStudent
{
    public class GetCountGendersStudentCommand : IRequest<GendersCountDTO>
    {
        public int GroupId { get; set; }

        public class GetCountStudentCommandHandler :
            IRequestHandler<GetCountGendersStudentCommand, GendersCountDTO>
        {

            private readonly Db131025Context db;
            public GetCountStudentCommandHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<GendersCountDTO> HandleAsync(GetCountGendersStudentCommand request,
                CancellationToken ct = default)
            {
                GendersCountDTO gendersCount = new GendersCountDTO();
                gendersCount.MaleCount = db.Students.Where(s => s.IdGroup == request.GroupId).Count(s => s.Gender == 1 );
                gendersCount.FemaleCount = db.Students.Where(s => s.IdGroup == request.GroupId).Count(s => s.Gender == 0);
                return gendersCount;
            }
        }
    }
}
