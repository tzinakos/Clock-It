using AutoMapper;
using Business.IRepository;
using Domain;
using Models;
using Persistence;

namespace Business.Repository;

public class UserRepo : IOperate<UserModel>
{
    private DataContext Context { get; }
    private IMapper Mapper { get; }

    public UserRepo(DataContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
    
    public void Create(UserModel entry)
    {
        var userEntry = Mapper.Map<User>(entry);
        Context.Users.Add(userEntry);
        Context.SaveChanges();
    }

    public void Delete(Guid id)
    {
    }

    public void Update(UserModel entry)
    {
    }

    public UserModel Get(Guid id)
    {
        return new UserModel();
    }

    public List<UserModel> GetAll()
    {
        return new List<UserModel>();
    }
}