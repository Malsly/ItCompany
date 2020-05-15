using BL.Abstract.ResultWrappers;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IDepartmentService : IGenericService<DepartmentDTO>
    {
        IDataResult<List<DepartmentDTO>> GetAll();
        IDataResult<DepartmentDTO> Get(int id);
        IResult Add(DepartmentDTO dto);
        IResult Update(DepartmentDTO dto);
        IResult Delete(int id);
    }
}
