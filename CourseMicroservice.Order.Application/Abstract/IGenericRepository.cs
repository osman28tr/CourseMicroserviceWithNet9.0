using CourseMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Application.Abstract
{
	public interface IGenericRepository<TId,T> where T : BaseEntity<TId>,new() where TId : struct
	{
		Task<bool> AnyAsync(TId id);
		IQueryable<T> Where(Expression<Func<T, bool>> predicate);
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(TId id);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(TId id);
	}
}
