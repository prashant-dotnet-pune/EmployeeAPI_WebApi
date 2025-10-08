using EmployeeAPI_WebApi.Models;

namespace EmployeeAPI_WebApi.Repository
{
    public class EmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Prashant", Department = "IT", MobileNo = "9876543210", Email = "prashant@mail.com" },
            new Employee { Id = 2, Name = "Vishal", Department = "HR", MobileNo = "9998887776", Email = "vishal@mail.com" },
            new Employee { Id = 3, Name = "Neha", Department = "Finance", MobileNo = "8887776665", Email = "neha@mail.com" }
        };
        public static List<Employee> GetAll() => employees;

        public static Employee? GetById(int id) => employees.FirstOrDefault(e => e.Id == id);
        public static void Add(Employee emp) => employees.Add(emp);
        public static bool Update(Employee emp)
        {
            var existingEmp = GetById(emp.Id);
            if (existingEmp != null)
            {
                existingEmp.Name = emp.Name;
                existingEmp.Department = emp.Department;
                existingEmp.MobileNo = emp.MobileNo;
                existingEmp.Email = emp.Email;
                return true;
            }
            return false;
        }

        public static List<Employee> GetByDept(string dept)
        {
            return employees.Where(e=>e.Department.Equals(dept, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static bool Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                employees.Remove(emp);
                return true;
            }
            return false;
        }

        public static bool UpdateEmail(int id, string email)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                emp.Email = email;
                return true;
            }
            return false;
        }
    } 
}
