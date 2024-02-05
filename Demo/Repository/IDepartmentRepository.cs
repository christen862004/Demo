namespace Demo.Repository
{
    public interface IDepartmentRepository
    {
        Guid Id { get; set; }

        public List<Department> GetAll();

        public Department GetByID(int id);

        public void Insert(Department obj);

        public void Edit(Department obj);

        public void Delete(int id);

        public void Save();
       
    }
}
