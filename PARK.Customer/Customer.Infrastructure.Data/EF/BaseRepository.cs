using Domain.Entities;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF
{
    public class BaseRepository<T, TPrimaryKey, TFilters> : IBaseRepository<T, TPrimaryKey, TFilters> where T : BaseEntity<TPrimaryKey> where TFilters : Filter
    {
        protected readonly Park_CustomerContext _context;
        protected readonly DbSet<T> _entity;

        public BaseRepository(Park_CustomerContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(TFilters filters)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

            if (!string.IsNullOrEmpty(filters.OrderBy))
                return _entity.OrderBy(ti.ToTitleCase(filters.OrderBy));
            else
                return _entity.AsEnumerable();
        }

        public virtual IEnumerable<T> Get(ISpecification<T> specification = null)
        {
            //return ApplySpecification(specification).ToList();
            return ApplySpecification(specification);
        }

        public async virtual Task<T> Get(TPrimaryKey id)
        {
            T entity = await _entity.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"No existe el id {id}");

            return entity;
        }

        public virtual async Task Create(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _entity.Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            T entity = await _entity.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"No existe el id {id}");

            _entity.Remove(entity);

            await _context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }


    public static class Order
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(
       this IQueryable<TSource> query, string propertyName)
        {
            var entityType = typeof(TSource);

            //Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method.
            var enumarableType = typeof(System.Linq.Queryable);
            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == "OrderBy" && m.IsGenericMethodDefinition)
                 .Where(m =>
                 {
                     var parameters = m.GetParameters().ToList();
                     //Put more restriction here to ensure selecting the right overload                
                     return parameters.Count == 2;//overload that has 2 parameters
                 }).Single();
            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method
                 .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
    }
}

