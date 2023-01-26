namespace Business.Settings;

using Domain;
using MediatR;
using Persistence;

public class Details
{
    public class Query : IRequest<Settings>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Settings>
    {
        private DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        public async Task<Settings> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Context.Settings.FindAsync(request.Id);
        }
    }
}