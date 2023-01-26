using MediatR;
using Persistence;

namespace Business.Settings;

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

        private DataContext Context { get; }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var settings = await Context.Settings.FindAsync(request.Id);
            Context.Settings.Remove(settings!);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}