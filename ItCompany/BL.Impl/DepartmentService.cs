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
    public class DepartmentService : IDepartmentService
    {

        readonly DepartmentMapper Mapper;
        readonly EfCoreDepartmentRepository Repo;

        public DepartmentService(ItCompanyContext context)
        {
            Repo = new EfCoreDepartmentRepository(context);
            Mapper = new DepartmentMapper(Repo);
        }

        public IDataResult<List<DepartmentDTO>> GetAll()
        {
            return new DataResult<List<DepartmentDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<DepartmentDTO> Get(int id)
        {
            return new DataResult<DepartmentDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(DepartmentDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(DepartmentDTO dto)
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
