using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TaskDTO : IDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullDiscription { get; set; }

        public DateTime Start { get; set; }
        
        public DateTime Deadline { get; set; }

        public bool Performed { get; set; }
    }
}
