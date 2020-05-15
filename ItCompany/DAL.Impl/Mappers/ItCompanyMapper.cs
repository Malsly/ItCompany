using DAL.Abstract;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Impl.Mappers
{
    public class ItCompanyMapper : IMapper<ItCompany, ItCompanyDTO, EfCoreItCompanyRepository>
    {
        public EfCoreItCompanyRepository repo;

        public ItCompanyMapper(EfCoreItCompanyRepository repo)
        {
            this.repo = repo;
        }

        public ItCompany DeMap(ItCompanyDTO dto)
        {
            ItCompany entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new ItCompany()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                };
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            return entity;
        }

        public ItCompanyDTO Map(ItCompany entity)
        {
            return new ItCompanyDTO()
            {
            Name = entity.Name,
            Id = entity.Id
            };
        }
    }
}
