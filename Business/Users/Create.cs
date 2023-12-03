namespace Business.Users
{
    using Domain;
    using MediatR;
    using Persistence;

    public class Create
    {
        public class Command : IRequest
        {
            public User User { get; set; }
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
                Context.Users.Add(request.User);
                await Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
