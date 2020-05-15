
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DAL.Abstract;

namespace Entities
{
    [Serializable]
    public class Department : IEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Task> TaskList { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeList { get; set; }        
    }
}
