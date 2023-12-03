namespace Business.IRepository;

public interface IOperate<T> where T : class
{
    public void Create(T entry);
    
    public void Delete(Guid id);
    
    public void Update(T entry);
    
    public T Get(Guid id);
    
    public List<T> GetAll();
}