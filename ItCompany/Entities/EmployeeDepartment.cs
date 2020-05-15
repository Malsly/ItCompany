using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class EmployeeDepartment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
        
    }
}
