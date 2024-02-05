using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    //Sql server - Server name - authantication - data base name "Options" Connection string"
    public class ITIContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //table ==>database 
        public ITIContext() : base()
        { }

        //using injection
        public ITIContext(DbContextOptions<ITIContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //builder ==>option
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=ITIIntake_44;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasData(new Department() { Id = 1,Name="SD",ManagerName="Ahmed"});
            modelBuilder.Entity<Department>()
                .HasData(new Department() { Id = 2, Name = "Full Stack", ManagerName = "Hager" });
            modelBuilder.Entity<Department>()
                .HasData(new Department() { Id = 3, Name = "Mearn", ManagerName = "Amira" });
           
            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id=1,Name="Alaa" ,Address="Alex",Age=22,Salary=7000,Image="m.png",DepartmentID=1});
            modelBuilder.Entity<Employee>()
                .HasData(new Employee() { Id = 2, Name = "Samar", Address = "Cairo", Age = 22, Salary = 7000, Image = "2.jpg", DepartmentID = 2 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
