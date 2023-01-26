using Domain;
using MediatR;
using Persistence;

namespace Business.Projects;

public class Create
{
    public class Command : IRequest
    {
        public Project Project { get; set; }
    }
    
    public class Handler : IRequestHandler<Command>
    {
        public DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await Context.Projects.AddAsync(request.Project, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}