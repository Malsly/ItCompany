using BL.Abstract.ResultWrappers;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IItCompanyService : IGenericService<ItCompanyDTO>
    {
        IDataResult<List<ItCompanyDTO>> GetAll();
        IDataResult<ItCompanyDTO> Get(int id);
        IResult Add(ItCompanyDTO dto);
        IResult Update(ItCompanyDTO dto);
        IResult Delete(int id);
    }
}
