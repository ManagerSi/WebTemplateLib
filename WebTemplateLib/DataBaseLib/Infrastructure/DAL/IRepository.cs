﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
namespace DataBaseLib.Infrastructure.DAL {
  public interface IRepository<TEntity> where TEntity : class {
    IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");
    TEntity Create();
    TEntity GetByID(object id);
    TEntity Insert(TEntity entity);
    void Delete(object id);
    void Delete(TEntity entityToDelete);
    void Update(TEntity entityToUpdate);
  }


}