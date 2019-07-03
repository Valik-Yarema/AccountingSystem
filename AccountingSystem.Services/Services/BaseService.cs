using AccountingSystem.Models;
using AccountingSystem.Services.Interfaces.RepositoryInterfaces;
using AccountingSystem.Services.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Services
{
    public class BaseService<TEntity,TEntityDto> where TEntity : class where TEntityDto : class//, IBaseService<TEntity,TEntityDto>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IMapper mapper;

        public BaseService( IMapper mainMapper , IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
              mapper = mainMapper;
        }

        public virtual void Update(TEntityDto entityDto)
        {
            var entity = mapper.Map<TEntityDto, TEntity>(entityDto);
            _baseRepository.Update(entity);
            _baseRepository.Save();
        }

        public virtual void Update(IEnumerable<TEntityDto> entitiesDto)
        {

            try
            {
                var entities = mapper.Map<IEnumerable<TEntityDto>, IEnumerable<TEntity>>(entitiesDto);
                foreach (var entity in entities)
                {
                    _baseRepository.Update(entity);
                }
                _baseRepository.Save();

            }catch(Exception ex)
            {
              
                throw ex;
            }

        }

        public virtual void Create(TEntityDto entityDto)
        {
            var entity = mapper.Map<TEntityDto, TEntity>(entityDto);
            _baseRepository.Insert(entity);
            _baseRepository.Save();
        }

        public virtual void Create(IEnumerable<TEntityDto> entitiesDto)
        {
            try
            {
                var entities = mapper.Map<IEnumerable<TEntityDto>, IEnumerable<TEntity>>(entitiesDto);
                foreach (var entity in entities)
                {
                    _baseRepository.Insert(entity);
                }
                _baseRepository.Save();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Delete(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            if (entity != null)
            {
                _baseRepository.Delete(entity);
                _baseRepository.Save();
            }
        }

        public void Delete(TEntityDto entityDto)
        {
            var entity = mapper.Map<TEntityDto, TEntity>(entityDto);
            _baseRepository.Delete(entity);
            _baseRepository.Save();
        }

        public void Delete(IEnumerable<Guid> entitiesId)
        {
            try
            {
                //var entities = mapper.Map<IEnumerable<TEntityDto>, IEnumerable<TEntity>>(entitiesDto);

                foreach (var entityId in entitiesId)
                {
                    var entity = _baseRepository.GetById(entityId);
                    _baseRepository.Delete(entity);
                }
                _baseRepository.Save();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public virtual IEnumerable<TEntityDto> GetAll()
        {
            var entities = _baseRepository.GetAll();
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(entities);
        }

        public virtual IEnumerable<TEntityDto> GetAll(int page, int countOnPage, out int maxElement)
        {
            var entities=_baseRepository.GetAll(page, countOnPage, out maxElement);
            return mapper.Map< IEnumerable<TEntity>,IEnumerable<TEntityDto>>(entities);
        }
        public virtual IEnumerable<TEntityDto> GetFiltered(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>,
      IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = "")
        {
            var entities = _baseRepository.GetFiltered(filter, orderBy, includeProperties);

            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(entities);
        }

        public virtual IEnumerable<TEntityDto> GetFiltered(int page, int countOnPage,out int maxElement,
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>,
           IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            
            var entities = _baseRepository.GetFiltered(page, countOnPage,out maxElement, filter, orderBy,includeProperties);

            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityDto>>(entities);
        }

        public virtual TEntityDto GetById(Guid id)
        {
            return mapper.Map<TEntity, TEntityDto>(_baseRepository.GetById(id));
        }
     
    }
}
