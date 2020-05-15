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
    public class TaskService : ITaskService
    {

        readonly TaskMapper Mapper;
        readonly EfCoreTaskEntityRepository Repo;

        public TaskService(ItCompanyContext context)
        {
            Repo = new EfCoreTaskEntityRepository(context);
            Mapper = new TaskMapper(Repo);
        }

        public IDataResult<List<TaskDTO>> GetAll()
        {
            return new DataResult<List<TaskDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<TaskDTO> Get(int id)
        {
            return new DataResult<TaskDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(TaskDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(TaskDTO dto)
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
