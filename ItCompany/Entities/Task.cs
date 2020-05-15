using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Task : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        public string FullDiscription { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
        
        [Required]
        public bool Performed { get; set; }
    }
}
