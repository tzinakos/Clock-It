namespace Business.Users
{
    using Domain;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class List
    {
        public class Query : IRequest<List<User>> { }

        public class Handler : IRequestHandler<Query, List<User>>
        {
            public Handler(DataContext context)
            {
                Context = context;
            }

            public DataContext Context { get; }

            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Context.Users.ToListAsync(cancellationToken);
            }
        }
    }
}