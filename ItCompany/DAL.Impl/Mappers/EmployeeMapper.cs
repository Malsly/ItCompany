using DAL.Abstract;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl.Mappers
{
    public class EmployeeMapper : IMapper<Employee, EmployeeDTO, EfCoreEmployeeRepository>
    {
        public EfCoreEmployeeRepository repo;

        public EmployeeMapper(EfCoreEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public Employee DeMap(EmployeeDTO dto)
        {
            Employee entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Employee()
                {
                    Name = dto.Name,
                    BornDate = dto.BornDate,
                    LastName = dto.LastName,
                    Id = dto.Id
                };
            entity.Name = dto.Name;
            entity.BornDate = dto.BornDate;
            entity.LastName = dto.LastName;
            entity.Id = dto.Id;
            return entity;
        }

        public EmployeeDTO Map(Employee entity)
        {
            return new EmployeeDTO()
            {
                Name = entity.Name,
                BornDate = entity.BornDate,
                LastName = entity.LastName,
                Id = entity.Id
            };
        }
    }
}
