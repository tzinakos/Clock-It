using MediatR;
using Persistence;

namespace Business.Users
{
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
                var user = await Context.Users.FindAsync(request.Id);
                Context.Users.Remove(user);
                await Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
