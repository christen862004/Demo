namespace Demo.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context;
        }
        //CRUD
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employee GetByID(int id)
        {
            return context.Employees.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Edit(Employee obj)
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
        //GetByDeptID
        public IQueryable<Employee> FindByDeptID(int deptID)
        {
            return context.Employees.Where(e=>e.DepartmentID == deptID);
        }
    }
}
