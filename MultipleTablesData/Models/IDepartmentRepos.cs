namespace MultipleTablesData.Models
{
    public interface IDepartmentRepos
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
