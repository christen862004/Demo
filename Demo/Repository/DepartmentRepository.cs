
namespace Demo.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIContext context;

        public Guid Id { set; get; }

        public DepartmentRepository(ITIContext _context)//inject
        {
            context = _context;// new ITIContext();
            Id= Guid.NewGuid();//generate unique id
        }
        //CRUD
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Edit(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            context.Remove(GetByID(id));
        }
        public void Save()
        {
            context.SaveChanges();
        }
        //GetByName
    }
}
