using Domain;
using MediatR;
using Persistence;

namespace Business.Projects;

public class Details
{
    public class Query : IRequest<Project>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Project>
    {
        private DataContext Context { get; }

        public Handler(DataContext context)
        {
            Context = context;
        }
        public async Task<Project> Handle(Query request, CancellationToken cancellationToken)
        {
            return await Context.Projects.FindAsync(request.Id);
        }
    }
}