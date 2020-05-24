using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmployeeDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
    }
}
