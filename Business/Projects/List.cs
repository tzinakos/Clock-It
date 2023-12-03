using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Business.Projects;

public class List
{
    public class Query : IRequest<List<Project>> { }

    public class Handler : IRequestHandler<Query, List<Project>>
    {
        private DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        public async Task<List<Project>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Context.Projects.ToListAsync(cancellationToken);
        }
    }
}