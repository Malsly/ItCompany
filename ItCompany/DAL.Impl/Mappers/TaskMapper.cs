using DAL.Abstract;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl.Mappers
{
    public class TaskMapper : IMapper<Task, TaskDTO, EfCoreTaskEntityRepository>
    {
        public EfCoreTaskEntityRepository repo;

        public TaskMapper(EfCoreTaskEntityRepository repo)
        {
            this.repo = repo;
        }

        public Task DeMap(TaskDTO dto)
        {
            Task entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Task()
                {
                    Name = dto.Name,
                    FullDiscription = dto.FullDiscription,
                    Start = dto.Start,
                    Deadline = dto.Deadline,
                    Id = dto.Id,
                    Performed = dto.Performed
                };
            entity.Name = dto.Name;
            entity.FullDiscription = dto.FullDiscription;
            entity.Start = dto.Start;
            entity.Deadline = dto.Deadline;
            entity.Id = dto.Id;
            entity.Performed = dto.Performed;
            return entity;
        }

        public TaskDTO Map(Task entity)
        {
            return new TaskDTO()
            {
                Name = entity.Name,
                FullDiscription = entity.FullDiscription,
                Start = entity.Start,
                Deadline = entity.Deadline,
                Id = entity.Id,
                Performed = entity.Performed
            };
        }
    }
}
