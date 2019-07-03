using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountingSystem.Services.Interfaces.Service
{
    public interface IBaseService<TEntity,TEntityDto>
    {
        void Create(TEntityDto entityDto);
        void Create(IEnumerable<TEntityDto> entitiesDto);
        void Delete(Guid entityId);
      
        void Delete(TEntityDto entityDto);
        void Delete(IEnumerable<Guid> entitiesDto);
        TEntityDto GetById(Guid id);
        IEnumerable<TEntityDto> GetAll();
        IEnumerable<TEntityDto> GetAll(int page, int countOnPage, out int maxOfElement);

        IEnumerable<TEntityDto> GetFiltered(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, 
              IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");

        IEnumerable<TEntityDto> GetFiltered(int page, int countOnPage, out int maxOfElement,
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>,
              IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");
    }
}
