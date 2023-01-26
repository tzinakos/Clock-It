using MediatR;
using Persistence;

namespace Business.Settings;

public class Create
{
    public class Command : IRequest
    {
        public Domain.Settings Settings { get; set; }
    }
    
    public class Handler : IRequestHandler<Command>
    {
        private DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await Context.Settings.AddAsync(request.Settings, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}