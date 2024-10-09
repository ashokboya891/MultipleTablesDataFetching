﻿using Microsoft.EntityFrameworkCore;
using static MultipleTablesData.Models.EmployeeRepos;
using System;
using MultipleTablesData.DatabaseContext;

namespace MultipleTablesData.Models
{
    public class EmployeeRepos : IEmployeeRepos
    {

        private readonly ApplicationDbContext appDbContext;
        public EmployeeRepos(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }



        public async void DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.Include(e => e.Department).Include(f=>f.Location).FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                      //SeleCT*
                //FROM Employees e
            //JOIN Departments d ON e.DepartmentId = d.DepartmentId
                    //WHERE e.EmployeeId = @employeeId;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string? name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            { query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name)); }

            if (gender != null)
            { query = query.Where(e => e.Gender == gender); }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}