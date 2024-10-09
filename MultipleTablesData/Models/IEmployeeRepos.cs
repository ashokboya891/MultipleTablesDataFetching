namespace MultipleTablesData.Models
{
    public interface IEmployeeRepos
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> Search(string? name, Gender? gender);

    }
}
