using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tables
{
    public abstract class BaseTable
    {
        [Key]
        public Guid Id { get; set; }

        public BaseTable()
        {
            this.Id = System.Guid.NewGuid();
            this.CreatedDate = DateTime.UtcNow;
        }

        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}