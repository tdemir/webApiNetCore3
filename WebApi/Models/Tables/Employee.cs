using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Tables
{
    public class Employee : BaseTable
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Concat(Name, " ", Surname).Trim();
            }
        }

        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}