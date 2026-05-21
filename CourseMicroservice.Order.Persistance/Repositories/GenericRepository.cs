using CourseMicroservice.Order.Application.Abstract;
using CourseMicroservice.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseMicroservice.Order.Persistance.Repositories
{
	public class GenericRepository<TId, T>(AppDbContext context) : IGenericRepository<TId, T> where T : BaseEntity<TId>, new() where TId : struct
	{
		protected AppDbContext _context = context;
		private readonly DbSet<T> _dbSet = context.Set<T>();


		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> AnyAsync(TId id)
		{
			return await _dbSet.AnyAsync(e => e.Id.Equals(id));
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate);
		}

		public async Task DeleteAsync(TId id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException($"Entity with id {id} not found.");
			}
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(TId id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
				return entity;
			throw new KeyNotFoundException($"Entity with id {id} not found.");
		}

		public async Task UpdateAsync(T entity)
		{
			var existingEntity = await _dbSet.FindAsync(entity.Id);
			if (existingEntity != null)
			{
				_context.Entry(existingEntity).CurrentValues.SetValues(entity);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException($"Entity with id {entity.Id} not found.");
			}
		}
	}
}
