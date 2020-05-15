using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using DAL.Abstract;

namespace Entities
{
    
    public class ItCompany : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Department> DepartmentList { get; set; }


    }
}
