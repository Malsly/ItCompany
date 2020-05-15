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
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {

        readonly EmployeeDepartmentMapper Mapper;
        readonly EfCoreEmployeeDepartmentRepository Repo;

        public EmployeeDepartmentService(ItCompanyContext context)
        {
            Repo = new EfCoreEmployeeDepartmentRepository(context);
            Mapper = new EmployeeDepartmentMapper(Repo);
        }

        public IDataResult<List<EmployeeDepartmentDTO>> GetAll()
        {
            return new DataResult<List<EmployeeDepartmentDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<EmployeeDepartmentDTO> Get(int id)
        {
            return new DataResult<EmployeeDepartmentDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(EmployeeDepartmentDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(EmployeeDepartmentDTO dto)
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
