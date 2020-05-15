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
    public class ItCompanyService : IItCompanyService
    {

        readonly ItCompanyMapper Mapper;
        readonly EfCoreItCompanyRepository Repo;

        public ItCompanyService(ItCompanyContext context)
        {
            Repo = new EfCoreItCompanyRepository(context);
            Mapper = new ItCompanyMapper(Repo);
        }

        public IDataResult<List<ItCompanyDTO>> GetAll()
        {
            return new DataResult<List<ItCompanyDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<ItCompanyDTO> Get(int id)
        {
            return new DataResult<ItCompanyDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(ItCompanyDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(ItCompanyDTO dto)
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
