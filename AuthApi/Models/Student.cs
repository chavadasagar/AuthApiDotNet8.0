using AuthApi.Validations;

namespace AuthApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        [StudentValidation]
        public string? Name { get; set; }
    }
    
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
