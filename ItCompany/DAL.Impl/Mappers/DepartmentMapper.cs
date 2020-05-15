using DAL.Abstract;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl.Mappers
{
    public class DepartmentMapper : IMapper<Department, DepartmentDTO, EfCoreDepartmentRepository>
    {
        public EfCoreDepartmentRepository repo;

        public DepartmentMapper(EfCoreDepartmentRepository repo)
        {
            this.repo = repo;
        }

        public Department DeMap(DepartmentDTO dto)
        {
            Department entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Department()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                };
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            return entity;
        }

        public DepartmentDTO Map(Department entity)
        {
            return new DepartmentDTO()
            {
            Name = entity.Name,
            Id = entity.Id
            };
        }
    }
}
