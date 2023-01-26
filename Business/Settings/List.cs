namespace Business.Settings;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


public class List
{
    public class Query : IRequest<List<Domain.Settings>> { }

    public class Handler : IRequestHandler<Query, List<Domain.Settings>>
    {
        private DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        public async Task<List<Domain.Settings>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Context.Settings.ToListAsync(cancellationToken);
        }
    }
}