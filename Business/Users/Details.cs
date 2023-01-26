using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Users
{
    public class Details
    {
        public class Query : IRequest<User>{
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            public Handler(DataContext context)
            {
                Context = context;
            }

            public DataContext Context { get; }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Context.Users.FindAsync(request.Id);
            }
        }
    }
}
