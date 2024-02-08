using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        //public List<Employee> GetAllWithoutInclue(string? navPro=null)
        //{
        //    if(navPro == null)
        //        return context.Employees.ToList();

        //    return context.Employees.Include(navPro).ToList();
        //}






        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context;
        }
        //CRUD
        public List<Employee> GetAll(string? include=null)//GetAll()
        {
            if(include != null)
                return context.Set<Employee>().Include(include).AsNoTracking().ToList();
            return context.Set<Employee>().ToList();

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
