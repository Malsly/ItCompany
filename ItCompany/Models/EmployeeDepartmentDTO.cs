﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EmployeeDepartmentDTO : IDTO
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
    }
}
