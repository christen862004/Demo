namespace Demo.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll(string? include);
        
        public Employee GetByID(int id);
        
        public void Insert(Employee obj);
        
        public void Edit(Employee obj);
        
        public void Delete(int id);

        public void Save();
        //GetByDeptID
        public IQueryable<Employee> FindByDeptID(int deptID);
    }
}
