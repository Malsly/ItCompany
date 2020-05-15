using BL.Abstract.ResultWrappers;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IEmployeeDepartmentService : IGenericService<EmployeeDepartmentDTO>
    {
        IDataResult<List<EmployeeDepartmentDTO>> GetAll();
        IDataResult<EmployeeDepartmentDTO> Get(int id);
        IResult Add(EmployeeDepartmentDTO dto);
        IResult Update(EmployeeDepartmentDTO dto);
        IResult Delete(int id);
    }
}
