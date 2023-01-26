using MediatR;
using Persistence;

namespace Business.Projects;

public class Delete
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        public Handler(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var project = await Context.Projects.FindAsync(request.Id);
            Context.Projects.Remove(project!);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}