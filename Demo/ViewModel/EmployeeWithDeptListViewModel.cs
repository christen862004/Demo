using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.ViewModel
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> DeptList { get; set; }
    }
}
