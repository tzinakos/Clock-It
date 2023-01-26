using AutoMapper;
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
            public Handler(DataContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }

            public DataContext Context { get; }
            public IMapper Mapper { get; }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await Context.Users.FindAsync(request.Id);
                Mapper.Map(request.User, user);
                await Context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
