namespace Business.Settings;

using AutoMapper;
using Domain;
using MediatR;
using Persistence;

public class Update
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
        public Settings Settings { get; set; }
    }
    
    public class Handler : IRequestHandler<Command>
    {
        private DataContext Context { get; }
        private IMapper Mapper { get; }

        public Handler(DataContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var settings = await Context.Settings.FindAsync(request.Id);
            Mapper.Map(request.Settings, settings);

            await Context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}