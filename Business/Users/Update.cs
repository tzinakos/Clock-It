using Domain;
using MediatR;
using Persistence;

namespace Business.Users
{
    public class Update
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var user = await Context.Users.FindAsync(request.Id);
                user.FirstName = request.User.FirstName ?? user.FirstName;
                user.LastName = request.User.LastName ?? user.LastName;
                user.Email = request.User.Email ?? user.Email;
                user.PhoneNumber = request.User.PhoneNumber ?? user.PhoneNumber;
                await Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
