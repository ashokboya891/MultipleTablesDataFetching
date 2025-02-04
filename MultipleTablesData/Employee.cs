﻿using System.ComponentModel.DataAnnotations;

namespace MultipleTablesData
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string PhotoPath { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; }


    }
}
