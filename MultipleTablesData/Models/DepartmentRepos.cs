using Microsoft.EntityFrameworkCore;
using MultipleTablesData.DatabaseContext;
using System;

namespace MultipleTablesData.Models
{
    public class DepartmentRepos:IDepartmentRepos
    {
        private readonly ApplicationDbContext appDbContext;
        public DepartmentRepos(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
