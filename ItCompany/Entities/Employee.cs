using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Employee : IEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }
    }
}