using MyMediator.Interfaces;
using MyMediator.Types;
using System.Linq;
using WebApplication1.DB;
using WebApplication1.SQRS.Groups;

namespace WebApplication1.SQRS.Students
{
    public class GetStudentPeveodToAnyGroupComamnd : IRequest
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public class GetStudentPeveodToAnyGroupComamndHandler :
            IRequestHandler<GetStudentPeveodToAnyGroupComamnd, Unit>
        {

            private readonly Db131025Context db;
            public GetStudentPeveodToAnyGroupComamndHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<Unit> HandleAsync(GetStudentPeveodToAnyGroupComamnd request,
                CancellationToken ct = default)
            {
                Group? group = db.Groups.FirstOrDefault(s => s.Id == request.GroupId);
                Student? student = db.Students.FirstOrDefault(s => s.Id == request.StudentId);
                try 
                {
                    if (group != null && student != null)
                    {
                        group.Students.Add(student);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("У вас нихрена не получается.");
                }
                
                return Unit.Value;
            }
        }
    }
}
