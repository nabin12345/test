using BloggingPlatform.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BloggingPlatform.Models
{
    public class CategoryRepository : IRepository<Category>
    {
        // comment added
        BlogAppContext m_Context = null;

        public CategoryRepository(BlogAppContext context)
        {
            m_Context = context;
        }

        public void Add(Category entity)
        {
            m_Context.Categories.Add(entity);
        }

        public long Count()
        {
            return m_Context.Categories.Count();
        }

        public void Delete(Category entity)
        {
            m_Context.Categories.Remove(entity);
        }

        public Category Get(Expression<Func<Category, bool>> predicate)
        {
            return m_Context.Categories.SingleOrDefault(predicate);
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> predicate = null)
        {
            return m_Context.Categories.Where(predicate);
        }

        public void Update(Category entity)
        {
            m_Context.Categories.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.
            ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
    }
}