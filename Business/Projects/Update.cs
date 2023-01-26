using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Business.Projects;

public class Update
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
        public Project Project { get; set; }
    }
    
    public class Handler : IRequestHandler<Command>
    {
        private DataContext Context { get; }
        private IMapper Mapper { get; }

        public Handler(DataContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var project = await Context.Projects.FindAsync(request.Id);
            Mapper.Map(request.Project, project);

            await Context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}