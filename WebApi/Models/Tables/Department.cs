using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tables
{
    public class Department : BaseTable
    {
        [Required]
        public string Name { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
    }
}