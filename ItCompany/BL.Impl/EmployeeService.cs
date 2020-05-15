using BL.Abstract;
using BL.Abstract.ResultWrappers;
using BL.Impl.ResultWrappers;
using DAL.Impl;
using DAL.Impl.Mappers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    public class EmployeeService : IEmployeeService
    {

        readonly EmployeeMapper Mapper;
        readonly EfCoreEmployeeRepository Repo;

        public EmployeeService(ItCompanyContext context)
        {
            Repo = new EfCoreEmployeeRepository(context);
            Mapper = new EmployeeMapper(Repo);
        }

        public IDataResult<List<EmployeeDTO>> GetAll()
        {
            return new DataResult<List<EmployeeDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<EmployeeDTO> Get(int id)
        {
            return new DataResult<EmployeeDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(EmployeeDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(EmployeeDTO dto)
        {
            Repo.Update(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Repo.Delete(id).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }
    }
}
