using BL.Abstract.ResultWrappers;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ITaskService : IGenericService<TaskDTO>
    {
        IDataResult<List<TaskDTO>> GetAll();
        IDataResult<TaskDTO> Get(int id);
        IResult Add(TaskDTO dto);
        IResult Update(TaskDTO dto);
        IResult Delete(int id);
    }
}
