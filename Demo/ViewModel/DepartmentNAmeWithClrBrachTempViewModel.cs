namespace Demo.ViewModel
{
    public class DepartmentNAmeWithClrBrachTempViewModel
    {
        /*
         Vm :marger 2 model
            DEpartment + Employee
         
         */
        /*
         1) marge 2 model
         2) model add extra info
         3) send some model  property "alians"
         4) security "hide main table structure" web api
        */
        public int DeptId { get; set; }
        public string DeptName { get; set; } //==>MApping Name inside department
        public string Message { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        public DateTime CurrentTime { get; set; }
        public List<string> Branches { get; set; }

    }
}
