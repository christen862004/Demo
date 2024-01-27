namespace Demo.Models
{
    public  static class StudentSampleData
    {
        private static List<Student> students;
        static StudentSampleData()
        {
            students = new List<Student>();
            students.Add(new Student() 
            { Id=1,Name="Ahmed",Address="Alex",Age=23,ImageURl="m.png"});
            students.Add(new Student()
            { Id = 2, Name = "Hala", Address = "Cairo", Age = 20, ImageURl = "2.jpg" });
            students.Add(new Student()
            { Id = 3, Name = "Alaa", Address = "Minia", Age = 23, ImageURl = "m.png" });
        }
        public static List<Student> GetAll()
        {
            return students;
        }
        public static Student GetByID(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }
    }
}
