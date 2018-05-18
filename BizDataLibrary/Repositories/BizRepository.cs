using BizDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BizDataLibrary.Repositories
{
    public class BizRepository<T> where T : class
    {
        private BizModel _context;

        //這是後來需要加的部分，讓子類別可以使用 _context 欄位
        protected BizModel Context
        { get { return _context; } }

        public BizRepository(BizModel context)
        {
            if(context == null)
            {
                throw new ArgumentNullException();
            }
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

    }
}
