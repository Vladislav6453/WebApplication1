using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication1.DB;
using WebApplication1.SQRS.DTO;

namespace WebApplication1.SQRS.Groups
{
    public class GetCreateNewGroupWithSpecComamnd : IRequest
    {
        public string NewGroupTitle { get; set; }
        public int NewGroupSpecial { get; set; }
        public class GetCreateNewGroupWithSpecComamndHandler :
            IRequestHandler<GetCreateNewGroupWithSpecComamnd, Unit>
        {

            private readonly Db131025Context db;
            public GetCreateNewGroupWithSpecComamndHandler(Db131025Context db)
            {
                this.db = db;
            }

            public async Task<Unit> HandleAsync(GetCreateNewGroupWithSpecComamnd request,
                CancellationToken ct = default)
            {
                Group newgroup = new Group { Title = request.NewGroupTitle, IdSpecial = request.NewGroupSpecial}; 
                db.Groups.Add(newgroup);
                
                return Unit.Value;
            }
        }
    }
}
