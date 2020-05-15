using DAL.Abstract;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl.Mappers
{
    public class EmployeeDepartmentMapper : IMapper<EmployeeDepartment, EmployeeDepartmentDTO, EfCoreEmployeeDepartmentRepository>
    {
        public EfCoreEmployeeDepartmentRepository repo;

        public EmployeeDepartmentMapper(EfCoreEmployeeDepartmentRepository repo)
        {
            this.repo = repo;
        }

        public EmployeeDepartment DeMap(EmployeeDepartmentDTO dto)
        {
            EmployeeDepartment entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new EmployeeDepartment()
                {
                    Id = dto.Id,
                    Department = new Department(),
                    Employee = new Employee(),
                };
            entity.Id = dto.Id;
            entity.Department = entity.Department;
            entity.Employee = entity.Employee;
            return entity;
        }

        public EmployeeDepartmentDTO Map(EmployeeDepartment entity)
        {
            return new EmployeeDepartmentDTO()
            {
            DepartmentId = entity.Department.Id.ToString(),
            EmployeeId = entity.Employee.Id.ToString(),
            Id = entity.Id
            };
        }
    }
}
